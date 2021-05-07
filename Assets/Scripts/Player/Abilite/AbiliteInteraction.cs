using UnityEngine;

public class AbiliteInteraction : MonoBehaviour
{
    [SerializeField] private string[] tagInteract = null;

    private void OnTriggerEnter(Collider other) {
        foreach(string tagInt in tagInteract)
        {
            if(other.tag == tagInt)
            {
                other.GetComponent<InteractableAbilite>().Interact();
                return;
            }
        }
    }
}
