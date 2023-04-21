using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCollision : MonoBehaviour
{
     [SerializeField] private float forceMagnitude = 2.5f;

     private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other) {

        

         if(other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Rigidbody rbOther = other.GetComponent<Rigidbody>();
            //if(rbOther == null) return;

            Vector3 force = _rb.velocity.normalized * forceMagnitude;            

            ContactPoint [] contacts = new ContactPoint[10];
            if(other.GetComponent<Collider>().GetComponent<Collision>().GetContacts(contacts) > 0)
            {
                Vector3 point = contacts[0].point;
                rbOther.AddForceAtPosition(force, point, ForceMode.Impulse);
            }            

            _rb.velocity = Vector3.zero;
        }
    }
   
}
