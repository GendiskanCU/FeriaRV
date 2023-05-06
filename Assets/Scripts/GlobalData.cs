using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour
{
    private int totalScore = 0;   
    
    private int nextSpawnPoint = 0;//Punto de salida del player

    public static GlobalData SharedInstance;

    public int TotalScore { get => totalScore; set => totalScore = value; }
    public int NextSpawnPoint { get => nextSpawnPoint; set => nextSpawnPoint = value; }

    private void Awake() {
        if(SharedInstance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            SharedInstance = this;
            DontDestroyOnLoad(gameObject);
        }


        if(!PlayerPrefs.HasKey("MaxScore"))
        {
            PlayerPrefs.SetInt("MaxScore", 0);
        }
    }    
}
