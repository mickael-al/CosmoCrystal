using System.Collections;
using UnityEngine;
public interface CameraEffect
{
    IEnumerator Effect(GameObject Camera,float duree,float magnitude,float smoothnessSpeed);
}
