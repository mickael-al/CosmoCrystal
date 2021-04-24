using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private List<Interactable> interactable = new List<Interactable>();
    
    private void Start() {
        InputManager.InputJoueur.Controller.ActionPrincipale.Enable();
        InputManager.InputJoueur.Controller.ActionPrincipale.performed += ctx => Interact();  
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Interactable")
        {
            if(other.GetComponent<Interactable>())
            {
                interactable.Add(other.GetComponent<Interactable>());
                other.GetComponent<Interactable>().StartInteract();
            }
        }    
    }

    public void Interact()
    {
        Interactable inter = null;
        float distance = float.MaxValue;
        foreach(Interactable i in interactable)
        {
            if(Vector3.Distance(i.gameObject.transform.position,transform.position) < distance)
            {
                distance = Vector3.Distance(i.gameObject.transform.position,transform.position);
                inter = i;
            }
        }
        if(inter != null)
        {
            inter.Interact(this.GetComponent<Character>());
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.tag == "Interactable")
        {
            if(other.GetComponent<Interactable>())
            {
                other.GetComponent<Interactable>().StopInteract();
                interactable.Remove(other.GetComponent<Interactable>());
            }
        }  
    }
}
