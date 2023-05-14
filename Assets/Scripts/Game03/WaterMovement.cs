using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour
{
    [SerializeField] private float minPosZ = 0.00780f;
    [SerializeField] private float maxPosZ = 0.00855f;

    [SerializeField] private float movementSpeed = 0.001f;

    private float initialCorrection = 0.00002f;
    private int temporalVariation = 1;

    
    // Start is called before the first frame update
    void Start()
    {
        float initialPositionZ = Random.Range(minPosZ + initialCorrection, maxPosZ - initialCorrection);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y,
            initialPositionZ);
    }

    // Update is called once per frame
    void Update()
    {
        MoveWater();
    }

    private void MoveWater()
    {        
        
        transform.Translate(Vector3.up * (Time.fixedDeltaTime * movementSpeed) * temporalVariation, Space.World);
        
        float currentPositionZ = transform.localPosition.z;
        if(currentPositionZ >= maxPosZ)
        {
            temporalVariation = -1;
        }
        if(currentPositionZ <= minPosZ)
        {
            temporalVariation = 1;
        }
    }
}
