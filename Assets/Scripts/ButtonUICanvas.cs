using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUICanvas : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("DedoIndice"))
        {
            Application.Quit();
        }
    }
}
