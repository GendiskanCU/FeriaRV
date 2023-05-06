using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUICanvas : MonoBehaviour
{
    [SerializeField] private WatchUICanvas watchUICanvas;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("DedoIndice"))
        {
            switch(gameObject.name)
            {
                case "ButtonQuitApp":
                    Application.Quit();
                break;

                case "ButtonInventory":
                    watchUICanvas.ShowInventory();
                break;

                case "ButtonScore":
                    watchUICanvas.ShowScores();
                break;

                case "Watch":
                    watchUICanvas.gameObject.SetActive(!watchUICanvas.gameObject.activeSelf);
                break;
            }            
        }
    }
}
