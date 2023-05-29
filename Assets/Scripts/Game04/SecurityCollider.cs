using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecurityCollider : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    [SerializeField] private AudioClip ballLostSound;

    [SerializeField] private float maxTimeWaiting = 10.0f;

    private float timeElapsed = 0;

    private AudioSource _audioSource;

    private void Start() {
        _audioSource = GetComponent<AudioSource>();
    }
    

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("BallGame04"))
        {
            StartCoroutine("StartWaitCrono");                     
        }
        
    }


    private void OnTriggerStay(Collider other) {

        if(timeElapsed >= maxTimeWaiting)
        {
            if(other.gameObject.CompareTag("BallGame04"))
            {
                _audioSource.PlayOneShot(ballLostSound);
                gameManager.DecreaseAttempts(1);
                other.gameObject.SetActive(false);            
            }   
        }       
    }   


    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("BallGame04"))
        {
            StopCoroutine("StartWaitCrono");
            timeElapsed = 0f;
        }
        
        
    } 


    private IEnumerator StartWaitCrono()
    {
        yield return new WaitForSeconds(1.0f);

        timeElapsed += 1;
    }
}
