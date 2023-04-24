using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameButtonsCanvas : MonoBehaviour
{    
    [SerializeField] private Material materialUnlocked;
    [SerializeField] private Material materialLocked;

    [SerializeField] private GameInfoCanvas gameInfoCanvas;
    
    private bool locked;
    private bool waitingForExitResponse;
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
                    gameInfoCanvas.ShowGameInstructions();
                    GameObject.Find("StartButton").GetComponent<GameButtonsCanvas>().Unlock();
                    GameObject.Find("ExitButton").GetComponent<GameButtonsCanvas>().Unlock();
                    waitingForExitResponse = false;
                break;

                case "StartButton": 
                    Lock();
                    gameInfoCanvas.ShowAMessage("El juego está en marcha... ¡SUERTE!");                   
                    GameObject.Find("GameBoard").GetComponent<GameBoard>().GameBegins();
                    GameObject.Find("InstructionsButton").GetComponent<GameButtonsCanvas>().Unlock();
                    GameObject.Find("ExitButton").GetComponent<GameButtonsCanvas>().Unlock();
                    waitingForExitResponse = false;
                break;

                case "ExitButton":
                    if(!waitingForExitResponse)
                    {
                        waitingForExitResponse = true;
                        gameInfoCanvas.ShowExitMessage();
                        GameObject.Find("InstructionsButton").GetComponent<GameButtonsCanvas>().Unlock();
                        GameObject.Find("StartButton").GetComponent<GameButtonsCanvas>().Unlock();
                    }                        
                    else
                    {
                        gameInfoCanvas.ShowAMessage("Saliendo del juego... Gracias por tu visita");
                    }
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
