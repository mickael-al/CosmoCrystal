using System.Collections;
using UnityEngine;
public class Morsure : MonoBehaviour,Abilite
{
    private GameObject prefabSpawn = null;
    private bool abiliteState = false;
    private float timerAttaqueRate = 0.8f;
    private float timerDureeEffect = 0.3f;
    private GameObject spawnEffect = null;
    private void Start() {
        prefabSpawn = Resources.Load("Abilite/Morsure") as GameObject;
    }
    public void startAbilite()
    {
        abiliteState = true;      
        spawnEffect = Instantiate(prefabSpawn,transform.position+transform.GetChild(0).TransformDirection(Vector3.forward)*1.5f,Quaternion.identity);
        spawnEffect.GetComponent<AbiliteInteraction>().Owner = gameObject.GetComponent<Character>();
        StartCoroutine(executeAbilite());
    }

    IEnumerator executeAbilite()
    {
        Destroy(spawnEffect,timerDureeEffect);
        yield return new WaitForSeconds(timerAttaqueRate);
        endAbilite();
    }

    public void endAbilite()
    {
        if(abiliteState)
        {
            Destroy(spawnEffect);
            abiliteState = false;
        }
    }
    public bool isActive()
    {
        return abiliteState;
    }
}
