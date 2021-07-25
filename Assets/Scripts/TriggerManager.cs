using System.Collections;
using System.Collections.Generic;
using RotaryHeart.Lib.SerializableDictionary;
using UnityEngine.Events;
using UnityEngine;
using Helper;

[System.Serializable]
class TriggerAreasDict : SerializableDictionaryBase<int, SphereCollider> { }

public class TriggerManager : MonoBehaviour
{
    [SerializeField] private int _colliderCount = 0;
    [SerializeField] private CartSpeedEventsManager _cartSpeedEventsManager;
    [SerializeField] private TriggerAreasDict Triggers;
    private void Start()
    {
        _cartSpeedEventsManager = FindObjectOfType<CartSpeedEventsManager>();
        
        foreach (Transform item in transform)
        {
            if (Triggers.ContainsKey(_colliderCount)) return;

            SphereCollider collider = item.GetComponent<SphereCollider>();
            if (collider != null)
            {
                ControlAreaChecker cac = item.gameObject.AddComponent<ControlAreaChecker>();
                cac.ColliderID = _colliderCount;

                Triggers[_colliderCount] = collider;

                _colliderCount++;
            }
        }
    }

    public void Triggering(int ColliderID)
    {
        if (ColliderID == 0)_cartSpeedEventsManager.InvokeFirstRisingEvent();
        if (ColliderID == 1)_cartSpeedEventsManager.InvokeSteepDropEvent();
        if (ColliderID == 2)_cartSpeedEventsManager.InvokeFirstLoopStartedEvent();
        if (ColliderID == 3)_cartSpeedEventsManager.InvokeFirstLoopEndedEvent();
        if (ColliderID == 4)_cartSpeedEventsManager.InvokeSecondLoopStartedEvent();
        if (ColliderID == 5)_cartSpeedEventsManager.InvokeSecondLoopEndedEvent();
    }
}
