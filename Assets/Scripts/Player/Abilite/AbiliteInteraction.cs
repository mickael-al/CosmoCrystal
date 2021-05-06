using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbiliteInteraction : MonoBehaviour
{
    [SerializeField] private string tagInteract = "";

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag(tagInteract))
        {
            Debug.Log(other);
            other.GetComponent<InteractableAbilite>().Interact();
        }
    }
}
