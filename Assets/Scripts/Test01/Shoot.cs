using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private float shootForce = 50.0f;
    [SerializeField] private Transform shootPoint;

    private void Update() {
        if(GetComponent<OVRGrabbable>().isGrabbed){        
            if(OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
            {
                if(OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                {
                    Instantiate(ball, shootPoint.position,
                    shootPoint.rotation).GetComponent<Rigidbody>().AddForce(shootPoint.forward * shootForce);         
                }
            }
        }
    }
}
