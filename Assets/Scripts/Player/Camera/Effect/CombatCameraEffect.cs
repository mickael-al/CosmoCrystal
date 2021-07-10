using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCameraEffect : CameraEffect
{
    private bool useState = true;
    private Vector3 originalPos;
    private Vector3 originaleuler;    
    private Transform cam;
    private CurveSO cso;
    public IEnumerator Effect(GameObject Camera,float duree,float magnitude,float smoothnessSpeed)
    {        
        useState = true;
        cam = Camera.transform.GetChild(0);
        cso=Resources.Load("Animation/CombatCameraEffect") as CurveSO;
        yield return new WaitForSeconds(1.0f);
        originalPos = cam.localPosition;
        originaleuler = cam.localEulerAngles;
        Vector3 dirrections = cam.TransformDirection(Vector3.forward)*10.0f+cam.position;
        float timer = 0.0f;
        float tValue = 0.0f;
        float m = 2.0f;
        while(useState)
        {
            tValue = Random.Range(1.2f,2.0f)*8.0f;
            timer = 0.0f;
            Vector3 newPos = new Vector3(Random.Range(-m,m)+originalPos.x,Random.Range(-m,m)+originalPos.y,Random.Range(-m,m)+originalPos.z);
            Vector3 startPos = cam.localPosition;
            while(timer < tValue && useState)
            {                
                cam.localPosition = Vector3.Lerp(startPos,newPos,cso.animationCurve.Evaluate(timer/tValue));
                timer+=Time.deltaTime;
                cam.transform.LookAt(dirrections);
                yield return null;
            }
            yield return new WaitForSeconds(1.0f);
        }        
    }
    public void StopEffect()
    {
        useState = false;
        cam.localPosition = originalPos;
        cam.localEulerAngles = originaleuler;
    }
}
