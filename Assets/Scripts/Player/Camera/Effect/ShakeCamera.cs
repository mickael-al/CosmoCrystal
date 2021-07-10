using System.Collections;
using UnityEngine;

public class ShakeCamera : CameraEffect
{
    public IEnumerator Effect(GameObject Camera,float duree,float magnitude,float smoothnessSpeed)
    {
        Vector3 originalPos = Camera.transform.localPosition;
        float elapsed = 0.0f;
        float x = 0.0f;
        float y = 0.0f;
        while(elapsed < duree)
        {
            x = Random.Range(-1.0f,1.0f) * magnitude;
            y = Random.Range(-1.0f,1.0f) * magnitude;
            Camera.transform.localPosition = new Vector3(x,y,originalPos.z);
            elapsed += Time.deltaTime;
            yield return null;
        }
        Camera.transform.localPosition = originalPos;
        yield return null;
    }

    public void StopEffect()
    {

    }
}
