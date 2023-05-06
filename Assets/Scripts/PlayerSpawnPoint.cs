using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject [] spawnsPoints;

    

    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int nextSpawnPoint = GlobalData.SharedInstance.NextSpawnPoint;
        if(spawnsPoints.Length > 0 && (nextSpawnPoint >= 0 && nextSpawnPoint < spawnsPoints.Length ))
        {
            Debug.LogError(string.Format("({0}-{1}-{2})",spawnsPoints[nextSpawnPoint].transform.position.x, spawnsPoints[nextSpawnPoint].transform.position.y, spawnsPoints[nextSpawnPoint].transform.position.z));
            transform.localPosition = spawnsPoints[nextSpawnPoint].transform.position;
            transform.localRotation = spawnsPoints[nextSpawnPoint].transform.rotation;
        }
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
