using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckMovement : MonoBehaviour
{
    [SerializeField] private float minPosY = 0.700f;
    [SerializeField] private float maxPosY = 0.755f;

    [SerializeField] private float floatingSpeed = 0.05f;

    private float initialPositionCorrection = 0.02f;
    private int temporalFloatingVariation = 1;

    
    // Start is called before the first frame update
    void Start()
    {
        float initialPositionY = Random.Range(minPosY + initialPositionCorrection, maxPosY - initialPositionCorrection);
        transform.position = new Vector3(transform.position.x, initialPositionY, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        MoveDuck();
    }

    private void MoveDuck()
    {        
        
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
    }
}
