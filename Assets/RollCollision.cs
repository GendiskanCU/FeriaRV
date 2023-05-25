using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollCollision : MonoBehaviour
{
    [SerializeField] private AudioClip rollCollisionAudio;

    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other) {
        _audioSource.PlayOneShot(rollCollisionAudio);
    }
}
