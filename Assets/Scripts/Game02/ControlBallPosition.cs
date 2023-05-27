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

    private Vector3 ReturnPositionForBallGame04 = new Vector3(2.588f, 0.889f, -1.181303f);

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        if(gameObject.CompareTag("BallGame04"))
        {
            initialPosition = ReturnPositionForBallGame04;
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
            Invoke("ReturnToInitialPosition", secondsUntilReturn);
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
