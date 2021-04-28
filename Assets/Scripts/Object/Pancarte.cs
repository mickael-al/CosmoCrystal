using UnityEngine;
public class Pancarte : Interactable
{
    [SerializeField] private Dialogue dialogue = null;

    public override void StartInteract()
    {
        base.StartInteract();
    }
    public override void Interact(Character character)
    {
        if(useState)
        {
            if(!interactState)
            {
                interactState = true;
                base.Interact(character);
                DialogueManager.Instance.StartDialogue(dialogue);
                return;
            }
            if(DialogueManager.Instance.DisplayNextSentence())
            {
                DialogueManager.Instance.EndDialogue();
                interactState = false;
            }
        }
    }
    public override void StopInteract()
    {                
        if(interactState && useState)
        {
            DialogueManager.Instance.EndDialogue();
            interactState = false;
        }
        base.StopInteract();
    }

    public override void ChangeInteract()
    {
        base.ChangeInteract();
        if(interactState && useState)
        {
            DialogueManager.Instance.EndDialogue();
            interactState = false;
        }
    }

    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {
        base.Update();
    }
}
