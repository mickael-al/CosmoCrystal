using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Inventaire : MonoBehaviour
{
    [SerializeField] protected int piece = 0;
    [SerializeField] protected int maxSlotPage = 15;
    [SerializeField] protected List<ItemInventaire> itemInventaire = new List<ItemInventaire>();
    private int nbItemGlobal = -1;
    private List<int> pageCount = new List<int>();

    protected virtual void Awake() { }
    protected virtual void Start() 
    {
        pageCount = new List<int>(new int[Enum.GetValues(typeof(Item.CaseTypeInventaire)).Length]);
    }

    public int calcItemType(int indice)
    {
        if(itemInventaire.Count != nbItemGlobal)
        {
            pageCount = new List<int>(new int[Enum.GetValues(typeof(Item.CaseTypeInventaire)).Length]);
            for(int i = 0; i < itemInventaire.Count;i++)
            {
                pageCount[(int)itemInventaire[i].Item.typeInventaire]++;
            }
            nbItemGlobal = itemInventaire.Count;
        }
        return pageCount[indice];
    }
    public bool ItemExist(Item item, out List<int> indice)
    {
        List<int> indf = new List<int>();
        for (int i = 0; i < itemInventaire.Count; i++)
        {
            if (itemInventaire[i].Item.name == item.name)
            {
                indf.Add(i);
            }
        }
        indice = indf;
        return indice.Count > 0;
    }
    public virtual bool AddItem(Item item, int nombre, out int reste)
    {
        List<int> indiceFind;
        reste = nombre;
        if (ItemExist(item, out indiceFind))
        {            
            foreach (int i in indiceFind)
            {
                if (itemInventaire[i].NbItem + reste > itemInventaire[i].Item.MaxStack)
                {
                    if (itemInventaire[i].NbItem != itemInventaire[i].Item.MaxStack)
                    {
                        reste = (itemInventaire[i].NbItem + reste) - itemInventaire[i].Item.MaxStack;
                        itemInventaire[i].NbItem = itemInventaire[i].Item.MaxStack;
                    }
                }
                else
                {
                    itemInventaire[i].NbItem += reste;
                    reste = 0;
                    return true;
                }
            }
        }
        if(calcItemType((int)item.typeInventaire) >= maxSlotPage)
        {
            return false;
        }
        itemInventaire.Add(new ItemInventaire(item, reste));
        reste = 0;
        return true;
    }
}
