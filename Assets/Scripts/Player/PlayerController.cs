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

    #region ControlerVariable
    private bool groundedPlayer = true;
    private float AnglesY = 0.0f;
    private RaycastHit hit;
    private Quaternion RaycastQuatNormal;

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
    }

    protected override void Update()
    {
        base.Update();
    }
}
