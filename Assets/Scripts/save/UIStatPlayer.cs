using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIStatPlayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textVie = null;
    [SerializeField] private TextMeshProUGUI textMana = null;
    private PlayerStarter ps = null;
    private float lastVie;
    private float lastMana;
    private bool changement = false;
    
    void Start()
    {
        ps = GameObject.FindWithTag("Player").GetComponent<PlayerStarter>();
        textVie.text = ps.Stat.Vie.ToString("00") + "/" + ps.Stat.VieMax;
        textMana.text = ps.Stat.Mana.ToString("00") + "/" + ps.Stat.ManaMax;
        lastVie = ps.Stat.Vie;
        lastMana = ps.Stat.Mana;
    }

    public void MajValue()
    {
        StartCoroutine(AffichageMaj());
    }

    IEnumerator AffichageMaj()
    {
        changement = true;
        yield return null;        
        yield return null;
        changement = false;
        while((lastVie != ps.Stat.Vie || lastMana != ps.Stat.Mana) && !changement)
        {        
            if(lastVie > ps.Stat.Vie){lastVie--;}
            if(lastVie < ps.Stat.Vie){lastVie++;}
            if(lastMana > ps.Stat.Mana){lastMana--;}
            if(lastMana < ps.Stat.Mana){lastMana++;}
            textVie.text = lastVie.ToString("00") + "/" + ps.Stat.VieBase;
            textMana.text = lastMana.ToString("00") + "/" + ps.Stat.ManaBase;
            yield return null;
        }
    }

}
