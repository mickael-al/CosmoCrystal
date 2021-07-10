using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AttaqueClassListSave
{
    public List<AttaqueSave> attaqueList = new List<AttaqueSave>();
}

public class CombatStarter : MonoBehaviour
{
    [Header("Statistique")]
    [SerializeField] protected Statistique statistique = null;

    [Header("Combat")]
    [SerializeField] protected GameObject spawnPrefab = null;
    [SerializeField] protected List<CombatStarter> alli = null;
    [SerializeField] protected AttaqueClassListSave attaqueClassListSave = new AttaqueClassListSave();
    [SerializeField] private bool isFighting = false;

    #region GetterSetter
    public Statistique Stat { get { return statistique; } }
    public List<AttaqueSave> AttaquesList { get { return attaqueClassListSave.attaqueList; } }
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
