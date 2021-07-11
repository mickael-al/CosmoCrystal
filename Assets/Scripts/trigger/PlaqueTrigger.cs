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

    private void Start()
    {
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
        Material m = GetComponentInChildren<SkinnedMeshRenderer>().material;
        Color c = m.GetColor("_EmissionColor");
        c.r = 1.0f;
        m.SetColor("_EmissionColor", c);
        if((other.tag == "Player" && this.triggerPlayer) || (other.tag == "MovableObject" && this.triggerMovableObjects))
        {
            this.setState(true);
        }
    }

    public void setState(bool s)
    {
        
        if(this.state != s)
        {
            foreach (GameObject go in this.listeners)
            {
                go.GetComponent<SwitchChangeListener>().OnSwitchChange(s);
            }
        }
        this.state = s;
    }

    public override void OnAfterLoad()
    {
        foreach (GameObject go in this.listeners)
        {
            go.GetComponent<SwitchChangeListener>().OnSwitchChange(this.state);
        }
    }

    public override void OnBeforeSave()
    {
        
    }
}
