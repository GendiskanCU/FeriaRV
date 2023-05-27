using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectPoint : MonoBehaviour
{
    [SerializeField] private int points = 10;
    [SerializeField] private int bonusScoreLimit = 10;

    //[SerializeField] private float waitTimeForNewTrigger = 1.0f;

    [SerializeField] private GameManager gameManager;

    //private bool acceptNewTrigger; 
    

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("BallGame04"))
        {            
            //Debug.LogError(string.Format("Se ha colado una bola: {0} puntos", points));            
            other.gameObject.SetActive(false);

            if(points > bonusScoreLimit)
            {
                gameManager.IncreaseScore(points, true);
            }
            else
            {
                gameManager.IncreaseScore(points);
            }
            
            gameManager.DecreaseAttempts(1);            
        }
        
    }    
}
