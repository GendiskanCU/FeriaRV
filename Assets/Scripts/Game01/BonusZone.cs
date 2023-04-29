using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusZone : MonoBehaviour
{
    [SerializeField] private GameInfoCanvas _gameInfoCanvas;
    [SerializeField] private int bonusScore = 1;

    private GameManager gameManager;


    private void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    

    private void OnTriggerExit(Collider other) {
         if(other.CompareTag("Player"))
        {
            //Llamada a método GameManager para aumentar la puntuación
            gameManager.IncreaseScore(bonusScore);
        }
    }
}
