using UnityEngine;

public class Porte : Interactable,I_Save
{
    [SerializeField] protected Item keyItem = null;
    [SerializeField] protected InteractStateSave locked = null;
    [SerializeField] protected Dialogue dialogueNotKey = null;

    [Header("Animation Porte")]
    [SerializeField] protected Animator animatorPorte = null;
    public override void StartInteract()
    {
        if(locked.locked)
        {
            base.StartInteract();
        }
    }
    public override void Interact(Character character)
    {        
        if(locked.locked && character.GetComponent<Inventaire>())
        {            
            if(character.GetComponent<Inventaire>().RemoveItem(keyItem))
            {
                locked.locked = false;
                animatorPorte.SetTrigger("Open");
                StopInteract();
                return;
            }
        }
        if(useState && locked.locked)
        {
            if(!interactState)
            {
                interactState = true;
                base.Interact(character);
                DialogueManager.Instance.StartDialogue(dialogueNotKey);
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

    public void Save(string s)
    {
        JSONArchiver.SaveJSONsFile(JSONArchiver.JSONPath, s, JsonUtility.ToJson(this.locked));
    }
    public void Load(string s)
    {
        bool state = false;
        bool lockBase = locked.locked;
        JsonUtility.FromJsonOverwrite(JSONArchiver.LoadJsonsFile(JSONArchiver.JSONPath, s, out state), this.locked);
        if (!state)
        {
            this.locked = new InteractStateSave();
            this.locked.locked = lockBase;
        }
        if(!this.locked.locked)
        {
            animatorPorte.SetTrigger("Disabled");
        }
    }
}
