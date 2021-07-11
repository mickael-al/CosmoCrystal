using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SwitchState //ta rien vue
{
    [SerializeField] public bool state = false;
}
public abstract class Switch : MonoBehaviour, I_Save
{
    protected SwitchState switchState = new SwitchState();

    public virtual void Load(string s)
    {
        bool exist;
        JsonUtility.FromJsonOverwrite(JSONArchiver.LoadJsonsFile(JSONArchiver.JSONPath, s, out exist), this.switchState);
        if(!exist)
        {
            this.switchState.state = false;
        }
    }

    public virtual void Save(string s)
    {
        JSONArchiver.SaveJSONsFile(JSONArchiver.JSONPath, s, JsonUtility.ToJson(this.switchState));
    }
}
