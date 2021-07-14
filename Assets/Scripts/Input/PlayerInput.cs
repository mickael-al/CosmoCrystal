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
                },
                {
                    ""name"": ""Abilite"",
                    ""type"": ""Button"",
                    ""id"": ""59856408-d493-48f5-9337-bc356c66fa0e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CameraMousePos"",
                    ""type"": ""Value"",
                    ""id"": ""ff76222f-6556-473c-aa91-01992ecedcef"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Inventaire"",
                    ""type"": ""Button"",
                    ""id"": ""c66c8e0b-6c5f-43cc-9387-fabba2901043"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Drop"",
                    ""type"": ""Button"",
                    ""id"": ""2d6d1b1a-1c71-4a7a-ad2c-2b7cd5dcdf1a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ActionSecondaire"",
                    ""type"": ""Button"",
                    ""id"": ""75f569d6-db03-4522-a665-09eac7bf6d67"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ChangeCameraDistance"",
                    ""type"": ""Button"",
                    ""id"": ""ba405bf8-9ab1-4912-8c87-94faa2153961"",
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
                    ""id"": ""430b5c6f-42b3-41b4-bc67-8585d1beced3"",
                    ""path"": ""<HID::Saitek AV8R Joystick>/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouvement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
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
                },
                {
                    ""name"": """",
                    ""id"": ""597f824b-5da6-45bd-ba3f-1cf86a69074c"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Abilite"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b91c08fe-db1f-4985-a0a4-a632cb84dd3e"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Abilite"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e176b159-13fc-408f-98eb-7806a9da9a1b"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""CameraMousePos"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""04e0f7f1-5712-4dc1-99fe-4795fbb33efa"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""Inventaire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b2f22a50-e886-4191-a19d-758399aab7eb"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Inventaire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1bde9940-239e-40cc-8f60-dd4e6da03d2e"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fee44565-22f7-49bb-928c-420d91cbd6d1"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Drop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""babddf6e-0ce6-449c-be89-5f5c7f7d354d"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""ActionSecondaire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""056ad6ed-c223-478e-993a-8595a244d29b"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ActionSecondaire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7c07954c-0c86-44b7-bedd-aea612b17dc2"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""ChangeCameraDistance"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71d8db79-51ee-4b0f-932a-accea3aff5d2"",
                    ""path"": ""<Gamepad>/rightStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""GamePad"",
                    ""action"": ""ChangeCameraDistance"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Debug"",
            ""id"": ""c19a6708-96b2-41f6-9bc6-573afce75129"",
            ""actions"": [
                {
                    ""name"": ""Mouvement"",
                    ""type"": ""Value"",
                    ""id"": ""654cd927-e790-4d97-90c4-965d457a9b53"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UP"",
                    ""type"": ""Button"",
                    ""id"": ""e76e639e-a3a1-4ff9-b1fb-c974074f42dd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""arrow"",
                    ""id"": ""d7783872-2df8-4e0a-9aa9-12fc42490d05"",
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
                    ""id"": ""385eae4c-6fcd-4da2-82d2-f12de0716ac1"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Mouvement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d2bb2214-5b25-46e1-ac45-1530f7fddc6c"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Mouvement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b879e1cc-fac7-4e2c-89ff-8fd2682ece9d"",
                    ""path"": ""<Keyboard>/h"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Mouvement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""89c6883e-9810-4b14-8fa7-af095f963e75"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Mouvement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""68da1bfd-a8f1-4261-b864-1e66760205dc"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UP"",
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
        m_Controller_Abilite = m_Controller.FindAction("Abilite", throwIfNotFound: true);
        m_Controller_CameraMousePos = m_Controller.FindAction("CameraMousePos", throwIfNotFound: true);
        m_Controller_Inventaire = m_Controller.FindAction("Inventaire", throwIfNotFound: true);
        m_Controller_Drop = m_Controller.FindAction("Drop", throwIfNotFound: true);
        m_Controller_ActionSecondaire = m_Controller.FindAction("ActionSecondaire", throwIfNotFound: true);
        m_Controller_ChangeCameraDistance = m_Controller.FindAction("ChangeCameraDistance", throwIfNotFound: true);
        // Debug
        m_Debug = asset.FindActionMap("Debug", throwIfNotFound: true);
        m_Debug_Mouvement = m_Debug.FindAction("Mouvement", throwIfNotFound: true);
        m_Debug_UP = m_Debug.FindAction("UP", throwIfNotFound: true);
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
    private readonly InputAction m_Controller_Abilite;
    private readonly InputAction m_Controller_CameraMousePos;
    private readonly InputAction m_Controller_Inventaire;
    private readonly InputAction m_Controller_Drop;
    private readonly InputAction m_Controller_ActionSecondaire;
    private readonly InputAction m_Controller_ChangeCameraDistance;
    public struct ControllerActions
    {
        private @PlayerInput m_Wrapper;
        public ControllerActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Mouvement => m_Wrapper.m_Controller_Mouvement;
        public InputAction @CameraMouse => m_Wrapper.m_Controller_CameraMouse;
        public InputAction @CameraGamePad => m_Wrapper.m_Controller_CameraGamePad;
        public InputAction @ActionPrincipale => m_Wrapper.m_Controller_ActionPrincipale;
        public InputAction @Abilite => m_Wrapper.m_Controller_Abilite;
        public InputAction @CameraMousePos => m_Wrapper.m_Controller_CameraMousePos;
        public InputAction @Inventaire => m_Wrapper.m_Controller_Inventaire;
        public InputAction @Drop => m_Wrapper.m_Controller_Drop;
        public InputAction @ActionSecondaire => m_Wrapper.m_Controller_ActionSecondaire;
        public InputAction @ChangeCameraDistance => m_Wrapper.m_Controller_ChangeCameraDistance;
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
                @Abilite.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnAbilite;
                @Abilite.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnAbilite;
                @Abilite.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnAbilite;
                @CameraMousePos.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnCameraMousePos;
                @CameraMousePos.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnCameraMousePos;
                @CameraMousePos.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnCameraMousePos;
                @Inventaire.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnInventaire;
                @Inventaire.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnInventaire;
                @Inventaire.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnInventaire;
                @Drop.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnDrop;
                @Drop.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnDrop;
                @Drop.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnDrop;
                @ActionSecondaire.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnActionSecondaire;
                @ActionSecondaire.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnActionSecondaire;
                @ActionSecondaire.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnActionSecondaire;
                @ChangeCameraDistance.started -= m_Wrapper.m_ControllerActionsCallbackInterface.OnChangeCameraDistance;
                @ChangeCameraDistance.performed -= m_Wrapper.m_ControllerActionsCallbackInterface.OnChangeCameraDistance;
                @ChangeCameraDistance.canceled -= m_Wrapper.m_ControllerActionsCallbackInterface.OnChangeCameraDistance;
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
                @Abilite.started += instance.OnAbilite;
                @Abilite.performed += instance.OnAbilite;
                @Abilite.canceled += instance.OnAbilite;
                @CameraMousePos.started += instance.OnCameraMousePos;
                @CameraMousePos.performed += instance.OnCameraMousePos;
                @CameraMousePos.canceled += instance.OnCameraMousePos;
                @Inventaire.started += instance.OnInventaire;
                @Inventaire.performed += instance.OnInventaire;
                @Inventaire.canceled += instance.OnInventaire;
                @Drop.started += instance.OnDrop;
                @Drop.performed += instance.OnDrop;
                @Drop.canceled += instance.OnDrop;
                @ActionSecondaire.started += instance.OnActionSecondaire;
                @ActionSecondaire.performed += instance.OnActionSecondaire;
                @ActionSecondaire.canceled += instance.OnActionSecondaire;
                @ChangeCameraDistance.started += instance.OnChangeCameraDistance;
                @ChangeCameraDistance.performed += instance.OnChangeCameraDistance;
                @ChangeCameraDistance.canceled += instance.OnChangeCameraDistance;
            }
        }
    }
    public ControllerActions @Controller => new ControllerActions(this);

    // Debug
    private readonly InputActionMap m_Debug;
    private IDebugActions m_DebugActionsCallbackInterface;
    private readonly InputAction m_Debug_Mouvement;
    private readonly InputAction m_Debug_UP;
    public struct DebugActions
    {
        private @PlayerInput m_Wrapper;
        public DebugActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Mouvement => m_Wrapper.m_Debug_Mouvement;
        public InputAction @UP => m_Wrapper.m_Debug_UP;
        public InputActionMap Get() { return m_Wrapper.m_Debug; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DebugActions set) { return set.Get(); }
        public void SetCallbacks(IDebugActions instance)
        {
            if (m_Wrapper.m_DebugActionsCallbackInterface != null)
            {
                @Mouvement.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnMouvement;
                @Mouvement.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnMouvement;
                @Mouvement.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnMouvement;
                @UP.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnUP;
                @UP.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnUP;
                @UP.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnUP;
            }
            m_Wrapper.m_DebugActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Mouvement.started += instance.OnMouvement;
                @Mouvement.performed += instance.OnMouvement;
                @Mouvement.canceled += instance.OnMouvement;
                @UP.started += instance.OnUP;
                @UP.performed += instance.OnUP;
                @UP.canceled += instance.OnUP;
            }
        }
    }
    public DebugActions @Debug => new DebugActions(this);
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
        void OnAbilite(InputAction.CallbackContext context);
        void OnCameraMousePos(InputAction.CallbackContext context);
        void OnInventaire(InputAction.CallbackContext context);
        void OnDrop(InputAction.CallbackContext context);
        void OnActionSecondaire(InputAction.CallbackContext context);
        void OnChangeCameraDistance(InputAction.CallbackContext context);
    }
    public interface IDebugActions
    {
        void OnMouvement(InputAction.CallbackContext context);
        void OnUP(InputAction.CallbackContext context);
    }
}
