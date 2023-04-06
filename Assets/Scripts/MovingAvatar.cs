using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Sunbox.Avatars;

public class MovingAvatar : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private AvatarCustomization _avatar;
    private int currentWayPointIndex;
    private float pauseWalkTime;
    private float pauseGreetingTime;
    private float pauseClapTime;
    private float pauseDanceTime;
    private bool inWayPoint;

    private bool hasMovement = false;

    [SerializeField] private Transform [] wayPoints;
    [SerializeField][Range(0.5f, 10f)] private float minStopDuration = 0.5f;
    [SerializeField][Range(10.5f, 30f)] private float maxStopDuration = 15f;


    [SerializeField] private bool greetingOn;
    [SerializeField][Range(5f, 15f)] private float minTimeBetweenGreetings = 5.0f;
    [SerializeField][Range(20f, 60f)] private float maxTimeBetweenGreetings = 20.0f;


    [SerializeField] private bool clapOn;
    [SerializeField][Range(2f, 5f)] private float minTimeBetweenApplauses = 3.0f;
    [SerializeField][Range(6f, 10f)] private float maxTimeBetweenApplauses = 10.0f;


    [SerializeField] private bool danceOn;
    [SerializeField][Range(1f, 5f)] private float minTimeBetweenDances = 2.0f;
    [SerializeField][Range(6f, 10f)] private float maxTimeBetweenDances = 7.0f;

    

    // Start is called before the first frame update
    void Start()
    {        
        hasMovement = wayPoints.Length > 1;        

        _avatar = GetComponent<AvatarCustomization>();

        if(hasMovement)
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();        
            currentWayPointIndex = 0;         
            StartCoroutine("NextMove");
        }

        if(greetingOn)
        {
            pauseGreetingTime = Random.Range(minTimeBetweenGreetings, maxTimeBetweenGreetings);
            StartCoroutine("SayHello");
        }

        if(clapOn)
        {
            pauseClapTime = Random.Range(minTimeBetweenApplauses, maxTimeBetweenApplauses);
            StartCoroutine("Clap");
        }

        if(danceOn)
        {
            pauseDanceTime = Random.Range(minTimeBetweenDances, maxTimeBetweenDances);
            StartCoroutine("Dance");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(hasMovement)
        {
            if(!inWayPoint && _navMeshAgent.remainingDistance < _navMeshAgent.stoppingDistance)
            {
                inWayPoint = true;    
                  
                pauseWalkTime = Random.Range(minStopDuration, maxStopDuration);
                currentWayPointIndex = Random.Range(0, wayPoints.Length - 1) % wayPoints.Length;
            
                //Debug.Log(string.Format("Tiempo de espera: {0}\nPróximo way point: {1}", pauseWalkTime, currentWayPointIndex));
                StartCoroutine("NextMove");
            }
        }
        
    }

    private void LateUpdate() {
        ControlWalkAnimations();
    }

    private IEnumerator NextMove()
    {        
        yield return new WaitForSeconds(pauseWalkTime);
               
        _navMeshAgent.SetDestination(wayPoints[currentWayPointIndex].position);
        inWayPoint = false;                
    }

    private IEnumerator SayHello()
    {
        while(greetingOn)
        {            
            yield return new WaitForSeconds(pauseGreetingTime);
            _avatar.Animator.SetTrigger("Wave");
            yield return new WaitForSeconds(4f);            
            _avatar.Animator.ResetTrigger("Wave");            
            pauseGreetingTime = Random.Range(minTimeBetweenGreetings, maxTimeBetweenGreetings);
        }
    }

    private IEnumerator Clap()
    {
        while(clapOn)
        {            
            yield return new WaitForSeconds(pauseClapTime);
            _avatar.Animator.SetTrigger("Clap");
            yield return new WaitForSeconds(4f);            
            _avatar.Animator.ResetTrigger("Clap");            
            pauseClapTime = Random.Range(minTimeBetweenApplauses, maxTimeBetweenApplauses);
        }
    }

    private IEnumerator Dance()
    {
        while(danceOn)
        {            
            yield return new WaitForSeconds(pauseDanceTime);
            _avatar.Animator.SetTrigger("Dance01");
            yield return new WaitForSeconds(4f);            
            _avatar.Animator.ResetTrigger("Dance01");            
            pauseDanceTime = Random.Range(minTimeBetweenDances, maxTimeBetweenDances);
        }
    }

    private void ControlWalkAnimations()
    {
        if(hasMovement)
        {
            //Debug.Log(string.Format("Velocidad: {0}", _navMeshAgent.velocity.sqrMagnitude));
            float newValueMoveY = _navMeshAgent.velocity.sqrMagnitude < 0.5f ? 0f : 1f;
            _avatar.Animator.SetFloat("MoveY", newValueMoveY);
        }
    }
}
