using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemSauvegarde : Interactable
{
    public override void StartInteract()
    {
        base.StartInteract();
    }
    public override void Interact(Character character)
    {
        if (useState)
        {
            if (!interactState)
            {
                interactState = true;
                base.Interact(character);
                UISave.Instance.StartSaveMenu();
                return;
            }
            else
            {
                base.Interact(character);
                UISave.Instance.StartSaveMenu();
            }
        }
    }
    public override void StopInteract()
    {
        if (interactState && useState)
        {
            UISave.Instance.EndSaveMenu();
            interactState = false;
        }
        base.StopInteract();
    }

    public override void ChangeInteract()
    {
        base.ChangeInteract();
        if (interactState && useState)
        {
            UISave.Instance.EndSaveMenu();
            interactState = false;
        }
    }

    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
    }
}
