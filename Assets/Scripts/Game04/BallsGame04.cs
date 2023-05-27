using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallsGame04 : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private List<Vector3> ballPosition = new List<Vector3>();

    private List<GameObject> ballsInGame04 = new List<GameObject>();
    
    
    void Start()
    {
        gameManager.OnGameStart.AddListener(GoToStartPosition);        

        foreach(Transform ball in transform)
        {
            Debug.LogError(string.Format("PosX: {0}, PosY: {1}, PosZ: {2}", ball.position.x, ball.position.y, ball.position.z));
            ballsInGame04.Add(ball.gameObject);
            ballPosition.Add(ball.position);
        }
    }

    private void GoToStartPosition()
    {
        int counter = 0;
        foreach(GameObject ball in ballsInGame04)
        {
            ball.gameObject.SetActive(false);
            Debug.LogError(string.Format("PosX: {0}, PosY: {1}, PosZ: {2}", ballPosition[counter].x, ballPosition[counter].y, ballPosition[counter].z));
            ball.transform.position = ballPosition[counter];
            ball.gameObject.SetActive(true);
            counter++;
        }
    }
}
