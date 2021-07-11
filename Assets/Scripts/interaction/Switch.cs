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
    [SerializeField] protected List<GameObject> listeners;
    protected SwitchState switchState = new SwitchState();

    protected virtual void Start()
    {
        foreach (GameObject go in this.listeners)
        {
            if (go.GetComponent<SwitchChangeListener>() == null)
            {
                throw new System.InvalidOperationException("les gameObjects de cette list doivent implémenté SwicthChangeListener");
            }
        }        
    }

    public virtual void setState(bool s)
    {
        if(this.switchState.state != s)
        {
            foreach (GameObject go in this.listeners)
            {
                go.GetComponent<SwitchChangeListener>().OnSwitchChange(s);
            }
        }
        this.switchState.state = s;
    }

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
