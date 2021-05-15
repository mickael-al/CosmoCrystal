using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class UIButtonSave
{
    public GameObject nouvellePartie;
    public GameObject partie;
    public TextMeshProUGUI nom;
    public TextMeshProUGUI vie;
    public TextMeshProUGUI mana;
    public TextMeshProUGUI tempsDate;
    public TextMeshProUGUI tempsHeure;
    public TextMeshProUGUI tempsTotal;
}

public class UISave : MonoBehaviour
{
    [SerializeField] private Animator animator = null;
    private PlayerCameraMouvement cameraJoueur = null;
    private static UISave uiSave = null;
    private bool onSave;

    [Header("UI Save")]
    [SerializeField] private UIButtonSave[] uiButtonSave = null;
    [SerializeField] private GameObject selection = null;


    #region GetterSetter
        public static UISave Instance
        {
            get
            {
                return uiSave;
            }
        }
    #endregion
    void Awake()
    {
        uiSave = this;
    }

    private void Start()
    {
        cameraJoueur = GameObject.FindWithTag("PivotCamera").GetComponent<PlayerCameraMouvement>();
        animator.gameObject.SetActive(true);
    }

    public void StartSaveMenu()
    {
        animator.SetBool("IsOpen", true);
        onSave = true;
        cameraJoueur.MouseCursorMove = onSave;
        cameraJoueur.MouseSee = onSave;
        cameraJoueur.CameraMove = !onSave;
    }

    public void Save(int i)
    {
        Debug.Log("Save " + i);
        Debug.Log(uiButtonSave.Length);
    }

    public void EndSaveMenu()
    {
        animator.SetBool("IsOpen", false);
        onSave = false;
        cameraJoueur.MouseCursorMove = onSave;
        cameraJoueur.MouseSee = onSave;
        cameraJoueur.CameraMove = !onSave;
    }

   
}
