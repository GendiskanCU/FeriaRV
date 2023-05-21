using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlFishingRodHandGrip : MonoBehaviour
{
    [SerializeField] private Transform transformForLeftHand;
    [SerializeField] private Transform transformForRightHand;
    // Start is called before the first frame update

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
                //GetComponent<Shoot>().LeftHand = true;
            }

            if(grabber.GetController() == OVRInput.Controller.RTouch)
            {
                _ovrGrabbable.SetSnapOffset(transformForRightHand);
                //GetComponent<Shoot>().LeftHand = false;
            }
        }        
    }  
}
