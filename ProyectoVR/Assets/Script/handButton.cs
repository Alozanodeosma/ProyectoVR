using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

//https://www.youtube.com/watch?v=pmRwhE2hQ9g
public class handButton : XRBaseInteractable
{
    public UnityEvent OnPress = null;

    private float yMin = 0.0f;
    private float yMax = 0.0f;
    private bool previousPress = false;

    private float previousHandleHeight = 0.0f;
    private XRBaseInteractor hoverInteractor = null;

    public EnemySpawner enemySpawner;

    protected override void Awake()
    {
        base.Awake();
        onHoverEntered.AddListener(StratPress);
        onHoverExited.AddListener(EndPress);
    }

    private void OnDestroy()
    {
        onHoverEntered.RemoveListener(StratPress);
        onHoverExited.RemoveListener(EndPress);
    }

    private void StratPress(XRBaseInteractor interactor)
    {
        //Debug.Log("hola");
        enemySpawner.Start();
        hoverInteractor = interactor;
        previousHandleHeight = GetlocalYPosition(hoverInteractor.transform.position);
    }

    private void EndPress(XRBaseInteractor interactor)
    {
        hoverInteractor = null;
        previousHandleHeight = 0.0f;

        previousPress = false;
        SetYPosition(yMax);
    }

    private void Start()
    {
        SetMinMax();
    }

    private void SetMinMax()
    {
        Collider collider = GetComponent<Collider>();
        yMin = transform.localPosition.y - (collider.bounds.size.y * 0.5f);
        yMax = transform.localPosition.y;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        if (hoverInteractor)
        {
            float newHandHeight = GetlocalYPosition(hoverInteractor.transform.position);
            float handDifference = previousHandleHeight - newHandHeight;
            previousHandleHeight = newHandHeight;

            float newPosition = transform.localPosition.y - handDifference; 

            SetYPosition(newPosition);
            CheckPress();
        }
    }

    private float GetlocalYPosition(Vector3 position)
    {
        Vector3 localPosition = transform.root.InverseTransformPoint(position);

        return localPosition.y;
    }

    private void SetYPosition(float position)
    {
        Vector3 newPosition = transform.localPosition;
        newPosition.y = Mathf.Clamp(position, yMin, yMax);
        transform.localPosition = newPosition;
    }

    private void CheckPress()
    {
        bool inPosition = InPosition();

        if (inPosition && inPosition != previousPress)
        {
            OnPress.Invoke();
        }
        previousPress = inPosition;
    }


    private bool InPosition()
    {
        float inRange = Mathf.Clamp(transform.localPosition.y, yMin, yMax + 0.01f);

        return transform.localPosition.y == inRange;
    }


}
