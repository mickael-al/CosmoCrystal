using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item/Item", order = 1)]
[System.Serializable]
public class Item : ScriptableObject
{
    [SerializeField] private string nom = "";
    [SerializeField] private string description = "";
    [SerializeField] private int prix = 0;
    [SerializeField] private int vente = 0;
    [SerializeField] private int maxStack = 1;
    [SerializeField] private float mass = 1.0f;
    [SerializeField] private Rarete rarete = Rarete.Normal;
    [SerializeField] private Sprite image = null;
    [SerializeField] private bool jetable = true;
    [SerializeField] private bool vendable = true;

    #region GetterSetter
    public string Nom { get { return nom; } }
    public string Description { get { return description; } }
    public int Prix { get { return prix; } }
    public int Vente { get { return vente; } }
    public float Mass { get { return mass; } }
    public int MaxStack { get { return maxStack; } }
    public Sprite SpriteIcon { get { return image; } }
    public Rarete ItemRarete { get { return rarete; } }
    public bool Vendable { get { return vendable; } }
    public bool Jetable { get { return jetable; } }
    public virtual CaseTypeInventaire typeInventaire { get{ return CaseTypeInventaire.ObjNormal;}}
    #endregion

    public enum Rarete
    {
        Normal,
        Special,
        Legendaire
    }

    public enum CaseTypeInventaire
    {
        ObjConsomable,
        ObjEquipable,
        ObjNormal
    }
}


