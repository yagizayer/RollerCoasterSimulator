using System.Collections;
using System.Collections.Generic;
using PathCreation.Examples;
using UnityEngine;

[RequireComponent(typeof(PathFollower), typeof(SphereCollider), typeof(Rigidbody)), SelectionBase]
public class CartManager : MonoBehaviour
{
    [SerializeField] private PathFollower _cartControlScript;
    private TriggerManager _triggerManager;

    private void Start()
    {
        _triggerManager = FindObjectOfType<TriggerManager>();
        _cartControlScript = GetComponent<PathFollower>();
    }
    private void EnableCartFollowAfterDelay()
    {
        StartCoroutine(WaitForCartStart());
        _cartControlScript.enabled = true;
    }
    private IEnumerator WaitForCartStart()
    {
        yield return new WaitForSeconds(1.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerArea")) _triggerManager.Triggering(other.GetComponent<ControlAreaChecker>().ColliderID);
    }
}
