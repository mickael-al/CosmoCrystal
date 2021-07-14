using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeRespawnPoint : MonoBehaviour
{
    private GameObject spawnPoint = null;
    private void Start() {
        spawnPoint = GameObject.FindWithTag("RespawnPoint");//0.6 sol
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")    
        {
            spawnPoint.transform.position = transform.position;
        }
    }
}
