using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButtonsCanvas : MonoBehaviour
{    
    [SerializeField] private Material materialUnlocked;
    [SerializeField] private Material materialLocked;

    [SerializeField] private GameInfoCanvas gameInfoCanvas;
    
    private bool locked = false;    

    public bool waitingForExitResponse = false;
    private MeshRenderer _meshRenderer;
    private Vector3 unlockedPosition;

    private GameManager gameManager;
    

    private void Start() {
        unlockedPosition = transform.localPosition;
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.material = materialUnlocked;        

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    
    private void OnTriggerEnter(Collider other) {        
        if(other.gameObject.tag == "ButtonsPusser" && !locked)
        {            
            switch(gameObject.name)
            {
                case "InstructionsButton":  
                    Lock();
                    gameInfoCanvas.ShowAMessage("INSTRUCCIONES");                  
                    gameInfoCanvas.ShowGameInstructions();                                                                                                  
                break;

                case "StartButton": 
                    Lock();
                    gameInfoCanvas.ShowAMessage("El juego está en marcha... ¡SUERTE!");                   
                    GameObject.Find("GameBoard").GetComponent<GameBoard>().GameBegins();
                    
                    GameObject.Find("InstructionsButton").GetComponent<GameButtonsCanvas>().Unlock();
                    GameObject.Find("ExitButton").GetComponent<GameButtonsCanvas>().Lock();

                    gameManager.StartNewGame();                                        
                break;

                case "ExitButton":                    
                    Lock();   
                    gameInfoCanvas.ShowAMessage("Saliendo del juego... ¡Gracias por tu visita!");
                    GameObject.Find("InstructionsButton").GetComponent<GameButtonsCanvas>().Lock();
                    GameObject.Find("StartButton").GetComponent<GameButtonsCanvas>().Lock();                                         
                    /*gameInfoCanvas.ShowAMessage("SALIR DEL JUEGO");
                    gameInfoCanvas.ShowExitMessage();*/                                                               
                break;
            }                                 
        }            
    } 

    public void Lock()
    {
        transform.localPosition = unlockedPosition + new Vector3(0.3f, 0, 0);        
        locked = true;
        _meshRenderer.material = materialLocked;
    }

    public void Unlock()
    {
        transform.localPosition = unlockedPosition;
        locked = false;
        _meshRenderer.material = materialUnlocked;
    }
}
