using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StyleCombat : MonoBehaviour
{
    protected Statistique stat;
    protected List<AttaqueSave> attaquesList;
    protected bool canFight = false;
    protected bool endFight = false;
    protected CombatManager cm = null;
    protected Animator anim = null;
    protected virtual void Start() 
    {
        anim = GetComponentInChildren<Animator>();
    }
    public virtual IEnumerator sCombat()
    {
        while(!endFight)
        {
            yield return null;
        }
    }

    protected virtual void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "AttaqueDegat")    
        {
            //stat.Vie -= other.GetComponent<AttaqueDegatCombat>().Degat;
        }
    }

    #region GetterSetter
    public Statistique statistique { set { stat = value; } get { return stat; } }
    public List<AttaqueSave> AttaquesList { set { attaquesList = value;} get { return attaquesList; } }
    public bool CanFight { set { canFight = value; } get { return canFight; } }
    public bool EndFight { set { endFight = value; } get { return endFight; } }
    public CombatManager CM { set { cm = value; } get { return cm; } }
    public Animator Anim { set { anim = value; } get { return anim; } }
    #endregion
}
