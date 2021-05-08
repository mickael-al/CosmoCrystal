using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStarter : CombatStarter,InteractableAbilite,I_Save
{
    public void Interact(Character owner)
    {
        GameObject.FindObjectOfType<CombatManager>().StartCombat(false,gameObject,owner.gameObject);
    }

    public void Save(string s)
    {

    }
    public void Load(string s)
    {

    }
}
