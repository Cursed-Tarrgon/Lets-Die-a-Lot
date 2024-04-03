//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.3
//     from Assets/InputSystems/Player Input Actions.inputactions
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

public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Input Actions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""eb9889d3-4753-4753-9dec-877a9033ff50"",
            ""actions"": [
                {
                    ""name"": ""HandleMovementInput"",
                    ""type"": ""Value"",
                    ""id"": ""495f93a5-0dc3-457d-a984-08f399505729"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""HandleCameraInput"",
                    ""type"": ""Value"",
                    ""id"": ""480e4711-dd3e-4726-af8e-6889da414513"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""ae08140b-9602-4e7e-9fd2-073a6e482af7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Sprint"",
                    ""type"": ""Button"",
                    ""id"": ""9fe93728-4474-43a8-83de-91a7ce9901d5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""Button"",
                    ""id"": ""a4eee4d6-ced7-456b-9cda-be448f1c1b98"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""04c6863e-80a6-4001-9f45-ca52e0f54114"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""f42902e5-0a0c-497f-83d2-d2bd832decdc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Reload Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""1021bf3d-808e-4a28-b81a-9fe8e7dfde9e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""cad3c541-20f8-41db-99f5-46d65ea395a6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Join Action"",
                    ""type"": ""Button"",
                    ""id"": ""4ba61ca2-5cfc-443e-9f59-48ebae2829b9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Menu Move"",
                    ""type"": ""Value"",
                    ""id"": ""69785f56-a6eb-4a91-8909-b5146188e605"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Menu Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""850335bc-6dba-4127-86a7-03427f8fb0c2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c82f67c0-c1ad-412d-ae0e-ef46d5a2307e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Gamepad"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3429d24b-f6df-4cb4-ae0e-a54d60bd7f93"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Keyboard"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e64604a1-fc6e-4e4c-a8cf-05c226de8ea3"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Gamepad"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""98743b8b-897a-4fd8-b4af-f2d1f9f6ac90"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Keyboard"",
                    ""action"": ""Sprint"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""db800510-5d15-4e64-ade0-f6d6981e975e"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Gamepad"",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d6712156-f73a-4d0e-9e81-0971318b4bcf"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Keyboard"",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03e0c928-0591-40fa-b173-dd7a9aae3bb7"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone,ScaleVector2(x=5,y=4)"",
                    ""groups"": ""Player / Gamepad"",
                    ""action"": ""HandleCameraInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cc108f9a-e448-4c32-8d14-3291b7456069"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Keyboard"",
                    ""action"": ""HandleCameraInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8580e7a1-a84e-429c-be61-b2fa8da3fb84"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Gamepad"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7df1cf38-514d-4e8d-b7b1-9b4e98934b5b"",
                    ""path"": ""<Mouse>/press"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Keyboard"",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""43ad73e3-6acd-44ab-a80f-ef595db04847"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Gamepad"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""de488396-d470-439a-8195-c7811ee1fbbb"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Keyboard"",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0897adf5-554e-4676-ae6a-97c3b48ebac8"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Gamepad"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a3e15cb-ec59-494f-8104-88fff711b45f"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Keyboard"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac05acc4-a581-4a31-8be6-cbb83058ce75"",
                    ""path"": ""<Gamepad>/leftStickPress"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Gamepad"",
                    ""action"": ""Reload Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1a8cc9a6-f356-4594-a8bd-b6c89e660f18"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Gamepad"",
                    ""action"": ""Reload Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c8e19ec9-2f0f-4424-b713-f60fa6016b96"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Gamepad"",
                    ""action"": ""Reload Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e6e99e15-8ad7-447a-9ccd-d2a832eeab50"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Gamepad"",
                    ""action"": ""Reload Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f35efefd-4ca7-4664-85d9-ef0b377f22d2"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Gamepad"",
                    ""action"": ""Reload Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18e7705f-f30f-4f64-a54a-898019913dc3"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Gamepad"",
                    ""action"": ""Reload Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9cb28384-a373-4cfd-bbdc-a9849ad841cb"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Keyboard"",
                    ""action"": ""Reload Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""58890bb0-5daf-4436-a7ce-9acc099f3166"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Keyboard"",
                    ""action"": ""Reload Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed26be97-07d4-4e1a-8c50-914d1492f739"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Keyboard"",
                    ""action"": ""Reload Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3500b948-494f-44a3-a1f1-7c88886a2d2e"",
                    ""path"": ""<Keyboard>/g"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Keyboard"",
                    ""action"": ""Reload Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8014f24b-f2eb-403d-ab10-9258abb4c245"",
                    ""path"": ""<Keyboard>/leftShift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Keyboard"",
                    ""action"": ""Reload Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d99691e6-b188-4f34-809a-2bdae1007dc4"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": ""Player / Gamepad"",
                    ""action"": ""HandleMovementInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""846aca70-118d-4756-83d3-26f5797a1569"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HandleMovementInput"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""53571249-a1e6-4c64-bb4d-1667076ec1af"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Keyboard"",
                    ""action"": ""HandleMovementInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""eed11f0c-8e86-45c0-8cc6-f9c978d9b8be"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Keyboard"",
                    ""action"": ""HandleMovementInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""3ebabe9f-29e1-47a6-8bbc-1e315bfe63b6"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Keyboard"",
                    ""action"": ""HandleMovementInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""68567b82-9b8a-477e-ab7b-1bf49a80b7bd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Keyboard"",
                    ""action"": ""HandleMovementInput"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""c582899f-f6b4-426d-b68f-effc2e85a081"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Gamepad"",
                    ""action"": ""Join Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c9e0c34-a4d9-486d-8ee8-64030f8d146a"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Keyboard"",
                    ""action"": ""Join Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""842e3c5d-38cd-4b62-a634-8b47e274cbac"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Gamepad"",
                    ""action"": ""Menu Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a1be5a5-aa60-4dd0-926c-a7a2b258cc09"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Keyboard"",
                    ""action"": ""Menu Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""72cedf1c-e058-471b-8fed-aa65d679ff6a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e4509e16-d5c2-4d80-a7b7-57d443881dfb"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Keyboard"",
                    ""action"": ""Menu Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9706c451-fd36-4ec0-b399-2b31a5cb756c"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Keyboard"",
                    ""action"": ""Menu Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a0904129-bdaf-4288-9168-72e1c5ead7de"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Keyboard"",
                    ""action"": ""Menu Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ae4734ef-a612-4c7f-8f29-71b13e0cd086"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Keyboard"",
                    ""action"": ""Menu Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""D-Pad"",
                    ""id"": ""cdaea833-34f5-470c-abb3-1e2a0a9ed764"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Menu Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""5f0dd407-5eaa-4169-813c-7828ed9c0bca"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Gamepad"",
                    ""action"": ""Menu Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""e6a7ddf0-8d55-4ad8-858e-f8e45625230d"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Gamepad"",
                    ""action"": ""Menu Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cc86dba3-8b8a-47aa-bc75-e0e03f9532f7"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Gamepad"",
                    ""action"": ""Menu Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ee804e88-0266-46d1-8607-5695894740eb"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player / Gamepad"",
                    ""action"": ""Menu Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Player / Gamepad"",
            ""bindingGroup"": ""Player / Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Player / Keyboard"",
            ""bindingGroup"": ""Player / Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_HandleMovementInput = m_Player.FindAction("HandleMovementInput", throwIfNotFound: true);
        m_Player_HandleCameraInput = m_Player.FindAction("HandleCameraInput", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Sprint = m_Player.FindAction("Sprint", throwIfNotFound: true);
        m_Player_Zoom = m_Player.FindAction("Zoom", throwIfNotFound: true);
        m_Player_Shoot = m_Player.FindAction("Shoot", throwIfNotFound: true);
        m_Player_Reload = m_Player.FindAction("Reload", throwIfNotFound: true);
        m_Player_ReloadCancel = m_Player.FindAction("Reload Cancel", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_JoinAction = m_Player.FindAction("Join Action", throwIfNotFound: true);
        m_Player_MenuMove = m_Player.FindAction("Menu Move", throwIfNotFound: true);
        m_Player_MenuConfirm = m_Player.FindAction("Menu Confirm", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_HandleMovementInput;
    private readonly InputAction m_Player_HandleCameraInput;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Sprint;
    private readonly InputAction m_Player_Zoom;
    private readonly InputAction m_Player_Shoot;
    private readonly InputAction m_Player_Reload;
    private readonly InputAction m_Player_ReloadCancel;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_JoinAction;
    private readonly InputAction m_Player_MenuMove;
    private readonly InputAction m_Player_MenuConfirm;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @HandleMovementInput => m_Wrapper.m_Player_HandleMovementInput;
        public InputAction @HandleCameraInput => m_Wrapper.m_Player_HandleCameraInput;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Sprint => m_Wrapper.m_Player_Sprint;
        public InputAction @Zoom => m_Wrapper.m_Player_Zoom;
        public InputAction @Shoot => m_Wrapper.m_Player_Shoot;
        public InputAction @Reload => m_Wrapper.m_Player_Reload;
        public InputAction @ReloadCancel => m_Wrapper.m_Player_ReloadCancel;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @JoinAction => m_Wrapper.m_Player_JoinAction;
        public InputAction @MenuMove => m_Wrapper.m_Player_MenuMove;
        public InputAction @MenuConfirm => m_Wrapper.m_Player_MenuConfirm;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @HandleMovementInput.started += instance.OnHandleMovementInput;
            @HandleMovementInput.performed += instance.OnHandleMovementInput;
            @HandleMovementInput.canceled += instance.OnHandleMovementInput;
            @HandleCameraInput.started += instance.OnHandleCameraInput;
            @HandleCameraInput.performed += instance.OnHandleCameraInput;
            @HandleCameraInput.canceled += instance.OnHandleCameraInput;
            @Jump.started += instance.OnJump;
            @Jump.performed += instance.OnJump;
            @Jump.canceled += instance.OnJump;
            @Sprint.started += instance.OnSprint;
            @Sprint.performed += instance.OnSprint;
            @Sprint.canceled += instance.OnSprint;
            @Zoom.started += instance.OnZoom;
            @Zoom.performed += instance.OnZoom;
            @Zoom.canceled += instance.OnZoom;
            @Shoot.started += instance.OnShoot;
            @Shoot.performed += instance.OnShoot;
            @Shoot.canceled += instance.OnShoot;
            @Reload.started += instance.OnReload;
            @Reload.performed += instance.OnReload;
            @Reload.canceled += instance.OnReload;
            @ReloadCancel.started += instance.OnReloadCancel;
            @ReloadCancel.performed += instance.OnReloadCancel;
            @ReloadCancel.canceled += instance.OnReloadCancel;
            @Interact.started += instance.OnInteract;
            @Interact.performed += instance.OnInteract;
            @Interact.canceled += instance.OnInteract;
            @JoinAction.started += instance.OnJoinAction;
            @JoinAction.performed += instance.OnJoinAction;
            @JoinAction.canceled += instance.OnJoinAction;
            @MenuMove.started += instance.OnMenuMove;
            @MenuMove.performed += instance.OnMenuMove;
            @MenuMove.canceled += instance.OnMenuMove;
            @MenuConfirm.started += instance.OnMenuConfirm;
            @MenuConfirm.performed += instance.OnMenuConfirm;
            @MenuConfirm.canceled += instance.OnMenuConfirm;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @HandleMovementInput.started -= instance.OnHandleMovementInput;
            @HandleMovementInput.performed -= instance.OnHandleMovementInput;
            @HandleMovementInput.canceled -= instance.OnHandleMovementInput;
            @HandleCameraInput.started -= instance.OnHandleCameraInput;
            @HandleCameraInput.performed -= instance.OnHandleCameraInput;
            @HandleCameraInput.canceled -= instance.OnHandleCameraInput;
            @Jump.started -= instance.OnJump;
            @Jump.performed -= instance.OnJump;
            @Jump.canceled -= instance.OnJump;
            @Sprint.started -= instance.OnSprint;
            @Sprint.performed -= instance.OnSprint;
            @Sprint.canceled -= instance.OnSprint;
            @Zoom.started -= instance.OnZoom;
            @Zoom.performed -= instance.OnZoom;
            @Zoom.canceled -= instance.OnZoom;
            @Shoot.started -= instance.OnShoot;
            @Shoot.performed -= instance.OnShoot;
            @Shoot.canceled -= instance.OnShoot;
            @Reload.started -= instance.OnReload;
            @Reload.performed -= instance.OnReload;
            @Reload.canceled -= instance.OnReload;
            @ReloadCancel.started -= instance.OnReloadCancel;
            @ReloadCancel.performed -= instance.OnReloadCancel;
            @ReloadCancel.canceled -= instance.OnReloadCancel;
            @Interact.started -= instance.OnInteract;
            @Interact.performed -= instance.OnInteract;
            @Interact.canceled -= instance.OnInteract;
            @JoinAction.started -= instance.OnJoinAction;
            @JoinAction.performed -= instance.OnJoinAction;
            @JoinAction.canceled -= instance.OnJoinAction;
            @MenuMove.started -= instance.OnMenuMove;
            @MenuMove.performed -= instance.OnMenuMove;
            @MenuMove.canceled -= instance.OnMenuMove;
            @MenuConfirm.started -= instance.OnMenuConfirm;
            @MenuConfirm.performed -= instance.OnMenuConfirm;
            @MenuConfirm.canceled -= instance.OnMenuConfirm;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_PlayerGamepadSchemeIndex = -1;
    public InputControlScheme PlayerGamepadScheme
    {
        get
        {
            if (m_PlayerGamepadSchemeIndex == -1) m_PlayerGamepadSchemeIndex = asset.FindControlSchemeIndex("Player / Gamepad");
            return asset.controlSchemes[m_PlayerGamepadSchemeIndex];
        }
    }
    private int m_PlayerKeyboardSchemeIndex = -1;
    public InputControlScheme PlayerKeyboardScheme
    {
        get
        {
            if (m_PlayerKeyboardSchemeIndex == -1) m_PlayerKeyboardSchemeIndex = asset.FindControlSchemeIndex("Player / Keyboard");
            return asset.controlSchemes[m_PlayerKeyboardSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnHandleMovementInput(InputAction.CallbackContext context);
        void OnHandleCameraInput(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnSprint(InputAction.CallbackContext context);
        void OnZoom(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnReloadCancel(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnJoinAction(InputAction.CallbackContext context);
        void OnMenuMove(InputAction.CallbackContext context);
        void OnMenuConfirm(InputAction.CallbackContext context);
    }
}
