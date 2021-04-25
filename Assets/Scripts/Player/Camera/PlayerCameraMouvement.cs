﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraMouvement : MonoBehaviour
{
    [Header("Camera Settings")]
    [Range(0,5)][SerializeField] private float sensitiveX = 1.0f;
    [Range(0,5)][SerializeField] private float sensitiveY = 1.0f;
    [SerializeField] private Vector2 angleMaxX = Vector2.zero;
    [SerializeField] private float angleMaxClamp = 10.0f;
    [SerializeField] private float speedMoveCamera = 2.0f;
    [SerializeField] private float speedAdaptationWallCamera = 2.0f;
    [SerializeField] private float distanceCamera = 13.0f;
    [SerializeField] private float mindistance = 8.0f;
    [SerializeField] private GameObject cameraObj = null;
    [SerializeField] private LayerMask layerMask = ~0;
    private GameObject target = null;
    private float angleY = 0.0f;
    private float angleX = 0.0f;
    private Vector2 cameraAxisMouse = Vector2.zero;
    private Vector2 cameraAxisPad = Vector2.zero;
    private float varDistCamera = 13.0f;
    private RaycastHit hit;

    void Start()
    {
        InputManager.InputJoueur.Controller.CameraMouse.Enable();
        InputManager.InputJoueur.Controller.CameraGamePad.Enable();
        InputManager.InputJoueur.Controller.ActionPrincipale.Enable();
        //InputManager.InputJoueur.Controller.ActionPrincipale.performed += ctx => ApplyEffect(new ShakeCamera(),1.0f,0.2f,1.0f);
        target = GameObject.FindWithTag("Player");
        if(target)
        {
            angleY = target.transform.eulerAngles.y;
            angleX = transform.eulerAngles.x;
        }
        else{
            Debug.LogWarning("Le tag player cannot find");
            Destroy(this);
        }
        varDistCamera = distanceCamera;
        cameraObj.transform.localPosition = new Vector3(0,0,-distanceCamera);
    }

    void Update()
    {
        cameraAxisMouse = Vector2.Lerp(cameraAxisMouse, InputManager.InputJoueur.Controller.CameraMouse.ReadValue<Vector2>(), Time.deltaTime * 12.0f);
        cameraAxisPad = Vector2.Lerp(cameraAxisPad, InputManager.InputJoueur.Controller.CameraGamePad.ReadValue<Vector2>(), Time.deltaTime * 12.0f);
        angleY += cameraAxisMouse.x * sensitiveX;
        angleY += cameraAxisPad.x*1.5f;
        angleX += cameraAxisMouse.y * sensitiveY;
        angleX += cameraAxisPad.y;
        if(angleX < angleMaxX.x)
        {
            angleX = Mathf.Lerp(angleX,angleMaxX.x,Time.deltaTime*13.0f);
        }
        if(angleX > angleMaxX.y)
        {
            angleX = Mathf.Lerp(angleX,angleMaxX.y,Time.deltaTime*13.0f);
        }
        angleX = Mathf.Clamp(angleX,angleMaxX.x-angleMaxClamp,angleMaxX.y+angleMaxClamp);
        transform.eulerAngles = new Vector3(angleX,angleY,0);
        transform.position = Vector3.Lerp(transform.position,target.transform.position ,Time.deltaTime * speedMoveCamera);
       
        if (Physics.Raycast(transform.position, -transform.TransformDirection(Vector3.forward), out hit, distanceCamera,layerMask))
        {            
            varDistCamera = hit.distance < mindistance ? distanceCamera : hit.distance-1;
        }
        else
        {
            varDistCamera = distanceCamera;
        }

        cameraObj.transform.localPosition = Vector3.Lerp(cameraObj.transform.localPosition,new Vector3(0,0,-varDistCamera),Time.deltaTime * speedAdaptationWallCamera);
    }

    public void ApplyEffect(CameraEffect ce,float duree,float magnitude,float smoothness)
    {
        StartCoroutine(ce.Effect(cameraObj,duree,magnitude, smoothness));
    }
}