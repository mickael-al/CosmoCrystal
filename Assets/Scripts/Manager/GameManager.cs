using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> instantiateManager = new List<GameObject>();
    [SerializeField] private GameObject playerPrefab = null;
    [SerializeField] private GameObject spawnPoint = null;
    [SerializeField] private SceneManagerLoader sceneManagerLoader = null;
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
        DontDestroyOnLoad(Instantiate(playerPrefab,spawnPoint.transform.position,Quaternion.identity));
        foreach(GameObject obj in instantiateManager)
        {
            DontDestroyOnLoad(Instantiate(obj,Vector3.zero,Quaternion.identity));
        }
        sceneManagerLoader = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManagerLoader>();
        StartCoroutine(sceneManagerLoader.TransitionFade(1.5f));
    }

}
