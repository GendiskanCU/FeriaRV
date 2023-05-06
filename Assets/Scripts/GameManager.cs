using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [SerializeField][Range(15, 1200)] private int timeForGame01 = 45;
    [SerializeField][Range(3, 100)] private int attemptsForGame01 = 5;

    [SerializeField] GameInfoCanvas gameInfoCanvas;

    public UnityEvent OnGameEnds;

    private int score = 0;
    private int totalTime = 0;
    private int remainingTime = 0;
    private int totalAttempts = 0;
    private int remainingAttempts = 0;

    private bool gameInProgress = false;

    private Shoot ballGun;
    
    void Start()
    {
        ballGun = GameObject.Find("BallGun").GetComponent<Shoot>();

        switch(SceneManager.GetActiveScene().name)
        {
            case "Game01":
                totalTime = timeForGame01;                
                totalAttempts = attemptsForGame01;                
            break;
        }
    }    

    private void EndGame()
    {
        gameInProgress = false;
        ballGun.CanShoot = false;        

        StopCoroutine(TimerGame());

        GlobalData.SharedInstance.TotalScore += score;

        

        if(GlobalData.SharedInstance.TotalScore > PlayerPrefs.GetInt("MaxScore"))       
        {
            PlayerPrefs.SetInt("MaxScore", GlobalData.SharedInstance.TotalScore);

            gameInfoCanvas.ShowAMessage(string.Format("FIN JUEGO. Sumas {0} puntos a un total de RECORD de {1} puntos",
         score, GlobalData.SharedInstance.TotalScore));
        }
        else
        {
            gameInfoCanvas.ShowAMessage(string.Format("JUEGO FINALIZADO. Has sumado {0} puntos y en total tienes {1} puntos",
         score, GlobalData.SharedInstance.TotalScore));
        }

        OnGameEnds.Invoke();
        
    }    

    private IEnumerator TimerGame()
    {  
        while(gameInProgress)      
        {
            yield return new WaitForSeconds(1.0f);
            remainingTime -= 1;
            gameInfoCanvas.ShowTimeText(FormatTime(remainingTime));

            if(remainingTime <= 0)
            {
                EndGame();
            }
        }        
    }

    private string FormatTime(int unformattedTime)
    {        
        int min = unformattedTime / 60;
        int sec = unformattedTime % 60;
        string fTime = string.Format("{0}:{1}", min.ToString("00"), sec.ToString("00"));
        return fTime;
    }


    public void StartNewGame()
    {
        remainingTime = totalTime;
        remainingAttempts = totalAttempts;
        score = 0;        

        gameInfoCanvas.ShowTimeText(FormatTime(remainingTime));
        gameInfoCanvas.ShowAttemptsText(remainingAttempts.ToString("00"));        
        gameInfoCanvas.ShowScoreText(score.ToString("000"));

        ballGun.CanShoot = true;
        gameInProgress = true;

        StartCoroutine(TimerGame());
    }

    public void IncreaseScore(int increment)
    {       
        score += increment;
        gameInfoCanvas.ShowScoreText(score.ToString("000"));        
    }

    public void DecreaseAttempts(int decrecement)
    {
        if(gameInProgress)
        {
            remainingAttempts -= decrecement;
            gameInfoCanvas.ShowAttemptsText(remainingAttempts.ToString("00"));

            if(remainingAttempts <= 0)
            {
                EndGame();
            }
        }        
    }
}
