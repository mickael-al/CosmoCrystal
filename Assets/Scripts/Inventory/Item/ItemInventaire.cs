using UnityEngine;
[System.Serializable]
public class ItemInventaire
{
    private Item item = null;
    [SerializeField] private string resourcesName = "";
    [SerializeField] private int nbItem = 0;
    [SerializeField] private int numeroPosInventaire = -1;

    public ItemInventaire() { }
    public ItemInventaire(Item it, int nombre)
    {
        Item = it;
        nbItem = nombre;
    }
    #region GetterSetter
    public Item Item
    {
        get 
        {
            if(item == null)
            {
                item = Resources.Load("item/"+resourcesName) as Item;
            }
            return item; 
        }
        set
        {
            item = value;
            resourcesName = item.name;
        }
    }

    public int NbItem
    {
        get { return nbItem; }
        set
        {
            nbItem = Mathf.Clamp(value, 0, item != null ? item.MaxStack : 0);
        }
    }

    public int NumeroPosInventaire { get { return numeroPosInventaire; } set{numeroPosInventaire=value;} }
    public string ResourcesName { get { return resourcesName; } }

    #endregion
}

