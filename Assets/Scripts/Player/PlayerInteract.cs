using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private List<Interactable> interactable = new List<Interactable>();
    private Interactable lastInteraction = null;
    private PlayerAbiliteControleur playerAbiliteControleur = null;
    private PlayerInventaire playerInventaire = null;

    #region GetterSetter
    public bool CanInteract
    {
        get{
            return interactable.Count > 0;
        }
    }

    public bool isInteract
    {
        get{
            return lastInteraction != null ? lastInteraction.InteractState : false;
        }
    }
    #endregion
    
    private void Start() {        
        playerAbiliteControleur = GetComponent<PlayerAbiliteControleur>();
        playerInventaire = GetComponent<PlayerInventaire>();
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
        if(playerAbiliteControleur.IsChoising || playerAbiliteControleur.IsUsing || playerInventaire.inInventaire) return;
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
            if(inter != lastInteraction)
            {
                if(lastInteraction != null)
                {                    
                    lastInteraction.ChangeInteract();
                }
            }
            lastInteraction = inter;
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
