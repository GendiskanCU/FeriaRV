using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalArea : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("BallGame04"))
        {
            gameManager.DecreaseAttempts(1);
            other.gameObject.SetActive(false);            
        }
    }
}
