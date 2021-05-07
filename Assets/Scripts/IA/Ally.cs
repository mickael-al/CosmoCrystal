using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : IAController
{
    [Header("Player")]
    [SerializeField] private GameObject playerObj = null;
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        playerObj = GameObject.FindWithTag("Player");
    }

    protected override void Update()
    {
        base.Update();
        if (!base.isDead)
        {
            Move();
        }
    }

    public virtual void Move()
    {

    }
}
