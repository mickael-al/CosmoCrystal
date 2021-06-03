using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStarter : MonoBehaviour
{
    [Header("Statistique")]
    [SerializeField] protected Statistique statistique = null;
    [SerializeField] protected GameObject spawnPrefab = null;
    [SerializeField] protected List<CombatStarter> alli = null;
    [Header("Combat")]
    [SerializeField] private bool isFighting = false;

    #region GetterSetter
    public Statistique Stat { get { return statistique; } }
    public GameObject SpawnPrefab { get { return spawnPrefab; } }
    public List<CombatStarter> Alli { get { return alli; } }
    public bool IsFighting { get { return isFighting; } 
        set 
        { 
            isFighting = value; 
            foreach(CombatStarter cs in alli)
            {
                cs.isFighting = value;
            }
        } 
    }
    #endregion

    protected virtual void Start() { }
    protected virtual void Update() { }
}
