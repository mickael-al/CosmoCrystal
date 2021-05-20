using UnityEngine;
[System.Serializable]
public class ItemInventaire
{
    [SerializeField] private Item item = null;
    [SerializeField] private int nbItem = 0;
    [SerializeField] private int numeroPosInventaire = -1;

    public ItemInventaire() { }
    public ItemInventaire(Item it, int nombre)
    {
        Item = it;
        nombre = nbItem;
    }
    #region GetterSetter
    public Item Item
    {
        get { return item; }
        set
        {
            item = value;

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

    public int NumeroPosInventaire { get { return numeroPosInventaire; } }

    #endregion
}

