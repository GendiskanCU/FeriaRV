using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    public Color color1, color2;
    private Image _image;

    private void Start() {
        _image = GetComponent<Image>();
        _image.color = color1;
    }

    

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "DedoIndice")
        {
            _image.color = _image.color == color1 ? color2 : color1;
        }
    }
}
