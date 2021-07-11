using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Switch : MonoBehaviour, I_Save
{
    protected bool state;

    public abstract void OnAfterLoad();

    public abstract void OnBeforeSave();

    public void Load(string s)
    {
        bool exist;
        JsonUtility.FromJsonOverwrite(JSONArchiver.LoadJsonsFile(JSONArchiver.JSONPath, s, out exist), this.state);
        if(!exist)
        {
            Debug.Log("new");
            this.state = false;
        }
        Debug.Log("load");
        this.OnAfterLoad();
    }

    public void Save(string s)
    {
        this.OnBeforeSave();
        Debug.Log("saved");
        JSONArchiver.SaveJSONsFile(JSONArchiver.JSONPath, s, JsonUtility.ToJson(this.state));
    }
}
