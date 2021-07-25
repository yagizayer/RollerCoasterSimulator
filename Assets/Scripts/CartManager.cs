using System.Collections;
using System.Collections.Generic;
using PathCreation.Examples;
using UnityEngine;
using Helper;

[RequireComponent(typeof(PathFollower), typeof(SphereCollider), typeof(Rigidbody)), SelectionBase]
public class CartManager : MonoBehaviour
{
    [SerializeField] private PathFollower _cartControlScript;
    private TriggerManager _triggerManager;
    private Transform _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
        _triggerManager = FindObjectOfType<TriggerManager>();
        _cartControlScript = GetComponent<PathFollower>();
    }
    public void EnableCartFollowAfterDelay()
    {
        StartCoroutine(WaitForCartStart());
    }
    private IEnumerator WaitForCartStart()
    {
        yield return new WaitForSeconds(2f);
        _cartControlScript.enabled = true;
        foreach (Transform child in transform)
        {
            child.Translate(new Vector3(-.5f, .4f, 0), Space.World);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerArea")) _triggerManager.Triggering(other.GetComponent<ControlAreaChecker>().ColliderID);
    }

    public void ReparentPlayer()
    {
        _player.SetParent(transform);
    }
}
