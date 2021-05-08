using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiStarter : CombatStarter,InteractableAbilite
{
    public void Interact(Character owner)
    {
        GameObject.FindObjectOfType<CombatManager>().StartCombat(true,owner.gameObject,gameObject);
    }
}
