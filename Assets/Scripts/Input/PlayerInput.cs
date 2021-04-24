// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/PlayerInput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""Controller"",
            ""id"": ""d55771b6-5579-4a6d-a381-161bbbed337a"",
            ""actions"": [
                {
                    ""name"": ""Mouvement"",
                    ""type"": ""Value"",
                    ""id"": ""73bfa560-5465-454f-b244-18c97588df45"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraMouse"",
                    ""type"": ""Value"",
                    ""id"": ""28653ddb-b6e0-445f-a0c3-be1f54d33cab"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraGamePad"",
                    ""type"": ""Value"",
                    ""id"": ""830c29a5-6d6a-4108-b6ad-6667c41be629"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ActionPrincipale"",
                    ""type"": ""Button"",
                    ""id"": ""759088ea-c896-4855-915e-12d8e717ee0e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f57000ef-5f56-48c0-87f5-e26416a9ca62"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""CameraMouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8afc036-1d98-4b04-8414-f3695151e0df"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Mouvement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""arrow"",
                    ""id"": ""c9e54088-b1d6-4076-a0fe-d7bc1c266dae"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouvement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""286f2d90-3990-4b0e-9bf1-172a533a2816"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Mouvement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0a466573-772f-46e0-b1a9-d2f45302c3ca"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Mouvement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fd2188ba-393a-4b15-af4b-3ea119c44880"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Mouvement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a7b16e0a-e255-40e8-b494-7972919ce3cf"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Mouvement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5ec3f3be-2509-4c5c-a54d-92b2645159de"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""CameraGamePad"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b6817e96-9c47-4616-a1a5-5633463f56e9"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""ActionPrincipale"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd93b9c8-5461-469b-99e3-ac618f12926b"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""ActionPrincipale"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""GamePad"",
            ""bindingGroup"": ""GamePad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Controller
        m_Controller = asset.FindActionMap("Controller", throwIfNotFound: true);
        m_Controller_Mouvement = m_Controller.FindAction("Mouvement", throwIfNotFound: true);
        m_Controller_CameraMouse = m_Controller.FindAction("CameraMouse", throwIfNotFound: true);
        m_Controller_CameraGamePad = m_Controller.FindAction("CameraGamePad", throwIfNotFound: true);
        m_Controller_ActionPrincipale = m_Controller.FindAction("ActionPrincipale", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Controller
    private readonly InputActionMap m_Controller;
    private IControllerActions m_ControllerActionsCallbackInterface;
    private readonly InputAction m_Controller_Mouvement;
    private readonly InputAction m_Controller_CameraMouse;
    private readonly InputAction m_Controller_CameraGamePad;
    private readonly InputAction m_Controller_ActionPrincipale;
    public struct ControllerActions
    {
        private @PlayerInput m_Wrapper;
        public ControllerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Mouvement => m_Wrapper.m_Controller_Mouvement;
        public InputAction @CameraMouse => m_Wrapper.m_Controller_CameraMouse;
        public InputAction @CameraGamePad => m_Wrapper.m_Controller_CameraGamePad;
        public InputAction @ActionPrincipale => m_Wrapper.m_Controller_ActionPrincipale;
        public InputActionMap Get() { return m_Wrapper.m_Controller; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ControllerActions set) { return set.Get(); }
        public void SetCallbacks(IControllerActions instance)
        {
            if (m_Wrapper.m_ControllerActionsCallbackInterface != null)
            {
                @Mouvement.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnMouvement;
                @Mouvement.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnMouvement;
                @Mouvement.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnMouvement;
                @CameraMouse.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnCameraMouse;
                @CameraMouse.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnCameraMouse;
                @CameraMouse.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnCameraMouse;
                @CameraGamePad.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnCameraGamePad;
                @CameraGamePad.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnCameraGamePad;
                @CameraGamePad.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnCameraGamePad;
                @ActionPrincipale.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnActionPrincipale;
                @ActionPrincipale.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnActionPrincipale;
                @ActionPrincipale.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnActionPrincipale;
            }
            m_Wrapper.m_ControllerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Mouvement.started += instance.OnMouvement;
                @Mouvement.performed += instance.OnMouvement;
                @Mouvement.canceled += instance.OnMouvement;
                @CameraMouse.started += instance.OnCameraMouse;
                @CameraMouse.performed += instance.OnCameraMouse;
                @CameraMouse.canceled += instance.OnCameraMouse;
                @CameraGamePad.started += instance.OnCameraGamePad;
                @CameraGamePad.performed += instance.OnCameraGamePad;
                @CameraGamePad.canceled += instance.OnCameraGamePad;
                @ActionPrincipale.started += instance.OnActionPrincipale;
                @ActionPrincipale.performed += instance.OnActionPrincipale;
                @ActionPrincipale.canceled += instance.OnActionPrincipale;
            }
        }
    }
    public ControllerActions @Controller => new ControllerActions(this);
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    private int m_GamePadSchemeIndex = -1;
    public InputControlScheme GamePadScheme
    {
        get
        {
            if (m_GamePadSchemeIndex == -1) m_GamePadSchemeIndex = asset.FindControlSchemeIndex("GamePad");
            return asset.controlSchemes[m_GamePadSchemeIndex];
        }
    }
    public interface IControllerActions
    {
        void OnMouvement(InputAction.CallbackContext context);
        void OnCameraMouse(InputAction.CallbackContext context);
        void OnCameraGamePad(InputAction.CallbackContext context);
        void OnActionPrincipale(InputAction.CallbackContext context);
    }
}
