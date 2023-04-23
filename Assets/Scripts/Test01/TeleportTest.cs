using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTest : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] LayerMask layerGround;
    
    private RaycastHit hit;
    private LineRenderer line;
    private Transform player;
    private bool teleportAreaDetected;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        player = transform.parent.parent.parent.parent;
    }

    // Update is called once per frame
    void Update()
    {
        if(OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp))
        {
            Debug.Log("Pulsa joystick arriba");
            if(Physics.Raycast(transform.position, transform.forward, out hit, range, layerGround))
            {
                line.enabled = true;
                teleportAreaDetected = true;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, hit.point);
            }
            else
            {
                teleportAreaDetected = false;
            }
        }
        if(OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickUp) && teleportAreaDetected)
        {
            Debug.Log("Deja de pulsar joystick arriba");
            line.enabled = false;            
            player.GetComponent<CharacterController>().enabled = false;
            player.GetComponent<OVRPlayerController>().enabled = false;

            if(hit.transform.tag == "Floor")
            {
                player.transform.position = hit.transform.GetChild(0).transform.position;
            }
            else
            {
                player.transform.position = hit.point;
            }
                    
            player.GetComponent<CharacterController>().enabled = true;
            player.GetComponent<OVRPlayerController>().enabled = true;

            teleportAreaDetected = false;
        }
        
        /*if(OVRInput.Get(OVRInput.Button.PrimaryHandTrigger))
        {            
            if(Physics.Raycast(transform.position, transform.forward, out hit, range, layerGround))
            {
                line.enabled = true;
                line.SetPosition(0, transform.position);
                line.SetPosition(1, hit.point);
                if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    player.GetComponent<CharacterController>().enabled = false;
                    player.GetComponent<OVRPlayerController>().enabled = false;

                    if(hit.transform.tag == "Floor")
                    {
                        player.transform.position = hit.transform.GetChild(0).transform.position;
                    }
                    else
                    {
                        player.transform.position = hit.point;
                    }
                    
                    player.GetComponent<CharacterController>().enabled = true;
                    player.GetComponent<OVRPlayerController>().enabled = true;
                }
            }
            else
            {
                line.enabled = false;
            }
        }
        else
        {
            line.enabled = false;
        }*/
    }
}
