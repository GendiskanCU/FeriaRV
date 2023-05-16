using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookController : MonoBehaviour
{
    private Rigidbody _rigidbody;

    private bool capturedDuck;

    private void Start() {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other) {
        if(!capturedDuck && other.gameObject.CompareTag("Duck"))
        {
            Debug.LogError("Pato");
            capturedDuck = true;
            /*other.gameObject.GetComponent<DuckMovement>().enabled = false;
            other.gameObject.AddComponent<SpringJoint>();
            other.gameObject.GetComponent<SpringJoint>().connectedBody = _rigidbody;
            other.gameObject.GetComponent<SpringJoint>().spring = 150;*/
            other.gameObject.transform.SetParent(gameObject.transform);
        }
    }
}
