using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSave : MonoBehaviour
{
    [SerializeField] private List<GameObject> allObjectSaveLoad = new List<GameObject>();
    private string keyRandom = "";

    private void Awake() {
        GenerateKey();
    }

    public void GenerateKey()
    {
        keyRandom = SceneManager.GetActiveScene().name;
    }

    public void SaveAll()
    {
        for(int i = 0 ; i < allObjectSaveLoad.Count;i++)
        {
            allObjectSaveLoad[i].GetComponent<I_Save>().Save(keyRandom+""+i);
        }
    }

    public void LoadAll()
    {
        for(int i = 0 ; i < allObjectSaveLoad.Count;i++)
        {
            allObjectSaveLoad[i].GetComponent<I_Save>().Load(keyRandom+""+i);
        }
    }
}
