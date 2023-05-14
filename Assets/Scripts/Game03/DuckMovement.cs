using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    //[SerializeField] private float minPosY = 0.700f;
    //[SerializeField] private float maxPosY = 0.755f;
    [SerializeField] private List<Transform> wayPoints;

    //[SerializeField][Range(0.008f, 0.1f)] private float floatingSpeed = 0.05f;
    [SerializeField][Range(0.1f, 0.5f)] private float displacementSpeed = 0.2f;
    [SerializeField][Range(-25f, 25f)] private float rotationSpeed = 10f;

    [SerializeField][Range(0.3f, 1.0f)] private float timeForFloatPulse = 0.3f;
    [SerializeField][Range(0.4f, 0.8f)] private float floatForce = 0.4f;

    private float initialPositionCorrection = 0.02f;
    private int temporalFloatingVariation = 1;    
    private float distanceChangeWayPoint = 0.05f;
    private byte nextWayPoint = 0;
    private float newRotationY;

    private Rigidbody _rb;   

    
    // Start is called before the first frame update
    void Start()
    {        
        _rb = GetComponent<Rigidbody>();

        /*//Alternativa sin tener en consideración las físicas
        float initialPositionY = Random.Range(minPosY + initialPositionCorrection, maxPosY - initialPositionCorrection);
        transform.position = new Vector3(transform.position.x, initialPositionY, transform.position.z);*/
        newRotationY = Random.Range(0, 360);
        transform.rotation = Quaternion.Euler(new Vector3(-90 ,newRotationY, 0));
        StartCoroutine("Floating");
    }  
   

    private void FixedUpdate() {
        MoveDuck();
    }

    private void MoveDuck()
    {        
        /*//Alternativa de movimiento sin tener en consideración las físicas
        //Flotación
        transform.Translate(Vector3.up * (Time.fixedDeltaTime * floatingSpeed) * temporalFloatingVariation, Space.World);
        
        float currentPositionY = transform.position.y;
        if(currentPositionY >= maxPosY)
        {
            temporalFloatingVariation = -1;
        }
        if(currentPositionY <= minPosY)
        {
            temporalFloatingVariation = 1;
        }

        //Desplazamiento
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[nextWayPoint].position,
            displacementSpeed * Time.fixedDeltaTime);
        if(Vector3.Distance(transform.position, wayPoints[nextWayPoint].position) <= distanceChangeWayPoint)
            nextWayPoint++;
        if(nextWayPoint >= wayPoints.Count)
            nextWayPoint = 0;

        //Rotación
        newRotationY += rotationSpeed * Time.fixedDeltaTime;
        transform.rotation = Quaternion.Euler(new Vector3(-90 ,newRotationY, 0));        */

        //Desplazamiento
        Vector3 direction = (wayPoints[nextWayPoint].position - transform.position).normalized;
        _rb.MovePosition(transform.position + direction * displacementSpeed * Time.fixedDeltaTime);
        if(Vector3.Distance(transform.position, wayPoints[nextWayPoint].position) <= distanceChangeWayPoint)
            nextWayPoint++;
        if(nextWayPoint >= wayPoints.Count)
            nextWayPoint = 0;

        //Rotación
        newRotationY += rotationSpeed * Time.fixedDeltaTime;
        transform.rotation = Quaternion.Euler(new Vector3(-90 ,newRotationY, 0));        
    }

    private IEnumerator Floating()
    {
        while(true)
        {
            yield return new WaitForSeconds(timeForFloatPulse);
            _rb.AddForce(transform.forward * floatForce, ForceMode.Impulse);
        }
    }
}
