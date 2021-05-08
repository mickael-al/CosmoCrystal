using UnityEngine;

public class AbiliteInteraction : MonoBehaviour
{
    [SerializeField] private string[] tagInteract = null;
    private Character owner = null;

    public Character Owner
    {
        set
        {
            owner = value;
        }
    }

    private void OnTriggerEnter(Collider other) {
        foreach(string tagInt in tagInteract)
        {
            if(other.tag == tagInt)
            {
                other.GetComponent<InteractableAbilite>().Interact(owner);
                return;
            }
        }
    }
}
