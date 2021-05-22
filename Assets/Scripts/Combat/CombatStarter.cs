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

    protected virtual void Start(){}
    protected virtual void Update(){}
}
