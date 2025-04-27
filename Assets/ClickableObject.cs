using System;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Outline))]
public class ClickableObject : MonoBehaviour
{
    public UnityEvent clicked = new UnityEvent();
    
    private Outline outline;
    
    void Awake()
    {
        outline = GetComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineHidden;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log(name + ": Clicked");
        clicked.Invoke();
    }

    private void OnMouseEnter()
    {
        outline.OutlineMode = Outline.Mode.OutlineAll;
    }

    private void OnMouseExit()
    {
        outline.OutlineMode = Outline.Mode.OutlineHidden;
    }
}
