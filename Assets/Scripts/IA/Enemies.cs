using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

    [System.Serializable]
    public class RandombeetweenTwoValue
    {
        [SerializeField] private float min = 0.0f;
        [SerializeField] private float max = 0.0f;
        public float lastRandom;
        public float random()
        {
            lastRandom = Random.Range(min,max);
            return lastRandom;
        } 
    }
public class Enemies : IAController
{
    [Header("IA Mouvement")]    
    [SerializeField] private float rayonMoveSize = 3.0f;    
    [SerializeField] private RandombeetweenTwoValue waitTime = null;

    [Header("Chasse")]
    [SerializeField] private float distanceChasse = 6.0f;
    private float varDistChasse = 0.0f;

    [Header("Player")]
    [SerializeField] private GameObject playerObj = null;
    private NavMeshHit myNavHit;

    private Vector3 targetPoint = Vector3.zero;    
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        targetPoint = transform.position;
        playerObj = GameObject.FindWithTag("Player");
        varDistChasse = distanceChasse;
    }

    protected override void Update()
    {
        base.Update();
        if(!base.isDead)
        {
            Move();
        }
    }

    public virtual void Move()
    {
        if(waitTime.lastRandom < 0.0f)
        {            
            waitTime.random();
            targetPoint = transform.position;
            targetPoint.x = Random.Range(-1.0f,1.0f) * rayonMoveSize + targetPoint.x;
            targetPoint.z = Random.Range(-1.0f,1.0f) * rayonMoveSize + targetPoint.z;
        
            if(NavMesh.SamplePosition(targetPoint, out myNavHit, rayonMoveSize+1.0f , NavMesh.AllAreas))
            {
                targetPoint = myNavHit.position;
            }
            
            nav.SetDestination(targetPoint);
        }                
        if(Vector3.Distance(playerObj.transform.position,transform.position) < varDistChasse)
        {   
            nav.SetDestination(playerObj.transform.position);
            nav.speed = base.runSpeed;
            varDistChasse = distanceChasse * 1.5f;
        }
        else{
            varDistChasse = distanceChasse;
            nav.speed = base.walkSpeed;
            waitTime.lastRandom -= Time.deltaTime;
        }
    }

    private void OnDrawGizmos()
    {
        //Gizmos.DrawSphere(targetPoint, 1.0f);
    }
}
