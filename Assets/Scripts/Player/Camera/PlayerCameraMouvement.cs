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
    [SerializeField] private float speedAdaptationWallCamera = 2.0f;
    [SerializeField] private float distanceCamera = 13.0f;
    [SerializeField] private float mindistance = 8.0f;
    [SerializeField] private GameObject cameraObj = null;
    [SerializeField] private LayerMask layerMask = ~0;
    private List<CameraEffect> effectCoroutineList = new List<CameraEffect>();

    [Header("Mouse")]

    [SerializeField] private bool mouseSee = false;
    [SerializeField] private bool mouseCursorMove = false;
    [SerializeField] private bool cameraMove = true;
    [SerializeField] private bool followTarget = true;
    private GameObject target = null;
    private float angleY = 0.0f;
    private float angleX = 0.0f;
    private Vector2 cameraAxisMouse = Vector2.zero;
    private Vector2 cameraAxisPad = Vector2.zero;
    private float varDistCamera = 13.0f;
    private RaycastHit hit;

    #region GetterSetter
        public bool MouseSee{
            get{
                return mouseSee;
            }
            set{
                Cursor.visible = value;
                mouseSee = value;
            }
        }

        public bool MouseCursorMove
        {
            get{
                return mouseCursorMove;
            }
            set{
                if(value)
                {
                    Cursor.lockState = CursorLockMode.None;
                }
                else{
                    Cursor.lockState = CursorLockMode.Locked;
                }
                mouseCursorMove = value;
            }
        }
        public bool CameraMove
        {
            get{
                return cameraMove;
            }
            set{
                cameraMove = value;
            }
        }

        public bool FollowTarget
        {
            get{
                return followTarget;
            }
            set{
                followTarget = value;
            }
        }

        public GameObject Target
        {
            get{
                return target;
            }
            set{
                target = value;
                angleY = target.transform.eulerAngles.y;
                angleX = target.transform.eulerAngles.x;
            }
        }
    #endregion

    public void ChangeAngleY(float angle)
    {
        angleY = angle;
        transform.eulerAngles = new Vector3(angleX,angleY,0);
    }

    void Start()
    {
        transform.parent = null;
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
        MouseSee = MouseSee;
        MouseCursorMove = MouseCursorMove;
    }

    void Update()
    {
        if(cameraMove)
        {
            cameraAxisMouse = Vector2.Lerp(cameraAxisMouse, InputManager.InputJoueur.Controller.CameraMouse.ReadValue<Vector2>(), Time.deltaTime * 12.0f);
            cameraAxisPad = Vector2.Lerp(cameraAxisPad, InputManager.InputJoueur.Controller.CameraGamePad.ReadValue<Vector2>(), Time.deltaTime * 12.0f);
        }
        else
        {
            cameraAxisMouse = Vector2.Lerp(cameraAxisMouse, Vector2.zero, Time.deltaTime * 12.0f);
            cameraAxisPad = Vector2.Lerp(cameraAxisPad, Vector2.zero, Time.deltaTime * 12.0f);
        }
        angleY += cameraAxisMouse.x * sensitiveX * Time.deltaTime * 100.0f;
        angleY += cameraAxisPad.x * Time.deltaTime * 250.0f;
        angleX += cameraAxisMouse.y * sensitiveY * Time.deltaTime * 100.0f;
        angleX += cameraAxisPad.y* Time.deltaTime * 100.0f;
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
        if(followTarget)
        {
            transform.position = Vector3.Lerp(transform.position,target.transform.position ,Time.deltaTime * speedMoveCamera);
        }
       
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
        effectCoroutineList.Add(ce);
        StartCoroutine(ce.Effect(cameraObj,duree,magnitude, smoothness));
    }

    public void StopAllEffect()
    {
        foreach(CameraEffect c in effectCoroutineList)
        {
            if(c != null)
            {
                c.StopEffect();
            }
        }
    }
}
