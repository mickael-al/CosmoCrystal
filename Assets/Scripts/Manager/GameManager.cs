using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> instantiateManager = new List<GameObject>();
    private void Awake()
    {
        if(GameObject.FindGameObjectsWithTag("GameManager").Length >= 2)
        {
            Destroy(gameObject);
            return;
        }
        else{        
            transform.parent = null;
            DontDestroyOnLoad(this);
        }
        foreach(GameObject obj in instantiateManager)
        {
            DontDestroyOnLoad(Instantiate(obj,Vector3.zero,Quaternion.identity));
        }
    }

}
