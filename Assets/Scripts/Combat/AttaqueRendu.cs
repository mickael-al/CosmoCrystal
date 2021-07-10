using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttaqueRendu : ScriptableObject
{
    protected bool isRunning = false;
    public virtual IEnumerator Rendu(GameObject lanceur,List<GameObject> cible,Attaque att)
    {
        if (!isRunning)
        {
            isRunning = true;
            yield return null;
            isRunning = false;
        }
    }

    public virtual void Interuption()
    {
        if (!isRunning)
        {
            
        }
    }

    #region GetterSetter
    public bool IsRunning { get { return isRunning; } }
    #endregion
}
