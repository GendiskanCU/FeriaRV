using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    private bool locked;
    private MeshRenderer _meshRenderer;

    [SerializeField] private Material materialUnlocked;
    [SerializeField] private Material materialLocked;

    
    private void Start() {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.material = materialUnlocked;
    }
    
    private void OnTriggerEnter(Collider other) {        
        if(other.gameObject.tag == "Dedo" && !locked)
        {
            Lock();
            GameObject.Find("GameBoard").GetComponent<GameBoard>().GameBegins();            
        }
    }

    public void Lock()
    {
        locked = true;
        _meshRenderer.material = materialLocked;
    }

    public void Unlock()
    {
        locked = false;
        _meshRenderer.material = materialUnlocked;
    }
}
