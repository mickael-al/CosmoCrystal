using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    //[Header("Interact Settings")]
    [Header("Animator")]
    [SerializeField] private Animator animator = null;
    private bool useState = false;
    public virtual void StartInteract()
    {
        useState = true;
        animator.SetTrigger("Start");
    }
    public virtual void Interact(Character character)
    {
        if(useState)
        {
            animator.SetTrigger("Use");
        }
    }
    public virtual void StopInteract()
    {
        useState = false;
        animator.SetTrigger("Stop");
    }
    protected virtual void Start()
    {
        
    }
    protected virtual void Update()
    {
        
    }
}
