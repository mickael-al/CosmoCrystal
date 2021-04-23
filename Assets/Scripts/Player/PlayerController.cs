using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Character
{

    #region PlayerController
    [Header("CharacterControler")]
    [SerializeField] private CharacterController characterControler = null;
    [SerializeField] private LayerMask layerMaskRayCastFloor = ~0;
    [SerializeField] private bool floorAdaptation = true;
    [SerializeField] private GameObject pivot = null;
    [SerializeField] private float speedRotate = 2.0f;
    [SerializeField] private GameObject modelPlayer = null;

    #region ControlerVariable
    private float speed = 0.0f;
    private float AnglesModelPlayerY = 0.0f;

    private float pivotY = 0.0f;
    private RaycastHit hit;
    private Quaternion RaycastQuatNormal;

    private Vector2 lerpMove = Vector2.zero;
    private Vector3 moveController = Vector3.zero;

    #endregion
    #region Animation
    [Header("Animation")]
    [SerializeField] private ProceduralAnimation proceduralAnimation = null;

    #endregion
    #endregion

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();
        InputManager.InputJoueur.Controller.Mouvement.Enable();
        InputManager.InputJoueur.Controller.CameraMouse.Enable();
        speed = walkSpeed;
        pivot = GameObject.FindWithTag("PivotCamera");
        pivotY = transform.eulerAngles.y;
        RaycastQuatNormal = transform.rotation;
        AnglesModelPlayerY = pivotY + Mathf.Atan2(lerpMove.x, lerpMove.y) * Mathf.Rad2Deg;
    }

    protected override void Update()
    {
        base.Update();
        Gravity();
        lerpMove = Vector2.Lerp(lerpMove, InputManager.InputJoueur.Controller.Mouvement.ReadValue<Vector2>(), Time.deltaTime * 12.0f);
        moveController = transform.TransformDirection(Vector3.right) * Time.deltaTime * speed * lerpMove.x;
        moveController += transform.TransformDirection(Vector3.forward) * Time.deltaTime * speed * lerpMove.y;
        moveController += new Vector3(0, base.gravityValue * Time.deltaTime * notGroundTime * base.gravityAcelerationMultipliyer, 0);
        characterControler.Move(moveController);   
               
        if(Mathf.Abs(lerpMove.magnitude) > 0.01f)
        {
            pivotY = transform.eulerAngles.y;
        }
        else
        {
            modelPlayer.transform.rotation = RaycastQuatNormal;
        }

        
        AnglesModelPlayerY = pivotY + Mathf.Atan2(lerpMove.x, lerpMove.y) * Mathf.Rad2Deg;

        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 4.0f))
        {
            Debug.DrawRay(transform.position, -Vector3.up, Color.red, 4.0f);
            RaycastQuatNormal = Quaternion.FromToRotation(Vector3.up, hit.normal) * Quaternion.Euler(0, AnglesModelPlayerY, 0);
        }
        else
        {
            RaycastQuatNormal = Quaternion.Euler(0, AnglesModelPlayerY, 0);
        }

        modelPlayer.transform.rotation = Quaternion.Lerp(modelPlayer.transform.rotation, RaycastQuatNormal, Time.deltaTime * speedRotate *0.5f);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,pivot.transform.eulerAngles.y,0), Time.deltaTime * speedRotate *0.5f); 
    }

    private void Gravity()
    {
        if(!characterControler.isGrounded)
        {
            notGroundTime += Time.deltaTime;
        }
        else
        {
            notGroundTime = 1.0f;
        }
        if(notGroundTime > 3.0f)
        {
            notGroundTime = 3.0f;
        }
    }
}
