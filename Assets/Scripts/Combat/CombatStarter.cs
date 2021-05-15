using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStarter : MonoBehaviour
{
    [Header("Statistique")]
    [SerializeField] protected Statistique statistique = null;

    #region GetterSetter
    public Statistique Stat
    {
        get{
            return statistique;
        }
    }
    #endregion

    public virtual void Start(){}
    public virtual void Update(){}
}
