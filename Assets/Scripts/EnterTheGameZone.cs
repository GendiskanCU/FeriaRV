using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterTheGameZone : MonoBehaviour
{
    [SerializeField] private string gameName;

    
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "OVRPlayerController")
        {
            SceneManager.LoadScene(gameName);
        }
    }
}
