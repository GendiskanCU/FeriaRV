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

    

    private void Start() {
        unlockedPosition = transform.localPosition;
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.material = materialUnlocked;        
    }
    
    private void OnTriggerEnter(Collider other) {        
        if(other.gameObject.tag == "ButtonsPusser" && !locked)
        {            
            switch(gameObject.name)
            {
                case "InstructionsButton":  
                    Lock();
                    gameInfoCanvas.ShowAMessage("TIRA-ROLLOS: INSTRUCCIONES");                  
                    gameInfoCanvas.ShowGameInstructions();
                    GameObject.Find("StartButton").GetComponent<GameButtonsCanvas>().Unlock();
                    GameObject.Find("ExitButton").GetComponent<GameButtonsCanvas>().Unlock();                    
                break;

                case "StartButton": 
                    Lock();
                    gameInfoCanvas.ShowAMessage("El juego está en marcha... ¡SUERTE!");                   
                    GameObject.Find("GameBoard").GetComponent<GameBoard>().GameBegins();
                    GameObject.Find("InstructionsButton").GetComponent<GameButtonsCanvas>().Unlock();
                    GameObject.Find("ExitButton").GetComponent<GameButtonsCanvas>().Unlock();                    
                break;

                case "ExitButton":
                    Lock();                    
                    gameInfoCanvas.ShowAMessage("SALIDA DEL JUEGO ACTIVADA");
                    gameInfoCanvas.ShowExitMessage();
                    GameObject.Find("InstructionsButton").GetComponent<GameButtonsCanvas>().Unlock();
                    GameObject.Find("StartButton").GetComponent<GameButtonsCanvas>().Unlock();                    
                    waitingForExitResponse = true;
                break;
            }                        
        }

        if(other.gameObject.tag == "ButtonsPusser" && waitingForExitResponse && gameObject.name == "ExitButton")
        {
            //gameInfoCanvas.ShowAMessage("Saliendo del juego... ¡Gracias por tu visita!");
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
