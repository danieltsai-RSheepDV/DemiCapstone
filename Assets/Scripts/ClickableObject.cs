using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Outline))]
public class ClickableObject : MonoBehaviour
{
    public static ClickableObject instance;
    
    public UnityEvent clicked = new UnityEvent();
    
    private Outline outline;
    
    void Awake()
    {
        outline = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        instance = this;
    }

    private void OnMouseEnter()
    {
        outline.OutlineWidth = 2f;
    }

    private void OnMouseExit()
    {
        outline.OutlineWidth = 0f;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<SproutController>())
        {
            Debug.Log(other.gameObject.name);
            if (instance == this)
            {
                clicked.Invoke();
                instance = null;
                enabled = false;
            }
        }
    }
}
