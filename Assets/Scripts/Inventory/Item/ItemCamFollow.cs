using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCamFollow : MonoBehaviour
{
    private Camera cam = null;
    private float yPos;
    private Vector3 newPos;
    [Range(0.0f,1.0f)] [SerializeField] private float sinPorcent = 0.5f;
    [SerializeField] private float speedAnimation = 1.5f;
    void Start()
    {
        cam = Camera.main;
        newPos = transform.localPosition;
        yPos = newPos.y;        
    }

    void LateUpdate()
    {
        transform.LookAt(cam.transform);
        newPos.y = yPos + Mathf.Sin(Time.time*speedAnimation)*sinPorcent;
        transform.localPosition = newPos;
    }
}
