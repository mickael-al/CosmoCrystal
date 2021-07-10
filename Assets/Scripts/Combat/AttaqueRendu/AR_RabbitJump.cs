using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Attaque/AttaqueRendu/AR_RabbitJump", order = 1)]
public class AR_RabbitJump : AttaqueRendu
{
    public override IEnumerator Rendu(GameObject lanceur,List<GameObject> cible,Attaque att)
    {
        if (!isRunning)
        {
            isRunning = true;
            yield return null;
            Animator anim = lanceur.GetComponent<StyleCombat>().Anim;
            CurveSO demiArc = Resources.Load("Animation/JumpLapin") as CurveSO;
            CurveSO arc = Resources.Load("Animation/DemiArcCurve") as CurveSO;
            GameObject prefabSpe = Resources.Load("AttaqueEffect/Hit_Spe") as GameObject;
            Vector3 startPoint = lanceur.transform.position;
            Vector3 targetPoint = cible[0].transform.position;
            Vector3 dir = (targetPoint - startPoint).normalized;
            float distTarget = Vector3.Distance(targetPoint,startPoint);
            float speed;
            float timeMax = 2.0f;
            float timer = timeMax;
            anim.SetTrigger("Jump");
            int i = Random.Range(0,2);
            if(i == 0)
            {
                Instantiate(prefabSpe,startPoint+new Vector3(0,1.0f,0),Quaternion.identity);
            }
            while(timer > timeMax/2.0f)
            {
                timer -= Time.deltaTime*1.5f;
                speed = 1-(timer/timeMax);
                lanceur.transform.position = new Vector3(startPoint.x+distTarget*dir.x*speed,startPoint.y+demiArc.animationCurve.Evaluate(speed)*1.5f,startPoint.z+distTarget*dir.z*speed);
                yield return null;
            }     
            anim.SetTrigger("Jump");
            if(i == 0)
            {
                yield return new WaitForSeconds(1.0f);
                anim.SetTrigger("Jump");
            }
            while(timer > 0.0f)
            {
                timer -= Time.deltaTime*2.0f;
                speed = 1-(timer/timeMax);
                lanceur.transform.position = new Vector3(startPoint.x+distTarget*dir.x*speed,startPoint.y+demiArc.animationCurve.Evaluate(speed)*1.5f,startPoint.z+distTarget*dir.z*speed);
                yield return null;
            }
            GameObject go = Instantiate(Resources.Load("AttaqueEffect/Hit") as GameObject,targetPoint,Quaternion.identity);
            go.GetComponent<AttaqueDegatCombat>().LanceurAttaque = att;
            go.GetComponent<AttaqueDegatCombat>().LanceurStat = lanceur.GetComponent<StyleCombat>().statistique;
            go.GetComponent<AttaqueDegatCombat>().PourcentageReussite = Random.Range(25.0f,100.0f);
            go.GetComponent<AttaqueDegatCombat>().ActiveTime = 0.05f;
            while(timer < 1.0f)
            {
                timer += Time.deltaTime;
                speed = 1-(timer/1.0f);
                lanceur.transform.position = new Vector3(startPoint.x+distTarget*dir.x*speed,startPoint.y+arc.animationCurve.Evaluate(speed)*1.5f,startPoint.z+distTarget*dir.z*speed);
                yield return null;
            }
            lanceur.transform.position = startPoint;
            Destroy(go);
            yield return new WaitForSeconds(1.0f);
            isRunning = false;
        }
    }

    public override void Interuption()
    {
        if (!isRunning)
        {
            
        }
    }
}
