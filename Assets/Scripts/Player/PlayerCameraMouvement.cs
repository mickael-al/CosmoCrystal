using System.Collections;
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
    private GameObject target = null;
    private float angleY = 0.0f;
    private float angleX = 0.0f;
    private Vector2 cameraAxisMouse = Vector2.zero;
    private Vector2 cameraAxisPad = Vector2.zero;
    void Start()
    {
        InputManager.InputJoueur.Controller.CameraMouse.Enable();
        InputManager.InputJoueur.Controller.CameraGamePad.Enable();
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
    }
}
