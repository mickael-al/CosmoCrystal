using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Attaque/AttaqueTours", order = 1)]

[System.Serializable]
public class AttaqueTours : Attaque
{
    [Header("AttaqueTours")]
    [SerializeField] private int dureeTourAttaque = 1;

    #region GetterSetter
    public int DureeTourAttaque {get{return dureeTourAttaque;}}

    #endregion
}