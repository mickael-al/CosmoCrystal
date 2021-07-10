using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    [SerializeField] private GameObject combatZone = null;
    [SerializeField] private GameObject combatCameraTarget = null;
    [SerializeField] private GameObject[] playerSpawnPoint = null;
    [SerializeField] private GameObject[] ennemiSpawnPoint = null;
    [SerializeField] private Animator anim = null;
    [SerializeField] private GameObject[] uIActive = null;
    [SerializeField] private GameObject[] uiDesactive = null;
    [SerializeField] private GameObject AttaqueUI = null;
    [SerializeField] private GameObject ObjectUI = null;
    [SerializeField] private TextMeshProUGUI AttaqueInfo = null;
    [SerializeField] private GameObject ContentBoxUIAttaque = null;
    [SerializeField] private GameObject ContentBoxUIObject = null;
    [SerializeField] private GameObject prefabsElementAttaques = null;
    [SerializeField] private GameObject prefabsElementObject = null;
    [SerializeField] private GameObject prefabSelectMob = null;
    [SerializeField] private UIStatPlayer uisp = null;
    [SerializeField] private FloatingTextControler ftc = null;
    [SerializeField] private List<GameObject> notePrefabsAttaque = new List<GameObject>();
    [SerializeField] private GameObject spawnPointNote = null;
    private List<GameObject> spawnAttaqueBase = new List<GameObject>();
    private List<GameObject> spawnAttaqueSpe = new List<GameObject>();
    private List<GameObject> spawnConsomable = new List<GameObject>();
    private List<GameObject> spawnSelectMob = new List<GameObject>();
    private bool attaqueMenuState = false;
    private bool objectMenuState = false;
    private bool inCombat = false;
    private bool playerAttack = false;
    private bool inChoixPlayerTarget = false;
    private Attaque AttacksChoixPlayerTarget = null;
    private int indiceChoixPlayerTarget = 0;
    private int tours = 0;


    private List<GameObject> allPlayer = new List<GameObject>();
    private List<GameObject> allEnnemi = new List<GameObject>();
    private List<GameObject> orderAttaque = new List<GameObject>();

    #region GetterSetter
    public List<GameObject> AllPlayer { get { return allPlayer; } set { allPlayer = value; } }
    public List<GameObject> AllEnnemi { get { return allEnnemi; } set { allEnnemi = value; } }
    public List<GameObject> NotePrefabsAttaque { get { return notePrefabsAttaque; } }
    public UIStatPlayer Uisp { get { return uisp; } }
    public FloatingTextControler Ftc { get { return ftc; } }
    #endregion
    public void StartCombat(bool playerIsAttack, GameObject player, GameObject ennemie)
    {
        StartCoroutine(StartCombatCoroutine(playerIsAttack, player, ennemie));
    }

    IEnumerator StartCombatCoroutine(bool playerIsAttack, GameObject player, GameObject ennemie)
    {
        PlayerCameraMouvement cam = GameObject.FindGameObjectWithTag("PivotCamera").GetComponent<PlayerCameraMouvement>();
        GetComponent<UIInventaire>().OpenInventaire(false);
        cam.CameraMove = false;
        anim.gameObject.SetActive(true);
        player.GetComponent<PlayerController>().IsInteract = true;
        player.GetComponent<CombatStarter>().IsFighting = true;
        ennemie.GetComponent<CombatStarter>().IsFighting = true;
        allPlayer.Add(Instantiate(player.GetComponent<CombatStarter>().SpawnPrefab, playerSpawnPoint[0].transform.position, Quaternion.Euler(0, 180, 0)));
        allPlayer[0].GetComponent<StyleCombat>().statistique = player.GetComponent<CombatStarter>().Stat;
        allPlayer[0].GetComponent<StyleCombat>().AttaquesList = player.GetComponent<CombatStarter>().AttaquesList;
        player.GetComponent<Inventaire>().EquipeModel(allPlayer[0].GetComponent<EquipableModel>());
        allEnnemi.Add(Instantiate(ennemie.GetComponent<CombatStarter>().SpawnPrefab, ennemiSpawnPoint[0].transform.position, Quaternion.Euler(0, 0, 0)));
        allEnnemi[0].GetComponent<StyleCombat>().statistique = ennemie.GetComponent<CombatStarter>().Stat;
        allEnnemi[0].GetComponent<StyleCombat>().AttaquesList = ennemie.GetComponent<CombatStarter>().AttaquesList;
        ennemie.GetComponent<CombatStarter>().Stat.Vie = ennemie.GetComponent<CombatStarter>().Stat.VieMax;
        
        for (int i = 0; i < player.GetComponent<CombatStarter>().AttaquesList.Count; i++)
        {
            spawnAttaqueBase.Add(Instantiate(prefabsElementAttaques, Vector3.zero, Quaternion.identity, ContentBoxUIAttaque.transform));
            spawnAttaqueBase[i].GetComponent<ElementAttaqueCombat>().Cm = this;
            spawnAttaqueBase[i].GetComponent<ElementAttaqueCombat>().Attacks = player.GetComponent<CombatStarter>().AttaquesList[i].Attaque;
        }
        if (ennemie.GetComponent<Inventaire>())
        {
            ennemie.GetComponent<Inventaire>().EquipeModel(allEnnemi[0].GetComponent<EquipableModel>());
        }
        for (int i = 0; i < 4; i++)
        {
            if (i < player.GetComponent<CombatStarter>().Alli.Count)
            {
                GameObject go = Instantiate(player.GetComponent<CombatStarter>().Alli[i].SpawnPrefab, playerSpawnPoint[i + 1].transform.position, Quaternion.Euler(0, 180, 0));
                if (player.GetComponent<CombatStarter>().Alli[i].GetComponent<Inventaire>())
                {
                    player.GetComponent<CombatStarter>().Alli[i].GetComponent<Inventaire>().EquipeModel(go.GetComponent<EquipableModel>());
                }
                allPlayer.Add(go);
                go.GetComponent<StyleCombat>().statistique = player.GetComponent<CombatStarter>().Alli[i].GetComponent<CombatStarter>().Stat;
                go.GetComponent<StyleCombat>().statistique.Vie = go.GetComponent<StyleCombat>().statistique.VieMax;
                go.GetComponent<StyleCombat>().AttaquesList = player.GetComponent<CombatStarter>().Alli[i].GetComponent<CombatStarter>().AttaquesList;
            }
            if (i < ennemie.GetComponent<CombatStarter>().Alli.Count)
            {
                GameObject go = Instantiate(ennemie.GetComponent<CombatStarter>().Alli[i].SpawnPrefab, ennemiSpawnPoint[i + 1].transform.position, Quaternion.Euler(0, 0, 0));
                if (ennemie.GetComponent<CombatStarter>().Alli[i].GetComponent<Inventaire>())
                {
                    ennemie.GetComponent<CombatStarter>().Alli[i].GetComponent<Inventaire>().EquipeModel(go.GetComponent<EquipableModel>());
                }
                allEnnemi.Add(go);
                go.GetComponent<StyleCombat>().statistique = ennemie.GetComponent<CombatStarter>().Alli[i].GetComponent<CombatStarter>().Stat;
                go.GetComponent<StyleCombat>().statistique.Vie = go.GetComponent<StyleCombat>().statistique.VieMax;
                go.GetComponent<StyleCombat>().AttaquesList = ennemie.GetComponent<CombatStarter>().Alli[i].GetComponent<CombatStarter>().AttaquesList;
            }
        }

        float timer = 0.0f;
        while (timer < 0.35f)
        {
            anim.SetFloat("Transition", timer);
            timer += Time.deltaTime * 0.3f;
            yield return null;
        }
        foreach (GameObject go in uiDesactive)
        {
            go.SetActive(false);
        }
        combatZone.SetActive(true);
        cam.ApplyEffect(new CombatCameraEffect(), 0.0f, 0.0f, 0.0f);
        cam.MouseSee = true;
        cam.MouseCursorMove = true;
        cam.Target = combatCameraTarget;
        cam.transform.position = combatCameraTarget.transform.position;
        while (timer < 1.0f)
        {
            anim.SetFloat("Transition", timer);
            timer += Time.deltaTime * 0.8f;
            yield return null;
        }
        anim.gameObject.SetActive(false);
        inCombat = true;
        playerAttack = playerIsAttack;
        tours = 0;
        for (int i = 0; i < allPlayer.Count; i++)
        {
            allPlayer[i].GetComponent<StyleCombat>().CM = this;
            StartCoroutine(allPlayer[i].GetComponent<StyleCombat>().sCombat());
        }
        for (int i = 0; i < allEnnemi.Count; i++)
        {
            allEnnemi[i].GetComponent<StyleCombat>().CM = this;
            StartCoroutine(allEnnemi[i].GetComponent<StyleCombat>().sCombat());
        }
        Next();
    }

    private void orderBySpeed()
    {
        for (int i = 0; i < allPlayer.Count; i++)
        {
            orderAttaque.Add(allPlayer[i]);
        }
        for (int i = 0; i < allEnnemi.Count; i++)
        {
            orderAttaque.Add(allEnnemi[i]);
        }
        orderAttaque.OrderBy(orderAttaque => orderAttaque.GetComponent<StyleCombat>().statistique.VitesseMax);
        if (tours == 0)
        {
            if (playerAttack)
            {
                orderAttaque.Remove(allPlayer[0]);
                orderAttaque.Insert(0, allPlayer[0]);
            }
            else
            {
                orderAttaque.Remove(allPlayer[0]);
                orderAttaque.Add(allPlayer[0]);
            }
        }
    }

    public void Next()
    {
        if (orderAttaque.Count > 0)
        {
            orderAttaque[0].GetComponent<StyleCombat>().CanFight = true;
            orderAttaque.Remove(orderAttaque[0]);
        }
        else
        {
            orderBySpeed();
            orderAttaque[0].GetComponent<StyleCombat>().CanFight = true;
            orderAttaque.Remove(orderAttaque[0]);
            tours++;
            //Debug.Log("tours : " + tours);
        }
    }

    public void UICombatChoix(bool state)
    {
        foreach (GameObject go in uIActive)
        {
            go.SetActive(state);
        }
    }

    public void AttaqueBouton()
    {
        if (!inChoixPlayerTarget)
        {
            attaqueMenuState = !attaqueMenuState;
            objectMenuState = false;
            AttaqueUI.SetActive(attaqueMenuState);
            ObjectUI.SetActive(objectMenuState);
        }
    }

    public void MajInfo(Attaque attacks)
    {
        AttaqueInfo.text = "Cible : " + attacks.CiblesAttacks.ToString() + " Types : " + attacks.TypeDegat.ToString() + "/" + attacks.TypeAttaque.ToString() + "\nEffet : " + "Aucun";
    }

    public void ObjectBouton()
    {
        if (!inChoixPlayerTarget)
        {
            objectMenuState = !objectMenuState;
            attaqueMenuState = false;
            AttaqueUI.SetActive(attaqueMenuState);
            ObjectUI.SetActive(objectMenuState);
        }
    }

    public void Fuite()
    {
        if (!inChoixPlayerTarget)
        {

        }
    }
    private void Start()
    {
        InputManager.InputJoueur.Controller.ActionPrincipale.performed += ctx => ActionPrincipale();
        InputManager.InputJoueur.Controller.ActionSecondaire.performed += ctx => ActionSecondaire();
        InputManager.InputJoueur.Controller.Mouvement.performed += ctx => MoveCursor();        
    }
    public void ActionPrincipale()
    {
        if (!inChoixPlayerTarget)
        {
            return;
        }
        inChoixPlayerTarget = false;
        AllPlayer[0].GetComponent<PlayerStyleCombat>().AttaqueChoix = AttacksChoixPlayerTarget;
        List<GameObject> cible = new List<GameObject>();
        cible.Add(AllEnnemi[indiceChoixPlayerTarget]);
        AllPlayer[0].GetComponent<PlayerStyleCombat>().Cible = AttacksChoixPlayerTarget.CiblesAttacks == Attaque.CiblesAttaque.Multiples ? AllEnnemi : cible;
        AllPlayer[0].GetComponent<PlayerStyleCombat>().Choix = false;
        for (int i = 0; i < spawnSelectMob.Count; i++)
        {
            Destroy(spawnSelectMob[i]);
        }
        spawnSelectMob.Clear();
        
    }

    public void NoteAttaque(float pourcentage)
    {
        GameObject go = Instantiate(notePrefabsAttaque[(int)Mathf.Floor(pourcentage*5.0f)],spawnPointNote.transform.position+new Vector3(0.0f,2.0f,0.0f),Quaternion.identity);
        Destroy(go,3.0f);
    }

    public void ActionSecondaire()
    {
        if (inChoixPlayerTarget)
        {
            inChoixPlayerTarget = false;
            for (int i = 0; i < spawnSelectMob.Count; i++)
            {
                Destroy(spawnSelectMob[i]);
            }
            spawnSelectMob.Clear();
            AttaqueBouton();
        }
    }
    private void MoveCursor()
    {
        if (inChoixPlayerTarget)
        {
            if (AttacksChoixPlayerTarget.CiblesAttacks == Attaque.CiblesAttaque.Seul)
            {
                spawnSelectMob[indiceChoixPlayerTarget].GetComponent<Animator>().SetTrigger("Stop");
                indiceChoixPlayerTarget = (InputManager.InputJoueur.Controller.Mouvement.ReadValue<Vector2>().x > 0 ? ++indiceChoixPlayerTarget : --indiceChoixPlayerTarget) % spawnSelectMob.Count;
                if(indiceChoixPlayerTarget < 0)
                {
                    indiceChoixPlayerTarget = spawnSelectMob.Count-1;
                }
                spawnSelectMob[indiceChoixPlayerTarget].GetComponent<Animator>().SetTrigger("Start");
            }
        }
    }

    public void AttaquePlayerChoix(Attaque attacks)
    {
        AttaqueBouton();
        AttacksChoixPlayerTarget = attacks;
        inChoixPlayerTarget = true;
        indiceChoixPlayerTarget = 0;
        for (int i = 0; i < allEnnemi.Count; i++)
        {
            spawnSelectMob.Add(Instantiate(prefabSelectMob, allEnnemi[i].transform.position, Quaternion.identity));
        }
        if (attacks.CiblesAttacks == Attaque.CiblesAttaque.Multiples)
        {
            for (int i = 0; i < allEnnemi.Count; i++)
            {
                spawnSelectMob[i].GetComponent<Animator>().SetTrigger("Start");
            }
        }
        else
        {
            spawnSelectMob[indiceChoixPlayerTarget].GetComponent<Animator>().SetTrigger("Start");
        }
    }

    public void EndCombat(bool playerWin)
    {

    }
}
