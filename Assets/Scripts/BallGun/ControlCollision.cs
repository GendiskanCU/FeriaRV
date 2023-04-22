using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCollision : MonoBehaviour
{
     [SerializeField] private float forceMagnitude = 2.5f;

     [SerializeField] private GameObject collisionEffect;

     private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other) {

        
        if(other.CompareTag("Player"))
        {
            Rigidbody rbOther = other.GetComponent<Rigidbody>();

            Vector3 force = _rb.velocity.normalized * forceMagnitude;

            rbOther.AddForceAtPosition(force, other.ClosestPoint(transform.position), ForceMode.Impulse);
        } 

        if(!other.CompareTag("Weapon"))
        {
            Instantiate(collisionEffect, transform.position, transform.rotation);
            //Destroy(gameObject);
        }
    }
        
}
