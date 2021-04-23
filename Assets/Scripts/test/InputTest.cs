using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{
    void Start()
    {     
        //InputManager.InputJoueur.Controller.Mouvement.performed += ctx => Mouvement(ctx.ReadValue<Vector2>());
    }

    /*void Mouvement(Vector2 move)
    {
        Debug.Log("Left : " + move);
    }*/

    private void OnEnable() {
        InputManager.InputJoueur.Controller.Mouvement.Enable();
        InputManager.InputJoueur.Controller.CameraMouse.Enable();
    }

    private void OnDisable() {
        InputManager.InputJoueur.Controller.Mouvement.Disable();
        InputManager.InputJoueur.Controller.CameraMouse.Disable();
    }

    /*private void Update() {
        Debug.Log("Right : " + InputManager.InputJoueur.Controller.CameraMouse.ReadValue<Vector2>());
        Debug.Log("Left : " + InputManager.InputJoueur.Controller.Mouvement.ReadValue<Vector2>());
    }*/
}
