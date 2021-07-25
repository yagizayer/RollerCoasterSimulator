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

    public void InvokeFirstRisingEvent()
    {
        FirstRisingEvent.Invoke();
    }
    public void InvokeSteepDropEvent()
    {
        SteepDropEvent.Invoke();
    }
    public void InvokeFirstLoopStartedEvent()
    {
        FirstLoopStartedEvent.Invoke();
    }
    public void InvokeFirstLoopEndedEvent()
    {
        FirstLoopEndedEvent.Invoke();
    }
    public void InvokeSecondLoopStartedEvent()
    {
        SecondLoopStartedEvent.Invoke();
    }
    public void InvokeSecondLoopEndedEvent()
    {
        SecondLoopEndedEvent.Invoke();
    }

    
}
