using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookController : MonoBehaviour
{
    [SerializeField] private Vector3 capturePoint = new Vector3(-0.5f, -2.9f, 0);
    [SerializeField] private Vector3 capturedRotation = new Vector3(-90f, 90f, 0);    

    [SerializeField] private WellAccessPoint fishingCollectionPoint;

    [SerializeField] private GameManager gameManager;

    [SerializeField] private AudioClip duckCaughtAudio;

    private Rigidbody _rigidbody;
    private AudioSource _audioSource;

    private bool capturedDuck;
    private bool allowFishing;

    private void Start() {
        fishingCollectionPoint.DuckCaught.AddListener(DuckReleased);

        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();

        gameManager.OnGameStart.AddListener(AllowsFishing);
        gameManager.OnGameEnds.AddListener(PreventsFishing);
    }

    private void OnCollisionEnter(Collision other) {
        if(allowFishing && !capturedDuck && other.gameObject.CompareTag("Duck"))
        {            
            capturedDuck = true;

            _audioSource.PlayOneShot(duckCaughtAudio);
            
            other.gameObject.GetComponent<DuckMovement>().enabled = false;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.transform.SetParent(gameObject.transform);
            other.gameObject.transform.localPosition = capturePoint;
            other.gameObject.transform.localRotation = Quaternion.Euler(capturedRotation);            
        }
    }

    private void DuckReleased()
    {
        capturedDuck = false;        
    }

    private void PreventsFishing()
    {
        //Debug.LogError("Impide más pescas");
        allowFishing = false;
        if(transform.GetChild(0).gameObject != null)
        {
            Destroy(transform.GetChild(0).gameObject);            
        }
            
    }

    private void AllowsFishing()
    {
        allowFishing = true;
    }
}
