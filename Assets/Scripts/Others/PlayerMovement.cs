using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using Helper;

[RequireComponent(typeof(NavMeshAgent), typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private NavMeshAgent _navMeshAgent;
    [SerializeField] private EventManager _eventManager;
    [SerializeField, Range(0.001f, 10f)] private float _movementOffset;
    public Transform Hips;
    private Transform _mainCam;
    private SoundManager _soundManager;

    private void Start()
    {
        if (_soundManager == null) _soundManager = FindObjectOfType<SoundManager>();
        if (_eventManager == null) _eventManager = FindObjectOfType<EventManager>();
        if (_animator == null) _animator = GetComponentInChildren<Animator>();
        if (_navMeshAgent == null) _navMeshAgent = GetComponent<NavMeshAgent>();
        _mainCam = Camera.main.transform;
    }
    private void Update()
    {
        Vector3 moveDir = GetInputs().RelativeToCamera(_mainCam);
        if (moveDir.magnitude >= 0)
        {
            _animator.SetBool("Moving", true);
            _soundManager.PlaySound(SoundEffectsName.Walking);
        }
        if (moveDir.magnitude <= 0)
        {
            _soundManager.StopSound(SoundEffectsName.Walking);
            _animator.SetBool("Moving", false);
        }
        _navMeshAgent.SetDestination(transform.position + moveDir * _movementOffset);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            // interaction with cart
            Collider[] nearbyObjects = Physics.OverlapSphere(transform.position, 5);
            foreach (Collider item in nearbyObjects)
            {
                if (item.CompareTag("Cart"))
                    _eventManager.InvokeCartInteractionEvent();
            }
        }
    }


    private Vector3 GetInputs()
    {
        return new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    public void EnterCarAnimation()
    {
        transform.position = new Vector3(5.4f, 2.6f, 25.0f);
        transform.rotation = Quaternion.identity;
        StartCoroutine(SlideToRight());
        _animator.SetTrigger("EnterCar");
    }
    private IEnumerator SlideToRight()
    {
        Vector3 targetPosition = transform.position + Vector3.right;
        Vector3 currentPosition = transform.position;
        Vector3 newPos = Vector3.zero;
        float lerpVal = 0;

        yield return new WaitForSeconds(.5f);
        while (lerpVal <= 1)
        {
            newPos = Vector3.Lerp(currentPosition, targetPosition, lerpVal);
            transform.position = newPos;
            lerpVal += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
    }



}
