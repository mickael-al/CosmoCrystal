using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSave : MonoBehaviour
{
    [SerializeField] private List<GameObject> allObjectSaveLoad = new List<GameObject>();
    [SerializeField] private string keyRandom = "";
    private void Awake() {
        keyRandom = SceneManager.GetActiveScene().name;
    }
    public void SaveAll()
    {
        Debug.Log("SaveScene");
        for(int i = 0 ; i < allObjectSaveLoad.Count;i++)
        {
            allObjectSaveLoad[i].GetComponent<I_Save>().Save(keyRandom+""+i);
        }
    }

    public void LoadAll()
    {
        Debug.Log("LoadSave");
        for(int i = 0 ; i < allObjectSaveLoad.Count;i++)
        {
            allObjectSaveLoad[i].GetComponent<I_Save>().Load(keyRandom+""+i);
        }
    }
}
