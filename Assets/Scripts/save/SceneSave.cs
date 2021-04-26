using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSave : MonoBehaviour
{
    [SerializeField] private List<I_Save> allObjectSaveLoad = new List<I_Save>();

    public void SaveAll()
    {
        Debug.Log("SaveScene");
        foreach(I_Save save in allObjectSaveLoad)
        {
            save.Save();
        }
    }

    public void LoadAll()
    {
        Debug.Log("LoadSave");
        foreach(I_Save load in allObjectSaveLoad)
        {
            load.Load();
        }
    }
}
