using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

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
    [HideInInspector] public bool stateExiste;
}

public class UISave : MonoBehaviour
{
    [SerializeField] private Animator animator = null;
    private PlayerCameraMouvement cameraJoueur = null;
    private GameObject playerOBJ = null;
    private static UISave uiSave = null;
    private bool onSave;
    private bool existSave = false;
    private int saveifExit = 0;
    private bool inSave = false;

    [Header("UI Save")]
    [SerializeField] private UIButtonSave[] uiButtonSave = null;
    [SerializeField] private GameObject selection = null;
    [SerializeField] private GameObject chargement = null;
    [SerializeField] private GameObject partieSauvegarder = null;


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
        playerOBJ = GameObject.FindWithTag("Player");
        animator.gameObject.SetActive(true);
    }

    public void StartSaveMenu()
    {
        if (!onSave && !inSave)
        {
            animator.SetBool("IsOpen", true);
            onSave = true;
            cameraJoueur.MouseCursorMove = onSave;
            cameraJoueur.MouseSee = onSave;
            cameraJoueur.CameraMove = !onSave;
            loadInfoAllSave();
        }
    }

    void loadInfoAllSave()
    {
        for (int i = 0; i < uiButtonSave.Length; i++)
        {
            InfoPartiJoueur ipj = JsonUtility.FromJson<InfoPartiJoueur>(JSONArchiver.ExtractArchiveInfo(i, out uiButtonSave[i].stateExiste));
            uiButtonSave[i].nouvellePartie.SetActive(!uiButtonSave[i].stateExiste);
            uiButtonSave[i].partie.SetActive(uiButtonSave[i].stateExiste);
            if (uiButtonSave[i].stateExiste)
            {
                uiButtonSave[i].nom.text = ipj.nom;
                uiButtonSave[i].vie.text = ipj.vie.ToString("00") + "/" + playerOBJ.GetComponent<PlayerStarter>().Stat.VieMax.ToString("00");
                uiButtonSave[i].mana.text = ipj.mana.ToString("00") + "/" + playerOBJ.GetComponent<PlayerStarter>().Stat.ManaMax.ToString("00");
                uiButtonSave[i].tempsDate.text = ipj.tempsDate;
                uiButtonSave[i].tempsHeure.text = ipj.tempsHeure;
                uiButtonSave[i].tempsTotal.text = Mathf.Round((float)TimeSpan.FromSeconds(ipj.tempsTotal).TotalHours).ToString("00") + ":" + Mathf.Round((float)TimeSpan.FromSeconds(ipj.tempsTotal).TotalMinutes).ToString("00") + ":" + Mathf.Round(((ipj.tempsTotal / 60.0f) - Mathf.Floor(ipj.tempsTotal / 60.0f)) * 60.0f).ToString("00");
            }
        }
    }

    public void Save(int i)
    {
        if (!inSave)
        {
            partieSauvegarder.SetActive(false);
            existSave = File.Exists(Path.Combine(JSONArchiver.ArchivePath, "Player_" + i + ".json"));
            if (!existSave)
            {
                StartCoroutine(SaveWaiTime(i));
            }
            else
            {
                saveifExit = i;
                selection.SetActive(true);
                animator.SetBool("Choix", true);
            }
        }
    }

    IEnumerator SaveWaiTime(int i)
    {
        if (!inSave)
        {
            inSave = true;
            chargement.SetActive(true);
            playerOBJ.GetComponent<PlayerSaveManager>().SaveAll(i);
            playerOBJ.GetComponent<PlayerController>().IsInteract = true;
            GameObject.FindWithTag("SceneSave").GetComponent<SceneSave>().SaveAll();
            JSONArchiver.archiveJSON(i);
            yield return new WaitForSeconds(1.5f);
            loadInfoAllSave();
            partieSauvegarder.SetActive(true);
            playerOBJ.GetComponent<PlayerController>().IsInteract = false;
            chargement.SetActive(false);
            animator.SetBool("Choix", true);
            inSave = false;
        }
        yield return null;
    }

    public void Comfirm(bool state)
    {
        if (!inSave)
        {
            if (state)
            {
                StartCoroutine(SaveWaiTime(saveifExit));
            }
            selection.SetActive(false);
            animator.SetBool("Choix", false);
        }
    }

    public void ConfirmPartieSave()
    {
        partieSauvegarder.SetActive(false);
        animator.SetBool("Choix", false);
    }

    public void EndSaveMenu()
    {
        animator.SetBool("IsOpen", false);
        animator.SetBool("Choix", false);
        onSave = false;
        cameraJoueur.MouseCursorMove = onSave;
        cameraJoueur.MouseSee = onSave;
        cameraJoueur.CameraMove = !onSave;
        selection.SetActive(false);
        partieSauvegarder.SetActive(false);
    }
}
