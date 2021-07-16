using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapsDelay : Traps
{
    [SerializeField] private Animation animation;
    [SerializeField] private float firstDelay;
    [SerializeField] private float delay;
    [SerializeField] private string showName;
    [SerializeField] private string hideName;

    private void Start() 
    {
        StartCoroutine(WaitTrapsDelay());
    }

    IEnumerator WaitTrapsDelay()
    {
        yield return new WaitForSeconds(firstDelay);
        while(true)
        {            
            animation.Play(showName);
            yield return new WaitForSeconds(delay);
            animation.Play(hideName);
            yield return new WaitForSeconds(delay);
        }
    }

}
