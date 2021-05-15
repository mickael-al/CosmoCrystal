using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Attaque", order = 1)]
[System.Serializable]
public class Attaque : ScriptableObject
{
    [Header("Attaque")]
    [SerializeField] private string nom = "";
    [SerializeField] private TypesAttaques type = TypesAttaques.physique;
    [SerializeField] private float mana = 0.0f;
    [SerializeField] private float degat = 0.0f;
    [SerializeField] private int dureeTourAttaque = 1;

    #region GetterSetter

    #endregion
    public enum TypesAttaques
    {
        physique,
        Special
    }
}