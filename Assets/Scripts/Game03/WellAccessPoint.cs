using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WellAccessPoint : MonoBehaviour
{
    [SerializeField] private int duckScore = 2;
    [SerializeField]private int bonusTotalPoolGame03 = 10;
    [SerializeField]private int numberOfDucksGame03 = 15;
    [SerializeField] private GameManager gameManager;

    [SerializeField] private AudioClip duckInWellAudio;    

    public UnityEvent DuckCaught;

    private ParticleSystem splashEffect;

    private AudioSource _audioSource;

    private int ducks;


    private void Start() {
        splashEffect = transform.GetComponentInChildren<ParticleSystem>();
        _audioSource = GetComponent<AudioSource>();
        
        gameManager.OnGameStart.AddListener(SetDucksInCurrentPool);
    }

   private void OnTriggerEnter(Collider other) {
    if(other.gameObject.CompareTag("Duck"))
    {
        _audioSource.PlayOneShot(duckInWellAudio);
        splashEffect.Play();
        other.gameObject.SetActive(false);
        Destroy(other.gameObject);

        gameManager.IncreaseScore(duckScore);
        DecreaseDucksInPoolGame03();

        DuckCaught.Invoke();
    }
   }

    public void DecreaseDucksInPoolGame03()
    {
        ducks--;
        if(ducks <= 0)
        {
            gameManager.IncreaseScore(bonusTotalPoolGame03, true);             
            gameManager.EndGame();
        }
        else
        {
            gameManager.IncreaseScore(duckScore);
        }
    }

    private void SetDucksInCurrentPool()
    {
        ducks = numberOfDucksGame03;
    }
}
