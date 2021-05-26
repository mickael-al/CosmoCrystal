using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item/Special", order = 1)]
[System.Serializable]
public class SpecialItem : Item
{
    [SerializeField] private bool destroyOnTake = true;
    #region GetterSetter
    public bool DestroyOnTake { get { return destroyOnTake; } }
    #endregion

}
