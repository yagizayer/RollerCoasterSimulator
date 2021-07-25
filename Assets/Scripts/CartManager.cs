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
            child.Translate(new Vector3(.75f, .4f, 0), Space.World);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerArea")) _triggerManager.Triggering(other.GetComponent<ControlAreaChecker>().ColliderID);
    }

    public void DeparentPlayer()
    {
        _player.SetParent(null);
    }

    public void AdjustSpeed(float speed)
    {
        // Debug.Log(_cartControlScript.speed);
        StopCoroutine("AdjustingSpeed");
        StartCoroutine(AdjustingSpeed(_cartControlScript.speed + speed));
    }

    private IEnumerator AdjustingSpeed(float targetSpeed)
    {
        float currentSpeed = _cartControlScript.speed;
        float lerpVal = 0;
        while (lerpVal <= 1)
        {
            float newSpeed = Mathf.Lerp(currentSpeed, targetSpeed, lerpVal);
            _cartControlScript.speed = newSpeed;
            lerpVal += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
    }

    public void AddForceToPlayer(float force)
    {
        Rigidbody rbPlayer = _player.GetComponent<Rigidbody>();
        rbPlayer.useGravity = true;
        rbPlayer.isKinematic = false;
        rbPlayer.AddForce(_player.forward * force * 3 + _player.up * force, ForceMode.VelocityChange);
    }
}
