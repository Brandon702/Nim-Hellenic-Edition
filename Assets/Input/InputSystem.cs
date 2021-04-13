// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputSystem.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputSystem : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputSystem()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputSystem"",
    ""maps"": [
        {
            ""name"": ""Main"",
            ""id"": ""9ae79157-631d-4e7e-964c-cffa1732ee3e"",
            ""actions"": [
                {
                    ""name"": ""Pause Game"",
                    ""type"": ""Button"",
                    ""id"": ""2dc5a1cc-5b18-4cc8-8069-f02974a79c3d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""25c969f3-9186-4977-bc21-64cbf89a8f01"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause Game"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23991f34-2826-4ff4-a482-809ed8cabefd"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause Game"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Game"",
            ""id"": ""fec36b9d-7850-411d-bd8c-e1792e4176cd"",
            ""actions"": [
                {
                    ""name"": ""Mouse"",
                    ""type"": ""Button"",
                    ""id"": ""4a610404-47c4-4f53-bb94-05b801898a55"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e1e42da4-60fd-456b-99a3-6f6e0791d23b"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mouse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Main
        m_Main = asset.FindActionMap("Main", throwIfNotFound: true);
        m_Main_PauseGame = m_Main.FindAction("Pause Game", throwIfNotFound: true);
        // Game
        m_Game = asset.FindActionMap("Game", throwIfNotFound: true);
        m_Game_Mouse = m_Game.FindAction("Mouse", throwIfNotFound: true);
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

    // Main
    private readonly InputActionMap m_Main;
    private IMainActions m_MainActionsCallbackInterface;
    private readonly InputAction m_Main_PauseGame;
    public struct MainActions
    {
        private @InputSystem m_Wrapper;
        public MainActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @PauseGame => m_Wrapper.m_Main_PauseGame;
        public InputActionMap Get() { return m_Wrapper.m_Main; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainActions set) { return set.Get(); }
        public void SetCallbacks(IMainActions instance)
        {
            if (m_Wrapper.m_MainActionsCallbackInterface != null)
            {
                @PauseGame.started -= m_Wrapper.m_MainActionsCallbackInterface.OnPauseGame;
                @PauseGame.performed -= m_Wrapper.m_MainActionsCallbackInterface.OnPauseGame;
                @PauseGame.canceled -= m_Wrapper.m_MainActionsCallbackInterface.OnPauseGame;
            }
            m_Wrapper.m_MainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @PauseGame.started += instance.OnPauseGame;
                @PauseGame.performed += instance.OnPauseGame;
                @PauseGame.canceled += instance.OnPauseGame;
            }
        }
    }
    public MainActions @Main => new MainActions(this);

    // Game
    private readonly InputActionMap m_Game;
    private IGameActions m_GameActionsCallbackInterface;
    private readonly InputAction m_Game_Mouse;
    public struct GameActions
    {
        private @InputSystem m_Wrapper;
        public GameActions(@InputSystem wrapper) { m_Wrapper = wrapper; }
        public InputAction @Mouse => m_Wrapper.m_Game_Mouse;
        public InputActionMap Get() { return m_Wrapper.m_Game; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameActions set) { return set.Get(); }
        public void SetCallbacks(IGameActions instance)
        {
            if (m_Wrapper.m_GameActionsCallbackInterface != null)
            {
                @Mouse.started -= m_Wrapper.m_GameActionsCallbackInterface.OnMouse;
                @Mouse.performed -= m_Wrapper.m_GameActionsCallbackInterface.OnMouse;
                @Mouse.canceled -= m_Wrapper.m_GameActionsCallbackInterface.OnMouse;
            }
            m_Wrapper.m_GameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Mouse.started += instance.OnMouse;
                @Mouse.performed += instance.OnMouse;
                @Mouse.canceled += instance.OnMouse;
            }
        }
    }
    public GameActions @Game => new GameActions(this);
    public interface IMainActions
    {
        void OnPauseGame(InputAction.CallbackContext context);
    }
    public interface IGameActions
    {
        void OnMouse(InputAction.CallbackContext context);
    }
}
