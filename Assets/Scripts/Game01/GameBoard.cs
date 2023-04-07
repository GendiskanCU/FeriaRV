using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject whiteRoll, goldRoll;

    [SerializeField] private List<GameObject> rolls;

    private bool gameBoardCreated;

    // Start is called before the first frame update
    void Start()
    {
        CreateNewGameBoard();
    }

    private void Update() {
        if(Input.GetKeyDown("space") && gameBoardCreated)
        {
            RestoreBoard();
        }
        
    }

    private void CreateNewGameBoard()
    {
        GameObject newRoll;
        for(int pos = 0; pos <= 9; pos++)
        {
            if((pos >= 0 && pos <= 3) || (pos >= 7 && pos <= 8))//Primera y tercera filas
            {
                newRoll = Instantiate(whiteRoll, GetPosition(pos), spawnPoint.rotation);
            }
            else //Segunda y cuarta filas
            {
                newRoll = Instantiate(goldRoll, GetPosition(pos), spawnPoint.rotation);
            }

            newRoll.transform.parent = transform;
            rolls.Add(newRoll);
        }
    
        gameBoardCreated = true;
    }


    private void RestoreBoard()
    {
        for(int pos = 0; pos <= 9; pos++)
        {
            rolls[pos].transform.rotation = spawnPoint.rotation;
            rolls[pos].GetComponent<Rigidbody>().MovePosition(GetPosition(pos));            
        }
    }    

    private Vector3 GetPosition(int numberOfOrder)
    {
        Vector3 position = new Vector3(0, 0, 0);
        switch(numberOfOrder)
        {
            case 0:
                position = new Vector3(spawnPoint.position.x, spawnPoint.position.y + 0.07f, spawnPoint.position.z);
                break;
            case 1:
                position = new Vector3(spawnPoint.position.x + 0.11f, spawnPoint.position.y + 0.07f, spawnPoint.position.z);
                break;
            case 2:
                position = new Vector3(spawnPoint.position.x + 0.11f * 2, spawnPoint.position.y + 0.07f, spawnPoint.position.z);
                break;
            case 3:
                position = new Vector3(spawnPoint.position.x + 0.11f * 3, spawnPoint.position.y + 0.07f, spawnPoint.position.z);
                break;
            case 4:
                position = new Vector3(spawnPoint.position.x + 0.055f, spawnPoint.position.y + 0.22f, spawnPoint.position.z);
                break;
            case 5:
                position = new Vector3(spawnPoint.position.x + 0.055f + 0.11f, spawnPoint.position.y + 0.22f, spawnPoint.position.z);
                break;
            case 6:
                position = new Vector3(spawnPoint.position.x + 0.055f + 0.11f * 2, spawnPoint.position.y + 0.22f, spawnPoint.position.z);
                break;
            case 7:
                position = new Vector3(spawnPoint.position.x + 0.107f, spawnPoint.position.y + 0.37f, spawnPoint.position.z);
                break;
            case 8:
                position = new Vector3(spawnPoint.position.x + 0.107f + 0.11f, spawnPoint.position.y + 0.37f, spawnPoint.position.z);
                break;
            case 9:
                position = new Vector3(spawnPoint.position.x + 0.16f, spawnPoint.position.y + 0.52f, spawnPoint.position.z);
                break;
        }

        return position;
    }
}
