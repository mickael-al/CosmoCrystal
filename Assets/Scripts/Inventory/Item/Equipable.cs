using UnityEngine;
[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item/Equipable", order = 1)]
[System.Serializable]
public class Equipable : Item
{
    [SerializeField] private EquipementType equipementType = EquipementType.Casque;
    [SerializeField] private GameObject prefabPlayerEquipement = null;
    #region GetterSetter
    public override CaseTypeInventaire typeInventaire { get{ return CaseTypeInventaire.ObjEquipable;}}
    #endregion 
    public enum EquipementType
    {
        Casque,
        Arme,
        Dos,
        jambes,
        Accessoires
    }
}