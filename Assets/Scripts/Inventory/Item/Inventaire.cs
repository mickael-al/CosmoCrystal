using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventaire : MonoBehaviour
{
    public virtual bool AddItem(Item item,int nombre,out int reste)
    {
        reste=nombre;
        return false;
    }
}
