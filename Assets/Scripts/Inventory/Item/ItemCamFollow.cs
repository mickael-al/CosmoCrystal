using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCamFollow : MonoBehaviour
{
    private Camera cam = null;
    void Start()
    {
        cam = Camera.main;
    }

    void LateUpdate()
    {
        transform.LookAt(cam.transform);
    }
}
