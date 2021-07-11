using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaqueTrigger : Switch
{
    [SerializeField]
    private List<GameObject> listeners;

    [SerializeField]
    private bool triggerPlayer;

    [SerializeField]
    private bool triggerMovableObjects;
    private Material mat = null;
    private Color baseColor = Color.white;
    private List<GameObject> ObjectInPlaque = new List<GameObject>();
    private void Start()
    {
        mat = GetComponentInChildren<SkinnedMeshRenderer>().material;
        baseColor = mat.GetColor("_EmissionColor");
        foreach (GameObject go in this.listeners)
        {
            if (go.GetComponent<SwitchChangeListener>() == null)
            {
                throw new System.InvalidOperationException("les gameObjects de cette list doivent implémenté SwicthChangeListener");
            }
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        Color c = baseColor;
        if((other.tag == "Player" && this.triggerPlayer) || (other.tag == "MovableObject" && this.triggerMovableObjects))
        {        
            c *= 2.5f;      
            ObjectInPlaque.Add(other.gameObject);      
            mat.SetColor("_EmissionColor", c);
            this.setState(true);
        }
        else
        {
            if(ObjectInPlaque.Count == 0)
            {
                c /= 2.0f;
                mat.SetColor("_EmissionColor", c);
            }
        }        
    }

    private void OnTriggerExit(Collider other) 
    {
        if((other.tag == "Player" && this.triggerPlayer) || (other.tag == "MovableObject" && this.triggerMovableObjects))
        {
            ObjectInPlaque.Remove(other.gameObject);
        }
        if(ObjectInPlaque.Count == 0)
        {
            mat.SetColor("_EmissionColor", baseColor);
        }
    }

    public void setState(bool s)
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

    public override void Load(string s)
    {
        base.Load(s);
        foreach (GameObject go in this.listeners)
        {
            go.GetComponent<SwitchChangeListener>().OnSwitchChange(this.switchState.state);
        }
    }

    public override void Save(string s)
    {
        base.Save(s);
    }
}
