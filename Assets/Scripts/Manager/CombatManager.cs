using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField] private GameObject combatZone = null;
    [SerializeField] private GameObject combatCameraTarget = null;
    [SerializeField] private GameObject[] playerSpawnPoint = null;
    [SerializeField] private GameObject[] ennemiSpawnPoint = null;
    [SerializeField] private Animator anim = null;
    [SerializeField] private GameObject[] uIActive = null;
    [SerializeField] private GameObject[] uiDesactive = null;

    private List<GameObject> allPlayer = new List<GameObject>();
    private List<GameObject> allEnnemi = new List<GameObject>();
    public void StartCombat(bool playerIsAttack,GameObject player,GameObject ennemie)
    {
        StartCoroutine(StartCombatCoroutine(playerIsAttack,player,ennemie));
    }

    IEnumerator StartCombatCoroutine(bool playerIsAttack,GameObject player,GameObject ennemie)
    {
        PlayerCameraMouvement cam = GameObject.FindGameObjectWithTag("PivotCamera").GetComponent<PlayerCameraMouvement>();
        GetComponent<UIInventaire>().OpenInventaire(false);
        cam.CameraMove = false;
        anim.gameObject.SetActive(true);
        player.GetComponent<PlayerController>().IsInteract = true;    
        player.GetComponent<CombatStarter>().IsFighting = true;
        ennemie.GetComponent<CombatStarter>().IsFighting = true;
        allPlayer.Add(Instantiate(player.GetComponent<CombatStarter>().SpawnPrefab,playerSpawnPoint[0].transform.position,Quaternion.Euler(0,180,0)));
        player.GetComponent<Inventaire>().EquipeModel(allPlayer[0].GetComponent<EquipableModel>());
        allEnnemi.Add(Instantiate(ennemie.GetComponent<CombatStarter>().SpawnPrefab,ennemiSpawnPoint[0].transform.position,Quaternion.Euler(0,0,0)));
        if(ennemie.GetComponent<Inventaire>())
        {
            ennemie.GetComponent<Inventaire>().EquipeModel(allEnnemi[0].GetComponent<EquipableModel>());
        }
        for(int i = 0; i < 4;i++)
        {
            if(i < player.GetComponent<CombatStarter>().Alli.Count)
            {
                GameObject go = Instantiate(player.GetComponent<CombatStarter>().Alli[i].SpawnPrefab,playerSpawnPoint[i+1].transform.position,Quaternion.Euler(0,180,0));
                if(player.GetComponent<CombatStarter>().Alli[i].GetComponent<Inventaire>())
                {
                    player.GetComponent<CombatStarter>().Alli[i].GetComponent<Inventaire>().EquipeModel(go.GetComponent<EquipableModel>());
                }
                allPlayer.Add(go);
            }
            if(i < ennemie.GetComponent<CombatStarter>().Alli.Count)
            {
                GameObject go = Instantiate(ennemie.GetComponent<CombatStarter>().Alli[i].SpawnPrefab,ennemiSpawnPoint[i+1].transform.position,Quaternion.Euler(0,0,0));
                if(ennemie.GetComponent<CombatStarter>().Alli[i].GetComponent<Inventaire>())
                {
                    ennemie.GetComponent<CombatStarter>().Alli[i].GetComponent<Inventaire>().EquipeModel(go.GetComponent<EquipableModel>());
                }
                allEnnemi.Add(go);
            }
        }
        
        float timer = 0.0f;
        while(timer < 0.35f)
        {
            anim.SetFloat("Transition",timer);
            timer += Time.deltaTime*0.3f;
            yield return null;
        }
        foreach(GameObject go in uIActive)
        {
            go.SetActive(true);
        }
        foreach(GameObject go in uiDesactive)
        {
            go.SetActive(false);
        }
        combatZone.SetActive(true);        
        cam.MouseSee = true;
        cam.MouseCursorMove = true;
        cam.Target = combatCameraTarget;   
        cam.transform.position = combatCameraTarget.transform.position;
        while(timer < 1.0f)
        {
            anim.SetFloat("Transition",timer);
            timer += Time.deltaTime*0.8f;
            yield return null;
        }    
        anim.gameObject.SetActive(false); 
    }

    public void EndCombat(bool playerWin)
    {

    }
}
