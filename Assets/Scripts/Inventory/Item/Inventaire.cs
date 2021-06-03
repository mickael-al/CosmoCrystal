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
    public List<ItemInventaire> ItemInventaire
    {
        get
        {
            for (int i = itemInventaire.Count - 1; i >= 0; i--)
            {
                if (itemInventaire[i].Item == null)
                {
                    itemInventaire.RemoveAt(i);
                }
            }
            return itemInventaire;
        }
    }
    public int MaxSlotPage { get { return maxSlotPage; } }

    public int Piece
    {
        get { return piece; }
        set
        {
            piece = Mathf.Clamp(value, 0, 99999);
        }
    }
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
        if (item is SpecialItem)
        {
            if (item.UseEffect(GetComponent<Character>(), nombre)) { }
            if (((SpecialItem)item).DestroyOnTake)
            {
                reste = 0;
                return true;
            }
        }
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
        if (ii.Item.Jetable)
        {
            itemInventaire.Remove(ii);
            GameObject prefabBaseItem = Resources.Load("Item/Prefab/ItemBase") as GameObject;
            GameObject objSpawn = Instantiate(prefabBaseItem, transform.position + new Vector3(0, 1.0f, 0), Quaternion.identity);
            StartCoroutine(objSpawn.GetComponent<ItemDrop>().blockRecupWait(2.5f));
            objSpawn.GetComponent<ItemDrop>().Item = ii.Item;
            objSpawn.GetComponent<ItemDrop>().NbItem = ii.NbItem;
        }
    }

    public virtual bool RemoveItem(Item item, int nombre = 1)
    {
        List<int> indiceFind;
        if (ItemExist(item, out indiceFind))
        {
            foreach (int i in indiceFind)
            {
                if (itemInventaire[i].NbItem - nombre > 0)
                {
                    itemInventaire[i].NbItem -= nombre;
                    return true;
                }
                else
                {
                    nombre -= itemInventaire[i].NbItem;
                    itemInventaire.Remove(itemInventaire[i]);
                    if (nombre == 0)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public virtual void EquipeModel(EquipableModel em)
    {
        if (em != null)
        {
            foreach (ItemInventaire ii in itemInventaire)
            {
                if (ii.EquipementID >= 0)
                {
                    if (ii.Item is Equipable)
                    {
                        em.AddModel(((Equipable)ii.Item).PlayerEquipement);
                    }
                }
            }
        }
    }

    public virtual void majStatBonusEquipement()
    {
        Statistique stat = GetComponent<CombatStarter>().Stat;
        stat.VieBaseBonus = 0.0f;
        stat.ManaBaseBonus = 0.0f;
        stat.VitesseBaseBonus = 0.0f;
        stat.AttaqueBaseBonus = 0.0f;
        stat.DefenceBaseBonus = 0.0f;
        stat.AttaqueBaseSpecialBonus = 0.0f;
        stat.DefenceBaseSpecialBonus = 0.0f;
        foreach (ItemInventaire ii in itemInventaire)
        {
            if (ii.EquipementID >= 0)
            {
                if (ii.Item is Equipable)
                {
                    foreach (BonusMalus bm in ((Equipable)ii.Item).BonusMalusStat)
                    {
                        if (bm.typesCibles != Statistique.Types.ALL) { break; }
                        switch (bm.statTypes)
                        {
                            case StatTypes.Vie:
                                stat.VieBaseBonus += bm.statModifier;
                                break;
                            case StatTypes.Mana:
                                stat.ManaBaseBonus += bm.statModifier;
                                break;
                            case StatTypes.Vitt:
                                stat.VitesseBaseBonus += bm.statModifier;
                                break;
                            case StatTypes.AtkPhys:
                                stat.AttaqueBaseBonus += bm.statModifier;
                                break;
                            case StatTypes.AtkSpe:
                                stat.AttaqueBaseSpecialBonus += bm.statModifier;
                                break;
                            case StatTypes.DefPhys:
                                stat.DefenceBaseBonus += bm.statModifier;
                                break;
                            case StatTypes.DefSpe:
                                stat.DefenceBaseSpecialBonus += bm.statModifier;
                                break;
                        }
                    }
                }
            }
        }
        stat.Vie = Mathf.Clamp(stat.Vie, 0, stat.VieMax);
        stat.Mana = Mathf.Clamp(stat.Mana, 0, stat.ManaMax);
    }
}
