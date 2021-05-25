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

    #region GetterSetter
    public List<ItemInventaire> ItemInventaire { 
        get 
        { 
            for(int i = itemInventaire.Count-1; i >= 0;i--)
            {
                if(itemInventaire[i].Item == null)
                {
                    itemInventaire.RemoveAt(i);
                }
            }
            return itemInventaire; 
        } 
    }
    public int MaxSlotPage { get { return maxSlotPage; } }
    #endregion

    protected virtual void Awake() { }
    protected virtual void Start()
    {
        pageCount = new List<int>(new int[Enum.GetValues(typeof(Item.CaseTypeInventaire)).Length]);
    }

    public int calcItemType(int indice)
    {
        if (itemInventaire.Count != nbItemGlobal)
        {
            pageCount = new List<int>(new int[Enum.GetValues(typeof(Item.CaseTypeInventaire)).Length]);
            for (int i = 0; i < itemInventaire.Count; i++)
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
        if (calcItemType((int)item.typeInventaire) >= maxSlotPage && !item.QueteObject)
        {
            return false;
        }
        itemInventaire.Add(new ItemInventaire(item, reste));
        reste = 0;
        return true;
    }

    public virtual void Lacher(ItemInventaire ii)
    {
        if(ii.Item.Jetable)
        {
            itemInventaire.Remove(ii);        
            GameObject prefabBaseItem = Resources.Load("Item/Prefab/ItemBase") as GameObject;
            GameObject objSpawn = Instantiate(prefabBaseItem,transform.position+new Vector3(0,1.0f,0),Quaternion.identity);            
            StartCoroutine(objSpawn.GetComponent<ItemDrop>().blockRecupWait(2.5f));
            objSpawn.GetComponent<ItemDrop>().Item = ii.Item;
            objSpawn.GetComponent<ItemDrop>().NbItem = ii.NbItem;
        }
    }
}
