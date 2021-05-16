using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Traps : MonoBehaviour
{
    [Range(0.0f,1.0f)] [SerializeField] protected float degatPourcentage = 0.0f;
    [SerializeField] protected float degatRate = 0.0f;
    protected float lastDegatRate = 0.0f;
    protected virtual void OnTriggerStay(Collider other) {
        if(other.tag == "Player")     
        {
            if(Time.time-lastDegatRate > degatRate)
            {
                lastDegatRate = Time.time;
                other.GetComponent<PlayerStarter>().TakeExternalDamage(degatPourcentage*other.GetComponent<PlayerStarter>().Stat.VieBase,0.1f,0.1f,0.3f);
            }
        }
    }
}
