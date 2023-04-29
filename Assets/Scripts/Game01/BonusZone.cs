using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BonusZone : MonoBehaviour
{
    [SerializeField] private GameInfoCanvas _gameInfoCanvas;
    [SerializeField] private int bonusScore = 1;
    
    private GameManager gameManager;

    public UnityEvent OnRollOffBoard;


    private void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();        
    }
    

    private void OnTriggerExit(Collider other) {
         if(other.CompareTag("Player"))
        {
            //Llamada a método de GameManager para aumentar la puntuación
            gameManager.IncreaseScore(bonusScore);
            //Invoca evento para controlar que el rollo ha salido del tablero
            OnRollOffBoard.Invoke();
        }
    }
}
