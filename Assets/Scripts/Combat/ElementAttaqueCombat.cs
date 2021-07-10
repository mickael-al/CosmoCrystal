using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ElementAttaqueCombat : MonoBehaviour
{
    private Attaque attaque = null;
    private CombatManager cm = null;
    [SerializeField] private RawImage image = null;
    [SerializeField] private TextMeshProUGUI textNom = null;
    [SerializeField] private TextMeshProUGUI text = null;

    #region GetterSetter
    public Attaque Attacks
    {
        get { return attaque; }
        set
        {
            attaque = value;
            if (attaque != null)
            {
                image.texture = attaque.Icon.texture;
                textNom.text = attaque.Nom;
                text.text = "ATK " + attaque.Degat + (attaque.Mana > 0 ? " MP " + attaque.Mana : "");
            }
        }
    }
    public CombatManager Cm { get { return cm; } set { cm = value; } }
    #endregion

    public void Use()
    {
        Cm.AttaquePlayerChoix(attaque);
    }

    public void MajInfo()
    {
        Cm.MajInfo(attaque);
    }
}
