using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolGameBoard : MonoBehaviour
{
    [SerializeField] private GameObject BaseGameBoard;
    [SerializeField] private GameManager gameManager;

    private GameObject currentGameBoard;    

    // Start is called before the first frame update
    void Start()
    {
        gameManager.OnGameStart.AddListener(CreateNewGameBoard);        
    }

    private void CreateNewGameBoard()
    {
        if(currentGameBoard != null)
        {
            currentGameBoard.gameObject.SetActive(false);
            Destroy(currentGameBoard);
        }
        
        currentGameBoard = Instantiate(BaseGameBoard, transform.position, transform.rotation);
    }    
}
