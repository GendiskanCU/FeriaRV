using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBoard : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject whiteRoll, goldRoll;

    [SerializeField] private List<GameObject> rolls;

    [SerializeField] private float standbyTimeForNewBoard = 3.0f;
    [SerializeField] private int extraBonus = 3;

    [SerializeField] private AudioClip mountingNewBoarAudio;

    private bool gameBoardCreated;

    private int rollsInTable;
    private BonusZone bonusZone;

    private GameManager gameManager;

    private AudioSource _audioSource;


    private void Awake() {
        bonusZone = transform.Find("BonusZone").gameObject.GetComponent<BonusZone>();
        bonusZone.OnRollOffBoard.AddListener(UpdateNumberRolls);
    }

    private void Start() {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _audioSource = GetComponent<AudioSource>();
    }
    
    public void GameBegins()
    {
        if(gameBoardCreated)
            RestoreBoard();
        else
            CreateNewGameBoard();
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
            rollsInTable++;
        }
    
        gameBoardCreated = true;
    }


    private void RestoreBoard()
    {
        rollsInTable = rolls.Count;

        _audioSource.PlayOneShot(mountingNewBoarAudio);

        for(int pos = 0; pos < rolls.Count; pos++)
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
                position = new Vector3(spawnPoint.position.x + 0.165f, spawnPoint.position.y + 0.07f, spawnPoint.position.z);
                break;
            case 2:
                position = new Vector3(spawnPoint.position.x + 0.165f * 2, spawnPoint.position.y + 0.07f, spawnPoint.position.z);
                break;
            case 3:
                position = new Vector3(spawnPoint.position.x + 0.165f * 3, spawnPoint.position.y + 0.07f, spawnPoint.position.z);
                break;
            case 4:
                position = new Vector3(spawnPoint.position.x + 0.0825f, spawnPoint.position.y + 0.33f, spawnPoint.position.z);
                break;
            case 5:
                position = new Vector3(spawnPoint.position.x + 0.0825f + 0.165f, spawnPoint.position.y + 0.33f, spawnPoint.position.z);
                break;
            case 6:
                position = new Vector3(spawnPoint.position.x + 0.0825f + 0.165f * 2, spawnPoint.position.y + 0.33f, spawnPoint.position.z);
                break;
            case 7:
                position = new Vector3(spawnPoint.position.x + 0.1605f, spawnPoint.position.y + 0.555f, spawnPoint.position.z);
                break;
            case 8:
                position = new Vector3(spawnPoint.position.x + 0.1605f + 0.165f, spawnPoint.position.y + 0.555f, spawnPoint.position.z);
                break;
            case 9:
                position = new Vector3(spawnPoint.position.x + 0.24f, spawnPoint.position.y + 0.78f, spawnPoint.position.z);
                break;
        }

        return position;
    }    

    private void UpdateNumberRolls()
    {
        rollsInTable--;

        if(rollsInTable <= 0)
        {            
            StartCoroutine(PlacingNewBoard());
        }
    }

    private IEnumerator PlacingNewBoard()
    {
        gameManager.IncreaseScore(extraBonus, true);
        yield return new WaitForSeconds(standbyTimeForNewBoard);        
        RestoreBoard();
    }
}
