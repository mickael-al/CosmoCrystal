using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSauteur : Enemies
{
    [Header("Special Animation")]
    [SerializeField] private GameObject root = null;
    [SerializeField] private float syncMove = 0.0f;
    [SerializeField] private float speedMult = 1.0f;
    private Vector3 pos = Vector3.zero;

    protected override void Start()
    {
        base.Start();
        pos = root.transform.position;
    }

    private void LateUpdate() 
    {
        syncMove+= Time.deltaTime *speedMult;
        /*if(Mathf.Abs(Mathf.Sin(syncMove*Mathf.PI)) < 0.6f)
        {
            root.transform.position = pos;
        }
        else
        {
            pos = root.transform.position;
            root.transform.localPosition = Vector3.Lerp(root.transform.localPosition,Vector3.zero,Time.deltaTime * 1.0f);
        }*/
        animator.SetFloat("MoveSync",syncMove);
    }
}
