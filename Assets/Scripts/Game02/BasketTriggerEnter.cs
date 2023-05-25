using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketTriggerEnter : MonoBehaviour
{    
    [SerializeField] private int redBallPoints = 5;
    [SerializeField] private int blueBallPoints = 10;
    
    [SerializeField] private GameManager gameManager;    


    private void Start() {
                
    }
    

    private void OnTriggerExit(Collider other) {
        if(other.CompareTag("Basketball"))
        {
            //Llamada a método de GameManager para aumentar la puntuación
            gameManager.IncreaseScore(redBallPoints);            
        }
        if(other.CompareTag("BasketballBlue"))
        {
            //Llamada a método de GameManager para aumentar la puntuación
            gameManager.IncreaseScore(blueBallPoints, true);            
        }        
    }
}
