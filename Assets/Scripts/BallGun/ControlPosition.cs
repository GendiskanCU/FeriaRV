using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPosition : MonoBehaviour
{
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Floor")
        {
            transform.position = initialPosition;
            transform.rotation = initialRotation;
        }
    }
}
