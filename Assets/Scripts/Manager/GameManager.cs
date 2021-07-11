using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> instantiateManager = new List<GameObject>();
    [SerializeField] private GameObject playerPrefab = null;
    [SerializeField] private GameObject spawnPoint = null;
    private SceneManagerLoader sceneManagerLoader = null;
    private void Awake()
    {
        GameObject[] managers = GameObject.FindGameObjectsWithTag("GameManager");
        if(managers.Length >= 2)
        {
            foreach(GameObject go in managers.Where(o => o != gameObject))
            {
                go.GetComponent<GameManager>().ChangePosSpawnPoint(spawnPoint.transform.position);
            }
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

    public void ChangePosSpawnPoint(Vector3 pos)
    {
        spawnPoint.transform.position = pos;
    }
}
