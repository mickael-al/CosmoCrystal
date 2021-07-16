using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteSwitch : MonoBehaviour,SwitchChangeListener
{
    [SerializeField] private bool inverted = false;
    [SerializeField] private Animator animator = null;

    public void OnSwitchChange(bool value,Switch interupteur)
    {  
        bool state = inverted ? !value : value;
        if(state)
        {
            animator.SetTrigger("Open");
        }
        else
        {
            animator.SetTrigger("Close");
        }
    }
}
