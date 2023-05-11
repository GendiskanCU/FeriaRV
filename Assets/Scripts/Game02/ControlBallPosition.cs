using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class ControlBallPosition : MonoBehaviour
{
    private Vector3 initialPosition;
    private Rigidbody _rigidbody;
    
    [SerializeField] private int secondsUntilReturn = 5;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("InvisibleGround") || other.gameObject.CompareTag("GameGround"))
        {
            Invoke("ReturnToInitialPosition", secondsUntilReturn);
        }
         
    }
  


    private void ReturnToInitialPosition()
    {
        gameObject.SetActive(false);
        _rigidbody.isKinematic = true;
        transform.position = initialPosition;
        _rigidbody.isKinematic = false;
        gameObject.SetActive(true);
    }
}
