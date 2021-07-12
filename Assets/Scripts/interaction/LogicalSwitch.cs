using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LogicalSwitch : Switch,SwitchChangeListener
{
    [SerializeField] private List<Switch> switchMap = new List<Switch>();
    [SerializeField] private bool Invert = false;
    [SerializeField] private bool OperatorOU = false;    
    private Dictionary<Switch,bool> interupteursMap = new Dictionary<Switch,bool>();
    protected override void Start()
    {
        foreach (GameObject go in base.listeners)
        {
            if (go.GetComponent<SwitchChangeListener>() == null)
            {
                throw new System.InvalidOperationException("les gameObjects de cette list doivent implémenté SwicthChangeListener");
            }
        }  
        foreach(Switch s in switchMap)
        {
            interupteursMap.Add(s,s.SwitchS.state);
        }
    }

    public void OnSwitchChange(bool value,Switch interupteur)
    {    
        interupteursMap[interupteur] = value;
        bool state = AndOperator(interupteursMap.Values.ToList()).First<bool>();
        foreach (GameObject go in base.listeners)
        {
            go.GetComponent<SwitchChangeListener>().OnSwitchChange(state,this);
        }
    }

    private List<bool> AndOperator(List<bool> list)
    {
        bool op1,op2;
        if(list.Count > 1)
        {
            op1 = list[0];
            op2 = list[1];
            list.RemoveAt(0);
            list.RemoveAt(0);
            list.Add(op1&&op2);
        }
        else
        {
            return list;
        }
        return AndOperator(list);
    }
}
