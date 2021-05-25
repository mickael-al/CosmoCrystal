using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item/Consomable", order = 1)]
[System.Serializable]
public class Consomable : Item
{   
    #region GetterSetter
    public override CaseTypeInventaire typeInventaire { get{ return CaseTypeInventaire.ObjConsomable;}}
    #endregion 
}
