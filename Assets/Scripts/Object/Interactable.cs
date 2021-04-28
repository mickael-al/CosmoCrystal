using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Header("Animator")]
    [SerializeField] private Animator animator = null;
    protected bool useState = false;
    protected bool interactState = false;
    #region GetterSetter
    public bool InteractState
    {
        get{
            return interactState;
        }
    }
    #endregion

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
        if(useState)
        {
            animator.SetTrigger("Stop");
            useState = false;        
        }
    }

    public virtual void ChangeInteract()
    {
        
    }

    protected virtual void Start()
    {
        
    }
    protected virtual void Update()
    {
        
    }
}
