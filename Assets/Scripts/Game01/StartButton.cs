using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    private bool locked;
    private MeshRenderer _meshRenderer;
    private Vector3 unlockedPosition;
    
    [SerializeField] private Material materialUnlocked;
    [SerializeField] private Material materialLocked;

    
    private void Start() {
        unlockedPosition = transform.localPosition;
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.material = materialUnlocked;
    }
    
    private void OnTriggerEnter(Collider other) {        
        if(other.gameObject.tag == "ButtonsPusser" && !locked)
        {
            Lock();
            GameObject.Find("GameBoard").GetComponent<GameBoard>().GameBegins();            
        }
    }

    public void Lock()
    {
        transform.localPosition = unlockedPosition + new Vector3(0.3f, 0, 0);        
        locked = true;
        _meshRenderer.material = materialLocked;
    }

    public void Unlock()
    {
        transform.localPosition = unlockedPosition;
        locked = false;
        _meshRenderer.material = materialUnlocked;
    }
}
