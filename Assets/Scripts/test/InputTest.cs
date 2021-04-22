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
        InputManager.InputJoueur.Controller.Camera.Enable();
    }

    private void OnDisable() {
        InputManager.InputJoueur.Controller.Mouvement.Disable();
        InputManager.InputJoueur.Controller.Camera.Disable();
    }

    /*private void Update() {
        Debug.Log("Right : " + InputManager.InputJoueur.Controller.Camera.ReadValue<Vector2>());
        Debug.Log("Left : " + InputManager.InputJoueur.Controller.Mouvement.ReadValue<Vector2>());
    }*/
}
