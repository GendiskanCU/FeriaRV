using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsGame04 : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private List<Vector3> ballPosition = new List<Vector3>();
    // Start is called before the first frame update
    void Start()
    {
        gameManager.OnGameStart.AddListener(GoToStartPosition);        

        foreach(Transform ball in transform)
        {
            ballPosition.Add(ball.position);
        }
    }

    private void GoToStartPosition()
    {
        int counter = 0;
        foreach(Transform ball in transform)
        {
            ball.gameObject.SetActive(false);
            ball.position = ballPosition[counter];
            ball.gameObject.SetActive(true);
            counter++;
        }
    }
}
