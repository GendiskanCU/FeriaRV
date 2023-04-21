using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollController : MonoBehaviour
{
    [SerializeField] private float forceMagnitude = 5f;

    private Rigidbody _rb;
    private Collider _col;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Weapon"))
        {
            _rb.isKinematic = false;
            _col.isTrigger = false;
            Vector3 forceDirection = other.GetComponent<Rigidbody>().velocity.normalized;
            _rb.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);
        }
    }


}
