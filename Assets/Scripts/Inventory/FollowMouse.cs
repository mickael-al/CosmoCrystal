using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private void OnEnable() {
        transform.position = InputManager.InputJoueur.Controller.CameraMousePos.ReadValue<Vector2>();    
    }
    void Update()
    {
        transform.position = InputManager.InputJoueur.Controller.CameraMousePos.ReadValue<Vector2>();
    }
}
