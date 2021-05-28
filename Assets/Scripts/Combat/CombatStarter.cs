using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStarter : MonoBehaviour
{
    [Header("Statistique")]
    [SerializeField] protected Statistique statistique = null;
    [Header("Combat")]
    [SerializeField] private bool isFighting = false;

    #region GetterSetter
    public Statistique Stat { get { return statistique; } }

    public bool IsFighting { get { return isFighting; } set { isFighting = value; } }
    #endregion

    protected virtual void Start() { }
    protected virtual void Update() { }
}
