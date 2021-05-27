using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Statistique", order = 1)]
[System.Serializable]
public class Statistique : ScriptableObject
{
    [Header("Stat")]
    [SerializeField] private float vieBase = 0.0f;
    [SerializeField] private float manaBase = 0.0f;
    [SerializeField] private float vitesseBase = 0.0f;
    [SerializeField] private float attaqueBase = 0.0f;
    [SerializeField] private float defenceBase = 0.0f;
    [SerializeField] private float attaqueBaseSpecial = 0.0f;
    [SerializeField] private float defenceBaseSpecial = 0.0f;

    [Header("Modifier")]
    [SerializeField] private float niveaux = 1.0f;
    [SerializeField] private float experience = 0.0f;
    [SerializeField] private float vie = 0.0f;
    [SerializeField] private float mana = 0.0f;
    [Header("Exp")]
    [SerializeField] private float expBaseLevelUp = 0.0f;
    [SerializeField] private float levelUpExponentielle = 0.0f;
    [Header("Bonus")]
    [SerializeField] private Types[] characterType = null;
    [SerializeField] private float vieBaseBonus = 0.0f;
    [SerializeField] private float manaBaseBonus = 0.0f;
    private float vitesseBaseBonus = 0.0f;
    private float attaqueBaseBonus = 0.0f;
    private float defenceBaseBonus = 0.0f;
    private float attaqueBaseSpecialBonus = 0.0f;
    private float defenceBaseSpecialBonus = 0.0f;

    public enum Types
    {
        Normal,
        Feu,
        Eau,
        Plante,
        Psy,
        Combat,
        Tenebre,
        ALL
    }

    #region GetterSetter
    public float VieBase { get { return vieBase; } }
    public float ManaBase { get { return manaBase; } }
    public float VitesseBase { get { return vitesseBase; } }
    public float AttaqueBase { get { return attaqueBase; } }
    public float DefenceBase { get { return defenceBase; } }
    public float AttaqueBaseSpecial { get { return attaqueBaseSpecial; } }
    public float DefenceBaseSpecial { get { return defenceBaseSpecial; } }

    /*Calcule selon le niveaux a faire*/
    public float VieMax { get { return vieBase + vieBaseBonus; } }
    public float ManaMax { get { return manaBase + manaBaseBonus; } }
    public float VitesseMax { get { return vitesseBase + vitesseBaseBonus; } }
    public float AttaqueMax { get { return attaqueBase + attaqueBaseBonus; } }
    public float DefenceMax { get { return defenceBase + defenceBaseBonus; } }
    public float AttaqueMaxSpecial { get { return attaqueBaseSpecial + attaqueBaseSpecialBonus; } }
    public float DefenceMaxSpecial { get { return defenceBaseSpecial + defenceBaseSpecialBonus; } }
    public float VieBaseBonus { set { vieBaseBonus = value; } get { return vieBaseBonus; } }
    public float ManaBaseBonus { set { manaBaseBonus = value; } get { return manaBaseBonus; } }
    public float VitesseBaseBonus { set { vitesseBaseBonus = value; } get { return vitesseBaseBonus; } }
    public float AttaqueBaseBonus { set { attaqueBaseBonus = value; } get { return attaqueBaseBonus; } }
    public float DefenceBaseBonus { set { defenceBaseBonus = value; } get { return defenceBaseBonus; } }
    public float AttaqueBaseSpecialBonus { set { attaqueBaseSpecialBonus = value; } get { return attaqueBaseSpecialBonus; } }
    public float DefenceBaseSpecialBonus { set { defenceBaseSpecialBonus = value; } get { return defenceBaseSpecialBonus; } }

    public float Niveaux { set { niveaux = value; } get { return niveaux; } }
    public float Experience { set { experience = value; } get { return experience; } }
    public float Vie { set { vie = value; } get { return vie; } }
    public float Mana { set { mana = value; } get { return mana; } }
    public float ExpBaseLevelUp { get { return expBaseLevelUp; } }
    public float LevelUpExponentielle { get { return levelUpExponentielle; } }
    public Types[] CharacterType { set { characterType = value; } get { return characterType; } }
    #endregion
}
