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

    [SerializeField] private bool inWayPoint;

    [SerializeField] private Transform [] wayPoints;
    [SerializeField][Range(0.5f, 10f)] private float minStopDuration = 0.5f;
    [SerializeField][Range(10.5f, 30f)] private float maxStopDuration = 15f;
    

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _avatar = GetComponent<AvatarCustomization>();
        currentWayPointIndex = 0;
        _navMeshAgent.SetDestination(wayPoints[currentWayPointIndex].position);
        _avatar.Animator.SetFloat("MoveY", 1f);
        Debug.Log(_avatar.Animator.GetFloat("MoveY"));
    }

    // Update is called once per frame
    void Update()
    {
        if(!inWayPoint && _navMeshAgent.remainingDistance < _navMeshAgent.stoppingDistance)
        {
            inWayPoint = true;            
            pauseTime = Random.Range(minStopDuration, maxStopDuration);
            currentWayPointIndex = Random.Range(0, wayPoints.Length - 1) % wayPoints.Length;
            
            Debug.Log(string.Format("Tiempo de espera: {0}\nPróximo way point: {1}", pauseTime, currentWayPointIndex));
            StartCoroutine("NextMove");
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
        float newValueMoveY = inWayPoint ? 0f : 1f;
        _avatar.Animator.SetFloat("MoveY", newValueMoveY);
    }
}
