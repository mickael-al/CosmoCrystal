using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSave : MonoBehaviour
{
    [SerializeField] private List<I_Save> allObjectSaveLoad = new List<I_Save>();

    public void SaveAll()
    {
        foreach(I_Save save in allObjectSaveLoad)
        {
            save.Save();
        }
    }

    public void LoadAll()
    {
        foreach(I_Save load in allObjectSaveLoad)
        {
            load.Load();
        }
    }
}
