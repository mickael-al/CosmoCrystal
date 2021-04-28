using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{    
    [SerializeField] private TextMeshProUGUI nameText = null;
    [SerializeField] private TextMeshProUGUI dialogueText = null;
    [SerializeField] private Animator animator = null;
    private bool onDialog;
    private PlayerCameraMouvement cameraJoueur = null;
    private Queue<string> sentences = new Queue<string>();
    private static DialogueManager dialogueManager = null;
    private bool couroutineSkip = false;

    #region GetterSetter
        public static DialogueManager Instance
        {
            get
            {
                return dialogueManager;
            }
        }
    #endregion

    private void Awake() 
    {
        dialogueManager = this;    
    }

    private void Start()
    {
        cameraJoueur = GameObject.FindWithTag("PivotCamera").GetComponent<PlayerCameraMouvement>();
        animator.gameObject.SetActive(true);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        onDialog = true;
        cameraJoueur.MouseCursorMove = onDialog;
        cameraJoueur.MouseSee = onDialog;
        nameText.text = dialogue.Name;

        sentences.Clear();

        foreach (string sentence in dialogue.Sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public bool DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return true;
        }

        string sentence = sentences.Dequeue();

        StartCoroutine(TypeSentence(sentence.ToCharArray()));
        return false;
    }

    IEnumerator TypeSentence(char[] sentence)
    {
        couroutineSkip = true;//skip l'ancienne coroutine
        yield return null;
        yield return null;
        couroutineSkip = false;
        dialogueText.text = "";
        for(int i = 0; i < sentence.Length && !couroutineSkip;i++)
        {
            dialogueText.text += sentence[i];
            yield return null;
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        onDialog = false;
        cameraJoueur.MouseCursorMove = onDialog;
        cameraJoueur.MouseSee = onDialog;
    }


}
