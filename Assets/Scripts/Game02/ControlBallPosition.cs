using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class ControlBallPosition : MonoBehaviour
{
    [SerializeField] private AudioClip ReturnToMainSound, groundCollisionSound, ringCollisionSound, tableCollisionSound;

    private AudioSource _audioSource;

    private Vector3 initialPosition;
    private Rigidbody _rigidbody;
    private MeshRenderer _mesh;

    [SerializeField] private GameManager gameManager;
    
    [SerializeField] private int secondsUntilReturn = 5;

    [SerializeField] private Vector3 ReturnPositionForBallsGame04 = new Vector3(1.29900002f,1.04700005f,-1.44200003f);

    private bool isGoingToInitialPosition;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        if(gameObject.CompareTag("BallGame04"))
        {
            initialPosition = ReturnPositionForBallsGame04;
        }
        else
        {
            initialPosition = transform.position;
        }
        
        _rigidbody = GetComponent<Rigidbody>();
        _mesh = GetComponent<MeshRenderer>();

        
        gameManager.OnGameStart.AddListener(ShowBall);
        gameManager.OnGameEnds.AddListener(HideBall);

        HideBall();
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("InvisibleGround") || other.gameObject.CompareTag("GameGround"))
        {
            _audioSource.PlayOneShot(groundCollisionSound);
            if(!isGoingToInitialPosition)
            {
                isGoingToInitialPosition = true;
                Invoke("ReturnToInitialPosition", secondsUntilReturn);
            }
            
        }
        else if(other.gameObject.CompareTag("BasketRing"))
        {
            _audioSource.PlayOneShot(ringCollisionSound);
        }
        else if(other.gameObject.CompareTag("BasketTable"))
        {
            _audioSource.PlayOneShot(tableCollisionSound);
        }
         
    }
  


    private void ReturnToInitialPosition()
    {        
        gameObject.SetActive(false);
        _rigidbody.isKinematic = true;
        transform.position = initialPosition;
        _rigidbody.isKinematic = false;        
        gameObject.SetActive(true);
        _audioSource.PlayOneShot(ReturnToMainSound);
        
        isGoingToInitialPosition = false;
    }

    private void ShowBall()
    {
        if(!gameObject.CompareTag("BallGame04"))
        {            
            ReturnToInitialPosition();
        }
            
        _mesh.enabled = true;
    }

    private void HideBall()
    {
        _mesh.enabled = false;        
    }
}
