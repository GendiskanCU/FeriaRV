using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketTriggerEnter : MonoBehaviour
{    
    [SerializeField] private int bonusScore = 1;
    
    private GameManager gameManager;    


    private void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();        
    }
    

    private void OnTriggerExit(Collider other) {
         if(other.CompareTag("Basketball"))
        {
            //Llamada a método de GameManager para aumentar la puntuación
            gameManager.IncreaseScore(bonusScore);            
        }
    }
}
