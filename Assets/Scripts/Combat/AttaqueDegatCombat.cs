using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttaqueDegatCombat : MonoBehaviour
{
    private Attaque lanceurAttaque;
    private Statistique lanceurStat;
    private float pourcentageReussite;
    private float activeTime;
    private Collider col = null;
    private ParticleSystem ps = null;

    private void Start() {
        col = GetComponent<Collider>();
        ps = GetComponent<ParticleSystem>();
        StartCoroutine(waitDesactive());
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.GetComponent<StyleCombat>() != null)
        {
            if(other.GetComponent<StyleCombat>().statistique.name != lanceurStat.name)
            {
                ps.Play();    
            }
        }
    }
    
    IEnumerator waitDesactive()
    {
        yield return new WaitForSeconds(activeTime);
        col.enabled = false;
    }

    #region GetterSetter
    public Attaque LanceurAttaque { get { return lanceurAttaque; } set { lanceurAttaque = value; } }
    public Statistique LanceurStat { get { return lanceurStat; } set { lanceurStat = value; } }
    public float PourcentageReussite { get { return pourcentageReussite; } set { pourcentageReussite = value; } }
    public float ActiveTime { get { return activeTime; } set { activeTime = value; } }
    #endregion
}
