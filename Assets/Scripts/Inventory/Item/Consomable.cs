using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item/Consomable", order = 1)]
[System.Serializable]
public class Consomable : Item
{   
    #region GetterSetter
    public override CaseTypeInventaire typeInventaire { get{ return CaseTypeInventaire.ObjConsomable;}}
    #endregion 
    [SerializeField] private List<ItemEffect> itemEffect = new List<ItemEffect>();
    public void UseEffect(Character character)
    {
        foreach(ItemEffect id in itemEffect)
        {
            id.Effect(character);
        }
    }
}
