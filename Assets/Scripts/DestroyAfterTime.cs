using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float lifeTime = 3.0f;

    private float elapsedTime;
    private void Start() {
        elapsedTime = 0f;
    }

    private void Update() {
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= lifeTime)
        {
            Destroy(this.gameObject);
        }
    }
}
