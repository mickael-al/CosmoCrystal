using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStarter : CombatStarter,InteractableAbilite
{
    public void Interact()
    {
        Debug.Log("Combat");
    }
}
