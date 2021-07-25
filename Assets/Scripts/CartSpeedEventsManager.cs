using System.Collections;
using System.Collections.Generic;
using PathCreation.Examples;
using UnityEngine.Events;
using UnityEngine;

public class CartSpeedEventsManager : MonoBehaviour
{

    [SerializeField] private UnityEvent FirstRisingEvent = new UnityEvent();
    [SerializeField] private UnityEvent SteepDropEvent = new UnityEvent();
    [SerializeField] private UnityEvent FirstLoopStartedEvent = new UnityEvent();
    [SerializeField] private UnityEvent FirstLoopEndedEvent = new UnityEvent();
    [SerializeField] private UnityEvent SecondLoopStartedEvent = new UnityEvent();
    [SerializeField] private UnityEvent SecondLoopEndedEvent = new UnityEvent();

    private void InvokeFirstRisingEvent()
    {
        FirstRisingEvent.Invoke();
    }
    private void InvokeSteepDropEvent()
    {
        SteepDropEvent.Invoke();
    }
    private void InvokeFirstLoopStartedEvent()
    {
        FirstLoopStartedEvent.Invoke();
    }
    private void InvokeFirstLoopEndedEvent()
    {
        FirstLoopEndedEvent.Invoke();
    }
    private void InvokeSecondLoopStartedEvent()
    {
        SecondLoopStartedEvent.Invoke();
    }
    private void InvokeSecondLoopEndedEvent()
    {
        SecondLoopEndedEvent.Invoke();
    }

}
