using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Attaque/AttaqueRendu/AR_Morsure", order = 1)]
public class AR_Morsure : AttaqueRendu
{
    private GameObject glow = null;
    private float tempsQTE;
    private float tempsEndQTE;
    private bool QTE = false;
    public override IEnumerator Rendu(GameObject lanceur,List<GameObject> cible,Attaque att)
    {
        if (!isRunning)
        {
            isRunning = true;
            yield return null;
            CurveSO cs = Resources.Load("Animation/zigzagAttaque") as CurveSO;
            Vector3 startPoint = lanceur.transform.position;
            Vector3 targetPoint = cible[0].transform.position + new Vector3(0,0.6f,0);
            Vector3 dir = (targetPoint - startPoint).normalized;
            float distTarget = Vector3.Distance(targetPoint,startPoint);
            float speed;
            float timeMax = 1.5f;
            float timer = timeMax;
            //Debug.Log(cs);
            while(timer > 0.2f)
            {
                timer -= Time.deltaTime;
                speed = 1-(timer/timeMax);
                lanceur.transform.position = new Vector3(startPoint.x+cs.animationCurve.Evaluate(speed)*3.0f,startPoint.y+distTarget*dir.y*speed,startPoint.z+distTarget*dir.z*speed);
                yield return null;
            }
            glow = Instantiate(Resources.Load("AttaqueEffect/Glow") as GameObject,lanceur.transform.position,Quaternion.identity);
            InputManager.InputJoueur.Controller.ActionPrincipale.performed += ctx => ActionPrincipale();  
            float timerQTEMax = 0.6f;
            float timerQTE = timerQTEMax;
            tempsQTE = Time.time + timerQTEMax;
            QTE = true;
            while(timerQTE > 0.0f)
            {
                timerQTE -= Time.deltaTime;
                yield return null;
            }   
            QTE = false;
            Destroy(glow);
            InputManager.InputJoueur.Controller.ActionPrincipale.performed -= ctx => ActionPrincipale(); 
            GameObject go = Instantiate(Resources.Load("AttaqueEffect/AR_Morsure") as GameObject,targetPoint,Quaternion.identity);
            go.GetComponent<AttaqueDegatCombat>().LanceurAttaque = att;
            go.GetComponent<AttaqueDegatCombat>().LanceurStat = lanceur.GetComponent<StyleCombat>().statistique;
            go.GetComponent<AttaqueDegatCombat>().PourcentageReussite = (1-(Mathf.Clamp(Mathf.Abs(tempsEndQTE-tempsQTE),0,timerQTEMax)/timerQTEMax))*100.0f;
            go.GetComponent<AttaqueDegatCombat>().ActiveTime = 0.2f;

            while(timer < timeMax)
            {
                timer += Time.deltaTime;
                speed = 1-(timer/timeMax);
                lanceur.transform.position = new Vector3(startPoint.x+distTarget*dir.x*speed,startPoint.y+distTarget*dir.y*speed,startPoint.z+distTarget*dir.z*speed);
                yield return null;
            }
            Destroy(go);
            
            lanceur.transform.position = startPoint;
            isRunning = false;
        }
    }

    public void ActionPrincipale()
    {
        if(QTE)
        {
            QTE = false;
            tempsEndQTE = Time.time;
            Destroy(glow);
        }
    }

    public override void Interuption()
    {
        if (!isRunning)
        {
            
        }
    }
}
