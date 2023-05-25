using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private float shootForce = 50.0f;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private AudioClip ballShootAudio;

    private bool leftHand = false;    

    public bool LeftHand { get => leftHand; set => leftHand = value; }
    public bool CanShoot { get => canShoot; set => canShoot = value; }
    
    private AudioSource _audioSource;
    private bool canShoot;    


    private void Start() {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        if(GetComponent<OVRGrabbable>().isGrabbed){        
            if(!LeftHand && OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
            {
                if(OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                {
                    BallShoot();
                }
            }

            if(LeftHand && OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
            {
                if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    BallShoot();      
                }
            }
        }
    }

    private void BallShoot()
    {
        if(CanShoot)
        {
            _audioSource.PlayOneShot(ballShootAudio);
            Instantiate(ball, shootPoint.position,
            shootPoint.rotation).GetComponent<Rigidbody>().AddForce(shootPoint.forward * shootForce * 1.5f);        
        }
        else
        {
            //No puede disparar
        }        
    }    
}
