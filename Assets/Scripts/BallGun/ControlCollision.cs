using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCollision : MonoBehaviour
{
     [SerializeField] private float forceMagnitude = 2.5f;

     [SerializeField] private GameObject collisionEffect;     

     private Rigidbody _rb;

     private GameManager gameManager;

    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    private void OnTriggerEnter(Collider other) {

        
        if(other.CompareTag("Player"))
        {
            Rigidbody rbOther = other.GetComponent<Rigidbody>();

            Vector3 force = _rb.velocity.normalized * forceMagnitude;

            rbOther.AddForceAtPosition(force, other.ClosestPoint(transform.position), ForceMode.Impulse);
        } 
        
        if(!other.CompareTag("Weapon") && !other.CompareTag("BonusZone"))
        {
            gameObject.SetActive(false);
            
            Instantiate(collisionEffect, transform.position, transform.rotation);

            gameManager.DecreaseAttempts(1);

            Destroy(gameObject);        
        }
        
    }
        
}
