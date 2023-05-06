using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterTheGameZone : MonoBehaviour
{
    [SerializeField][Range(1, 4)] private int gameNumber = 1;

    
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "OVRPlayerController")
        {
            string gameScene = string.Format("Game0{0}", gameNumber);

            GlobalData.SharedInstance.NextSpawnPoint = gameNumber;

            SceneManager.LoadScene(gameScene);
        }
    }
}
