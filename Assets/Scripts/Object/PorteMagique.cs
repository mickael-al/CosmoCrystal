using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorteMagique : Porte,SwitchChangeListener
{
    public override void Interact(Character character)
    {       
        if(useState && locked.locked)
        {
            if(!interactState)
            {
                interactState = true;
                base.Interact(character);
                DialogueManager.Instance.StartDialogue(dialogueNotKey);
                return;
            }
            if(DialogueManager.Instance.DisplayNextSentence())
            {
                DialogueManager.Instance.EndDialogue();
                interactState = false;
            }
        }
    }

    public void OnSwitchChange(bool value,Switch interupteur)
    {
        if(!locked.locked)
        {
            locked.locked = value;
            if(value)
            {
                animatorPorte.SetTrigger("Open");
            }
            return;
        }        
    }
}
