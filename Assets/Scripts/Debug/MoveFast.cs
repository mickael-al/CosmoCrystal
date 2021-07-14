using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFast : MonoBehaviour
{
    [SerializeField] private float speedMove = 5.0f;
    void Update()
    {
        Vector2 convert = InputManager.InputJoueur.Debug.Mouvement.ReadValue<Vector2>();
        transform.position += transform.TransformDirection(new Vector3(convert.x,InputManager.InputJoueur.Debug.UP.ReadValue<float>(),convert.y)) * Time.deltaTime * speedMove;
    }
}
