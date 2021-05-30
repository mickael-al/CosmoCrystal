﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemContainer
{
    public Item item;
    public int nb;
}

[System.Serializable]
public class Coffre : Interactable, I_Save
{
    [Header("Coffre")]
    [SerializeField] private InteractStateSave isLocked;
    [SerializeField] private List<ItemContainer> itemsSpawn = null;
    [SerializeField] private Animator animatorCoffre = null;
    [SerializeField] private bool instantiate = false;
    [SerializeField] private List<Transform> pointInstantiate = null;
    private GameObject prefabBase = null;

    public override void StartInteract()
    {
        if(isLocked.locked)
        {
            base.StartInteract();
        }
    }
    public override void Interact(Character character)
    {
        if (isLocked.locked && useState && character.GetComponent<Inventaire>())
        {
            if (!interactState)
            {
                interactState = true;
                isLocked.locked = false;
                animatorCoffre.SetTrigger("Open");
                StopInteract();

                for(int i = 0 ; i < itemsSpawn.Count;i++)
                {
                    if (instantiate)
                    {                        
                        GameObject objPrefb = Instantiate(prefabBase,pointInstantiate[pointInstantiate.Count%i].position,Quaternion.identity);
                        objPrefb.GetComponent<ItemDrop>().Item = itemsSpawn[i].item;
                        objPrefb.GetComponent<ItemDrop>().NbItem = itemsSpawn[i].nb;
                    }
                    else
                    {
                        int reste;
                        character.GetComponent<Inventaire>().AddItem(itemsSpawn[i].item, itemsSpawn[i].nb, out reste);
                    }
                }

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

    private void Awake() {
       prefabBase = Resources.Load("Item/Prefab/ItemBase") as GameObject;
    }

    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
    }

    public void Save(string s)
    {
        JSONArchiver.SaveJSONsFile(JSONArchiver.JSONPath, s, JsonUtility.ToJson(this.isLocked));
    }
    public void Load(string s)
    {
        bool state = false;
        bool lockBase = isLocked.locked;
        JsonUtility.FromJsonOverwrite(JSONArchiver.LoadJsonsFile(JSONArchiver.JSONPath, s, out state), this.isLocked);
        if (!state)
        {
            this.isLocked = new InteractStateSave();
            this.isLocked.locked = lockBase;
        }
        if (!this.isLocked.locked)
        {
            animatorCoffre.SetTrigger("Disabled");
        }
    }
}