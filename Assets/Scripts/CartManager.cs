using System.Collections;
using System.Collections.Generic;
using PathCreation.Examples;
using UnityEngine;

public class CartManager : MonoBehaviour
{
    [SerializeField] private PathFollower _cartControlScript;

    private void EnableCartFollowAfterDelay()
    {
        StartCoroutine(WaitForCartStart());
        _cartControlScript.enabled = true;
    }
    private IEnumerator WaitForCartStart()
    {
        yield return new WaitForSeconds(1.5f);
    }

}
