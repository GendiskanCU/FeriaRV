using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutOfLevelControl : MonoBehaviour
{
    private Scene scene;
    [SerializeField] private GameObject canvasReloadingScene;
    
    void Start()
    {
        scene = SceneManager.GetActiveScene();       
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player"))
        {
            canvasReloadingScene.SetActive(true);
            StartCoroutine("ReloadingScene");
        }
    }

    private IEnumerator ReloadingScene()
    {        
        GlobalData.SharedInstance.NextSpawnPoint = 0;
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(scene.name);
    }
}
