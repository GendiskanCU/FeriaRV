using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPosition : MonoBehaviour
{
    [SerializeField] private AudioClip ReturnToMainSound;

    private AudioSource _audioSource;
    
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    //Si el objeto colisiona con el suelo vuelve a su posición de partida
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Floor" ||
        other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _audioSource.PlayOneShot(ReturnToMainSound);
            transform.position = initialPosition;
            transform.rotation = initialRotation;
        }
    }
}
