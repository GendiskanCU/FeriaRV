using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class ControlBallPosition : MonoBehaviour
{
    [SerializeField] private AudioClip ReturnToMainSound;

    private AudioSource _audioSource;

    private Vector3 initialPosition;
    private Rigidbody _rigidbody;
    private MeshRenderer _mesh;

    [SerializeField] private GameManager gameManager;
    
    [SerializeField] private int secondsUntilReturn = 5;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        initialPosition = transform.position;
        _rigidbody = GetComponent<Rigidbody>();
        _mesh = GetComponent<MeshRenderer>();

        
        gameManager.OnGameStart.AddListener(ShowBall);
        gameManager.OnGameEnds.AddListener(HideBall);

        HideBall();
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("InvisibleGround") || other.gameObject.CompareTag("GameGround"))
        {
            Invoke("ReturnToInitialPosition", secondsUntilReturn);
        }
         
    }
  


    private void ReturnToInitialPosition()
    {
        //Debug.LogError("Colocando balones en su posición inicial");
        gameObject.SetActive(false);
        _rigidbody.isKinematic = true;
        transform.position = initialPosition;
        _rigidbody.isKinematic = false;        
        gameObject.SetActive(true);
        _audioSource.PlayOneShot(ReturnToMainSound);
    }

    private void ShowBall()
    {
        ReturnToInitialPosition();
        _mesh.enabled = true;
    }

    private void HideBall()
    {
        _mesh.enabled = false;
        //_rigidbody.isKinematic = true;
    }
}
