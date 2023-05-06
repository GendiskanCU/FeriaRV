using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBallHandGrip : MonoBehaviour
{
    [SerializeField] private Transform transformForLeftHand;
    [SerializeField] private Transform transformForRightHand;
    

    private OVRGrabbable _ovrGrabbable;


    private void Start() {
        _ovrGrabbable = GetComponent<OVRGrabbable>();
    }    
    
    private void OnTriggerEnter(Collider other) {

        if(other.CompareTag("PlayerHand"))
        {
            OVRGrabber grabber = other.GetComponent<OVRGrabber>();

            if(grabber.GetController() == OVRInput.Controller.LTouch)
            {
                _ovrGrabbable.SetSnapOffset(transformForLeftHand);                
            }

            if(grabber.GetController() == OVRInput.Controller.RTouch)
            {
                _ovrGrabbable.SetSnapOffset(transformForRightHand);                
            }
        }        
    }
}
