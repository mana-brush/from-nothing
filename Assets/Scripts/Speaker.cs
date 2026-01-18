using System;
using UnityEngine;

public class Speaker : MonoBehaviour
{

    private Canvas _helpCanvas;

    void Start()
    {
        _helpCanvas = gameObject.GetComponentInChildren<Canvas>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        _helpCanvas.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _helpCanvas.enabled = false;
    }
}
