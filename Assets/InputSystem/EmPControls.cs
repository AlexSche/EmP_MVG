//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/InputSystem/EmPControls.inputactions
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

public partial class @EmPControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @EmPControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""EmPControls"",
    ""maps"": [
        {
            ""name"": ""Ingame"",
            ""id"": ""9254f47b-6edf-46d9-86e6-f1a6f6eb7d8f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""a5adae1d-653c-4f45-80e7-3678a9007687"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Camera"",
                    ""type"": ""Value"",
                    ""id"": ""fc9dd2bf-72f4-49d7-bc03-762536df480b"",
                    ""expectedControlType"": ""Delta"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""17ea12ce-2749-448d-b98d-c1c3eeb9bf74"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""a94f0e59-6df3-4998-af1d-eaa5aa262022"",
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
                    ""id"": ""efb595a3-f541-454f-9059-7fb211942379"",
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
                    ""id"": ""03e6b201-b0c2-4317-a4c5-a4c19f02d805"",
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
                    ""id"": ""cf4f1a5b-e6da-4899-93d8-9035a6c2fe3f"",
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
                    ""id"": ""12ee3ff8-c127-4f2f-b854-fde1a5787312"",
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
                    ""id"": ""a5e7574a-a340-44e3-bfe3-c3d6837ff70f"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Camera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea16d819-d3a7-417c-b593-d60dfb042c70"",
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
            ""name"": ""VR-LeftController"",
            ""id"": ""509e892b-a5e0-4568-b868-d05e95748231"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""a1711478-badf-4d84-8a3f-18fb7e101412"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""081b4a17-07eb-4333-a0ad-a945116602e3"",
                    ""path"": ""<XRController>{LeftHand}/{Primary2DAxis}"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone,ScaleVector2(x=0.5,y=0.5)"",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Ingame
        m_Ingame = asset.FindActionMap("Ingame", throwIfNotFound: true);
        m_Ingame_Move = m_Ingame.FindAction("Move", throwIfNotFound: true);
        m_Ingame_Camera = m_Ingame.FindAction("Camera", throwIfNotFound: true);
        m_Ingame_Jump = m_Ingame.FindAction("Jump", throwIfNotFound: true);
        // VR-LeftController
        m_VRLeftController = asset.FindActionMap("VR-LeftController", throwIfNotFound: true);
        m_VRLeftController_Move = m_VRLeftController.FindAction("Move", throwIfNotFound: true);
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

    // Ingame
    private readonly InputActionMap m_Ingame;
    private List<IIngameActions> m_IngameActionsCallbackInterfaces = new List<IIngameActions>();
    private readonly InputAction m_Ingame_Move;
    private readonly InputAction m_Ingame_Camera;
    private readonly InputAction m_Ingame_Jump;
    public struct IngameActions
    {
        private @EmPControls m_Wrapper;
        public IngameActions(@EmPControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Ingame_Move;
        public InputAction @Camera => m_Wrapper.m_Ingame_Camera;
        public InputAction @Jump => m_Wrapper.m_Ingame_Jump;
        public InputActionMap Get() { return m_Wrapper.m_Ingame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(IngameActions set) { return set.Get(); }
        public void AddCallbacks(IIngameActions instance)
        {
            if (instance == null || m_Wrapper.m_IngameActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_IngameActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
            @Camera.started += instance.OnCamera;
            @Camera.performed += instance.OnCamera;
            @Camera.canceled += instance.OnCamera;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
        }

        private void UnregisterCallbacks(IIngameActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
            @Camera.started -= instance.OnCamera;
            @Camera.performed -= instance.OnCamera;
            @Camera.canceled -= instance.OnCamera;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
        }

        public void RemoveCallbacks(IIngameActions instance)
        {
            if (m_Wrapper.m_IngameActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IIngameActions instance)
        {
            foreach (var item in m_Wrapper.m_IngameActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_IngameActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public IngameActions @Ingame => new IngameActions(this);

    // VR-LeftController
    private readonly InputActionMap m_VRLeftController;
    private List<IVRLeftControllerActions> m_VRLeftControllerActionsCallbackInterfaces = new List<IVRLeftControllerActions>();
    private readonly InputAction m_VRLeftController_Move;
    public struct VRLeftControllerActions
    {
        private @EmPControls m_Wrapper;
        public VRLeftControllerActions(@EmPControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_VRLeftController_Move;
        public InputActionMap Get() { return m_Wrapper.m_VRLeftController; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(VRLeftControllerActions set) { return set.Get(); }
        public void AddCallbacks(IVRLeftControllerActions instance)
        {
            if (instance == null || m_Wrapper.m_VRLeftControllerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_VRLeftControllerActionsCallbackInterfaces.Add(instance);
            @Move.started += instance.OnMove;
            @Move.performed += instance.OnMove;
            @Move.canceled += instance.OnMove;
        }

        private void UnregisterCallbacks(IVRLeftControllerActions instance)
        {
            @Move.started -= instance.OnMove;
            @Move.performed -= instance.OnMove;
            @Move.canceled -= instance.OnMove;
        }

        public void RemoveCallbacks(IVRLeftControllerActions instance)
        {
            if (m_Wrapper.m_VRLeftControllerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IVRLeftControllerActions instance)
        {
            foreach (var item in m_Wrapper.m_VRLeftControllerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_VRLeftControllerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public VRLeftControllerActions @VRLeftController => new VRLeftControllerActions(this);
    public interface IIngameActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnCamera(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
    }
    public interface IVRLeftControllerActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
}
