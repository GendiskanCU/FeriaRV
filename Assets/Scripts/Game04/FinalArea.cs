using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalArea : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private AudioClip ballLostSound;

    private AudioSource _audioSource;


    private void Start() {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("BallGame04"))
        {
            _audioSource.PlayOneShot(ballLostSound);
            gameManager.DecreaseAttempts(1);
            other.gameObject.SetActive(false);            
        }
    }
}
