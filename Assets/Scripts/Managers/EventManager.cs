using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] private UnityEvent CartInteractionEvent = new UnityEvent();
    [SerializeField] private UnityEvent CartCrashEvent = new UnityEvent();


    public void InvokeCartInteractionEvent()
    {
        CartInteractionEvent.Invoke();
    }
    public void InvokeCartCrashEvent()
    {
        CartCrashEvent.Invoke();
    }
    public void TestFunc(string message)
    {
        Debug.Log(message);
    }
}
