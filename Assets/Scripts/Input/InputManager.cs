using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance = null;
    #region  InputAction
    [SerializeField] private PlayerInput playerInput = null;

    #endregion
    #region Get
    public static PlayerInput InputJoueur{
        get{
            return instance.playerInput;
        }
    }
    #endregion

    private void Awake() {
        instance = this;
        playerInput = new PlayerInput();
    }

    private void OnEnable() {
        /*playerInput.Controller.Mouvement.Enable();
        playerInput.Controller.CameraMouse.Enable();
        playerInput.Controller.CameraMousePos.Enable();
        playerInput.Controller.CameraGamePad.Enable();
        playerInput.Controller.ActionPrincipale.Enable();
        playerInput.Controller.Abilite.Enable();*/
        playerInput.Enable();
    }
    private void OnDisable() {
        /*playerInput.Controller.Mouvement.Disable();
        playerInput.Controller.CameraMouse.Disable();
        playerInput.Controller.CameraGamePad.Disable();
        playerInput.Controller.ActionPrincipale.Disable();*/
    }
}
