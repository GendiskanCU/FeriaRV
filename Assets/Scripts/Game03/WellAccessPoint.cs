using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WellAccessPoint : MonoBehaviour
{
    [SerializeField] private int duckScore = 2;
    [SerializeField] private GameManager gameManager;
    public UnityEvent DuckCaught;

    private ParticleSystem splashEffect;


    private void Start() {
        splashEffect = transform.GetComponentInChildren<ParticleSystem>();
    }

   private void OnTriggerEnter(Collider other) {
    if(other.gameObject.CompareTag("Duck"))
    {
        splashEffect.Play();
        other.gameObject.SetActive(false);
        Destroy(other.gameObject);

        gameManager.IncreaseScore(duckScore);
        gameManager.DecreaseDucksInPoolGame03();

        DuckCaught.Invoke();
    }
   }
}
