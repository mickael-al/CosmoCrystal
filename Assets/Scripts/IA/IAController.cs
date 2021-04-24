using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class IAController : Character
{
    [Header("Navigation")]
    [SerializeField] protected NavMeshAgent nav = null;
    [Header("Animation")]
    [SerializeField] protected Animator animator = null;
    private float lerpSpeed = 0.0f;

    public bool Dead{
        set{
            if(value)
            {
                nav.isStopped = true;
                nav.speed = 0.0f;
            }
            base.isDead = value;
        }
    }
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        nav.speed = walkSpeed;
    }

    protected override void Update()
    {
        base.Update();
        lerpSpeed = Mathf.Lerp(lerpSpeed,nav.velocity.normalized.magnitude,Time.deltaTime * 2.0f);
        animator.SetFloat("Speed",lerpSpeed);
    }
}
