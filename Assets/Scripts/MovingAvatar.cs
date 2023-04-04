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
    private float pauseTime;
    private bool inWayPoint;

    private bool hasMovement = false;

    [SerializeField] private Transform [] wayPoints;
    [SerializeField][Range(0.5f, 10f)] private float minStopDuration = 0.5f;
    [SerializeField][Range(10.5f, 30f)] private float maxStopDuration = 15f;
    

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
    }

    // Update is called once per frame
    void Update()
    {
        if(hasMovement)
        {
            if(!inWayPoint && _navMeshAgent.remainingDistance < _navMeshAgent.stoppingDistance)
            {
                inWayPoint = true;    
                  
                pauseTime = Random.Range(minStopDuration, maxStopDuration);
                currentWayPointIndex = Random.Range(0, wayPoints.Length - 1) % wayPoints.Length;
            
                //Debug.Log(string.Format("Tiempo de espera: {0}\nPróximo way point: {1}", pauseTime, currentWayPointIndex));
                StartCoroutine("NextMove");
            }
        }
        
    }

    private void LateUpdate() {
        ControlAnimations();
    }

    private IEnumerator NextMove()
    {        
        yield return new WaitForSeconds(pauseTime);
               
        _navMeshAgent.SetDestination(wayPoints[currentWayPointIndex].position);
        inWayPoint = false;                
    }

    private void ControlAnimations()
    {
        if(hasMovement)
        {
            //Debug.Log(string.Format("Velocidad: {0}", _navMeshAgent.velocity.sqrMagnitude));
            float newValueMoveY = _navMeshAgent.velocity.sqrMagnitude < 0.5f ? 0f : 1f;
            _avatar.Animator.SetFloat("MoveY", newValueMoveY);
        }
    }
}
