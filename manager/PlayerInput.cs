//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/manager/PlayerInput.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInput"",
    ""maps"": [
        {
            ""name"": ""PlayerBattleInput"",
            ""id"": ""1e1e0446-01d5-41b9-b9c3-5d0c97751721"",
            ""actions"": [
                {
                    ""name"": ""BattleOptionsScroll"",
                    ""type"": ""Button"",
                    ""id"": ""e1586c84-7464-4fc7-b0e6-3b318e20eb64"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""TargetPosition"",
                    ""type"": ""Value"",
                    ""id"": ""8543c811-3418-4642-bd9e-ee4789bc3775"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SelectItem"",
                    ""type"": ""Button"",
                    ""id"": ""e594c38d-48ce-4656-86a8-837065ba2fba"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""YesOrNot"",
                    ""type"": ""Button"",
                    ""id"": ""faacadd8-a482-4575-92b4-2efe93bd1f08"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ShiftItemMenu"",
                    ""type"": ""Button"",
                    ""id"": ""7194ed7b-f05c-4696-bfaf-88b7cb959c65"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bdd5bf08-6ae5-48b3-bb18-58dd7d4ad9fb"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TargetPosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""43c4ac76-84ee-4ac1-aecb-1b0127b71f52"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24883b7d-dfac-4eb3-ba3c-be3b24c26cd6"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eee56659-ad9e-453e-b000-11498608079e"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aa9c3e7b-8a21-4f37-a781-a5fddb1366b1"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""51d782dd-3f99-413e-b20f-fc0faee0f35c"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""8b599d9f-f9af-454c-ade0-b20efdb32615"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YesOrNot"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0da20216-8c74-491a-982c-0622a8868264"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YesOrNot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""68ab1968-774e-4338-b5b8-c7a5b88ddad1"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""YesOrNot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Shift"",
                    ""id"": ""fad2b882-9ea1-4536-aa72-dc55f50d2f14"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShiftItemMenu"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c802e36c-efdf-4298-802e-6b8282295e88"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShiftItemMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""b7913177-2890-4271-8dbc-91d9242b1eb1"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ShiftItemMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Scroll"",
                    ""id"": ""86d7b167-acd3-40d3-9a44-58140666978f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BattleOptionsScroll"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""351b0f0c-1cfa-4abf-afb7-3532cb03a801"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BattleOptionsScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""735f6b6d-b65c-4622-a10d-02676bd7a9d2"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BattleOptionsScroll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""PlayerDefaultInput"",
            ""id"": ""8a2f0904-568f-4fa1-84b5-8ac13a1237d5"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""ff8b5fa0-7cbd-428c-b08d-f23d0b0c4792"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""fc8e5300-f6fb-4e70-b17d-a95c7dc3dcec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""c993c611-2836-4d96-b3db-ceba19943373"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""b5db1424-e92d-411e-9e77-7fa9571adb35"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ddd0d028-c942-4e3b-be8b-d6dbb0314e51"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6fe4d8c3-760d-469a-8aa9-62b6d5d28b29"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""8be29344-3bb9-474b-b214-b80cd01d83d9"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1bb04e5f-c632-49a6-a597-eb68cb647a58"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PlayerMenuInput"",
            ""id"": ""8c315c51-bc6c-4aac-b326-ec964175c2cb"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""667bc80d-7966-4e5e-ab9e-c18204614d46"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b3d44a43-31ca-461c-9455-61ec1b931397"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerBattleInput
        m_PlayerBattleInput = asset.FindActionMap("PlayerBattleInput", throwIfNotFound: true);
        m_PlayerBattleInput_BattleOptionsScroll = m_PlayerBattleInput.FindAction("BattleOptionsScroll", throwIfNotFound: true);
        m_PlayerBattleInput_TargetPosition = m_PlayerBattleInput.FindAction("TargetPosition", throwIfNotFound: true);
        m_PlayerBattleInput_SelectItem = m_PlayerBattleInput.FindAction("SelectItem", throwIfNotFound: true);
        m_PlayerBattleInput_YesOrNot = m_PlayerBattleInput.FindAction("YesOrNot", throwIfNotFound: true);
        m_PlayerBattleInput_ShiftItemMenu = m_PlayerBattleInput.FindAction("ShiftItemMenu", throwIfNotFound: true);
        // PlayerDefaultInput
        m_PlayerDefaultInput = asset.FindActionMap("PlayerDefaultInput", throwIfNotFound: true);
        m_PlayerDefaultInput_Move = m_PlayerDefaultInput.FindAction("Move", throwIfNotFound: true);
        m_PlayerDefaultInput_Jump = m_PlayerDefaultInput.FindAction("Jump", throwIfNotFound: true);
        // PlayerMenuInput
        m_PlayerMenuInput = asset.FindActionMap("PlayerMenuInput", throwIfNotFound: true);
        m_PlayerMenuInput_Newaction = m_PlayerMenuInput.FindAction("New action", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // PlayerBattleInput
    private readonly InputActionMap m_PlayerBattleInput;
    private List<IPlayerBattleInputActions> m_PlayerBattleInputActionsCallbackInterfaces = new List<IPlayerBattleInputActions>();
    private readonly InputAction m_PlayerBattleInput_BattleOptionsScroll;
    private readonly InputAction m_PlayerBattleInput_TargetPosition;
    private readonly InputAction m_PlayerBattleInput_SelectItem;
    private readonly InputAction m_PlayerBattleInput_YesOrNot;
    private readonly InputAction m_PlayerBattleInput_ShiftItemMenu;
    public struct PlayerBattleInputActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerBattleInputActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @BattleOptionsScroll => m_Wrapper.m_PlayerBattleInput_BattleOptionsScroll;
        public InputAction @TargetPosition => m_Wrapper.m_PlayerBattleInput_TargetPosition;
        public InputAction @SelectItem => m_Wrapper.m_PlayerBattleInput_SelectItem;
        public InputAction @YesOrNot => m_Wrapper.m_PlayerBattleInput_YesOrNot;
        public InputAction @ShiftItemMenu => m_Wrapper.m_PlayerBattleInput_ShiftItemMenu;
        public InputActionMap Get() { return m_Wrapper.m_PlayerBattleInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerBattleInputActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerBattleInputActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerBattleInputActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerBattleInputActionsCallbackInterfaces.Add(instance);
            @BattleOptionsScroll.started += instance.OnBattleOptionsScroll;
            @BattleOptionsScroll.performed += instance.OnBattleOptionsScroll;
            @BattleOptionsScroll.canceled += instance.OnBattleOptionsScroll;
            @TargetPosition.started += instance.OnTargetPosition;
            @TargetPosition.performed += instance.OnTargetPosition;
            @TargetPosition.canceled += instance.OnTargetPosition;
            @SelectItem.started += instance.OnSelectItem;
            @SelectItem.performed += instance.OnSelectItem;
            @SelectItem.canceled += instance.OnSelectItem;
            @YesOrNot.started += instance.OnYesOrNot;
            @YesOrNot.performed += instance.OnYesOrNot;
            @YesOrNot.canceled += instance.OnYesOrNot;
            @ShiftItemMenu.started += instance.OnShiftItemMenu;
            @ShiftItemMenu.performed += instance.OnShiftItemMenu;
            @ShiftItemMenu.canceled += instance.OnShiftItemMenu;
        }

        private void UnregisterCallbacks(IPlayerBattleInputActions instance)
        {
            @BattleOptionsScroll.started -= instance.OnBattleOptionsScroll;
            @BattleOptionsScroll.performed -= instance.OnBattleOptionsScroll;
            @BattleOptionsScroll.canceled -= instance.OnBattleOptionsScroll;
            @TargetPosition.started -= instance.OnTargetPosition;
            @TargetPosition.performed -= instance.OnTargetPosition;
            @TargetPosition.canceled -= instance.OnTargetPosition;
            @SelectItem.started -= instance.OnSelectItem;
            @SelectItem.performed -= instance.OnSelectItem;
            @SelectItem.canceled -= instance.OnSelectItem;
            @YesOrNot.started -= instance.OnYesOrNot;
            @YesOrNot.performed -= instance.OnYesOrNot;
            @YesOrNot.canceled -= instance.OnYesOrNot;
            @ShiftItemMenu.started -= instance.OnShiftItemMenu;
            @ShiftItemMenu.performed -= instance.OnShiftItemMenu;
            @ShiftItemMenu.canceled -= instance.OnShiftItemMenu;
        }

        public void RemoveCallbacks(IPlayerBattleInputActions instance)
        {
            if (m_Wrapper.m_PlayerBattleInputActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerBattleInputActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerBattleInputActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerBattleInputActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerBattleInputActions @PlayerBattleInput => new PlayerBattleInputActions(this);

    // PlayerDefaultInput
    private readonly InputActionMap m_PlayerDefaultInput;
    private List<IPlayerDefaultInputActions> m_PlayerDefaultInputActionsCallbackInterfaces = new List<IPlayerDefaultInputActions>();
    private readonly InputAction m_PlayerDefaultInput_Move;
    private readonly InputAction m_PlayerDefaultInput_Jump;
    public struct PlayerDefaultInputActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerDefaultInputActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerDefaultInput_Move;
        public InputAction @Jump => m_Wrapper.m_PlayerDefaultInput_Jump;
        public InputActionMap Get() { return m_Wrapper.m_PlayerDefaultInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerDefaultInputActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerDefaultInputActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerDefaultInputActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerDefaultInputActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
        }

        private void UnregisterCallbacks(IPlayerDefaultInputActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
        }

        public void RemoveCallbacks(IPlayerDefaultInputActions instance)
        {
            if (m_Wrapper.m_PlayerDefaultInputActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerDefaultInputActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerDefaultInputActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerDefaultInputActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerDefaultInputActions @PlayerDefaultInput => new PlayerDefaultInputActions(this);

    // PlayerMenuInput
    private readonly InputActionMap m_PlayerMenuInput;
    private List<IPlayerMenuInputActions> m_PlayerMenuInputActionsCallbackInterfaces = new List<IPlayerMenuInputActions>();
    private readonly InputAction m_PlayerMenuInput_Newaction;
    public struct PlayerMenuInputActions
    {
        private @PlayerInput m_Wrapper;
        public PlayerMenuInputActions(@PlayerInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_PlayerMenuInput_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_PlayerMenuInput; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerMenuInputActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerMenuInputActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerMenuInputActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerMenuInputActionsCallbackInterfaces.Add(instance);
            @Newaction.started += instance.OnNewaction;
            @Newaction.performed += instance.OnNewaction;
            @Newaction.canceled += instance.OnNewaction;
        }

        private void UnregisterCallbacks(IPlayerMenuInputActions instance)
        {
            @Newaction.started -= instance.OnNewaction;
            @Newaction.performed -= instance.OnNewaction;
            @Newaction.canceled -= instance.OnNewaction;
        }

        public void RemoveCallbacks(IPlayerMenuInputActions instance)
        {
            if (m_Wrapper.m_PlayerMenuInputActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerMenuInputActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerMenuInputActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerMenuInputActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerMenuInputActions @PlayerMenuInput => new PlayerMenuInputActions(this);
    public interface IPlayerBattleInputActions
    {
        void OnBattleOptionsScroll(InputAction.CallbackContext context);
        void OnTargetPosition(InputAction.CallbackContext context);
        void OnSelectItem(InputAction.CallbackContext context);
        void OnYesOrNot(InputAction.CallbackContext context);
        void OnShiftItemMenu(InputAction.CallbackContext context);
    }
    public interface IPlayerDefaultInputActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface IPlayerMenuInputActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
