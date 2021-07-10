using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Attaque/Attaque", order = 1)]
[System.Serializable]
public class Attaque : ScriptableObject
{
    [Header("Attaque")]
    [SerializeField] private string nom = "";
    [SerializeField] private TypesAttaques typeAttaque = TypesAttaques.Physique;
    [SerializeField] private CiblesAttaque ciblesAttaque = CiblesAttaque.Seul;
    [SerializeField] private Statistique.Types typeDegat = Statistique.Types.Normal;
    [SerializeField] private float mana = 0.0f;
    [SerializeField] private float degat = 0.0f;
    [SerializeField] private AttaqueRendu attaqueRendu = null;
    [SerializeField] private Sprite icon = null;

    #region GetterSetter

    public string Nom { get { return nom; } }
    public TypesAttaques TypeAttaque { get { return typeAttaque; } }
    public Statistique.Types TypeDegat { get { return typeDegat; } }
    public Sprite Icon { get { return icon; } }
    public float Mana { get { return mana; } }
    public float Degat { get { return degat; } }
    public AttaqueRendu AttaqueRendu { get { return attaqueRendu; } }

    public CiblesAttaque CiblesAttacks { get { return ciblesAttaque; } set{ ciblesAttaque = value; } }
    #endregion

    public enum TypesAttaques
    {
        Physique,
        Special
    }

    public enum CiblesAttaque
    {
        Seul,
        Multiples
    }
}