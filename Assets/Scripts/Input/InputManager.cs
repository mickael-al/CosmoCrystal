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
}
