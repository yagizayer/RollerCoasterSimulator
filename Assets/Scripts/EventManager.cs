using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [SerializeField] private UnityEvent CartInteraction = new UnityEvent();
    [SerializeField] private UnityEvent CartCrash = new UnityEvent();


    public void InvokeCartInteractionEvent()
    {

    }
    public void InvokeCartCrashEvent()
    {

    }
    public void TestFunc()
    {
        Debug.Log("test");
    }
}
