using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    [SerializeField] private GameObject combatZone = null;
    [SerializeField] private GameObject combatCameraTarget = null;
    [SerializeField] private Animator anim = null;
    [SerializeField] private GameObject[] uIActive = null;
    [SerializeField] private GameObject[] uiDesactive = null;
    public void StartCombat(bool playerIsAttack,GameObject player,GameObject ennemie)
    {
        StartCoroutine(StartCombatCoroutine(playerIsAttack,player,ennemie));
    }

    IEnumerator StartCombatCoroutine(bool playerIsAttack,GameObject player,GameObject ennemie)
    {
        PlayerCameraMouvement cam = GameObject.FindGameObjectWithTag("PivotCamera").GetComponent<PlayerCameraMouvement>();
        cam.CameraMove = false;
        anim.gameObject.SetActive(true);
        player.GetComponent<PlayerController>().IsInteract = true;
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
