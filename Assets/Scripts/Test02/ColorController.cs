using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorController : MonoBehaviour
{
    [SerializeField] private Material[] wallMaterial;
    [SerializeField] private TextMeshProUGUI displayText;

    private Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        displayText.text = "";
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.name == "PlayerBall")
        {
            displayText.text = "Ouch!";
            rend.sharedMaterial = wallMaterial[0];
        }
    }

    private void OnCollisionExit(Collision other) {
        if(other.gameObject.name == "PlayerBall")
        {
            displayText.text = "";
            rend.sharedMaterial = wallMaterial[1];
        }
    }
}
