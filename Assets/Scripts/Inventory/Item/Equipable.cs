using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EquipementObjectPlacer
{
    public GameObject prefabPlayerEquipement;
    public int indiceBody;
    public Vector3 posObj;
    public Vector3 eulerObj;
}

[System.Serializable]
public class BonusMalus
{
    public float statModifier;
    public StatTypes statTypes;
}

public enum StatTypes
{
        Vie,
        Mana,
        AtkSpe,
        AtkPhys,
        DefSpe,
        DefPhys,
        Vitt
}

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item/Equipable", order = 1)]
[System.Serializable]
public class Equipable : Item
{
    [SerializeField] private EquipementType equipementType = EquipementType.Casque;
    [SerializeField] private List<EquipementObjectPlacer> playerEquipement = null;
    [SerializeField] private List<BonusMalus> bonusMalusStat = null;
    #region GetterSetter
    public override CaseTypeInventaire typeInventaire { get { return CaseTypeInventaire.ObjEquipable; } }
    public List<EquipementObjectPlacer> PlayerEquipement { get { return playerEquipement; } }
    public List<BonusMalus> BonusMalusStat { get { return bonusMalusStat; } }
    public EquipementType EquipementTypeObjet { get { return equipementType; } }
    #endregion 
    public enum EquipementType
    {
        Casque,
        Arme,
        Chest,
        jambes,
        Accessoires
    }
}