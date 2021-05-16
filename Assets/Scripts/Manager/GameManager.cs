using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> instantiateManager = new List<GameObject>();
    [SerializeField] private GameObject playerPrefab = null;
    [SerializeField] private GameObject spawnPoint = null;
    private SceneManagerLoader sceneManagerLoader = null;
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
        GameObject playerObj = Instantiate(playerPrefab,spawnPoint.transform.position,Quaternion.identity);
        DontDestroyOnLoad(playerObj);
        foreach(GameObject obj in instantiateManager)
        {
            DontDestroyOnLoad(Instantiate(obj,Vector3.zero,Quaternion.identity));
        }
        sceneManagerLoader = GameObject.FindGameObjectWithTag("SceneManager").GetComponent<SceneManagerLoader>();
        StartCoroutine(sceneManagerLoader.TransitionFade(1.5f));
        playerObj.GetComponent<PlayerSaveManager>().LoadAll(0);
    }
}
