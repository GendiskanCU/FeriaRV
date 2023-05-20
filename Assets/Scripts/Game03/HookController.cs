using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookController : MonoBehaviour
{
    [SerializeField] private Vector3 capturePoint = new Vector3(-0.5f, -2.9f, 0);
    [SerializeField] private Vector3 capturedRotation = new Vector3(-90f, 90f, 0);

    [SerializeField] private float massIncrement = 0.350f;
    private Rigidbody _rigidbody;

    private bool capturedDuck;

    private void Start() {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other) {
        if(!capturedDuck && other.gameObject.CompareTag("Duck"))
        {            
            capturedDuck = true;
            
            other.gameObject.GetComponent<DuckMovement>().enabled = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.transform.SetParent(gameObject.transform);
            other.gameObject.transform.localPosition = capturePoint;
            other.gameObject.transform.localRotation = Quaternion.Euler(capturedRotation);

            _rigidbody.mass += massIncrement;
        }
    }

    private void DuckReleased()
    {
        capturedDuck = false;
        _rigidbody.mass -= massIncrement;
    }
}
