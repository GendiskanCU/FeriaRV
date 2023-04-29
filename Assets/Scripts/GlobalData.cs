using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalData : MonoBehaviour
{
    private int totalScore = 0;    

    public static GlobalData SharedInstance;

    public int TotalScore { get => totalScore; set => totalScore = value; }

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
    }
}
