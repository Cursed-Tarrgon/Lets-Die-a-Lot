using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.EventSystems;

public class MenuNav : MonoBehaviour
{
    public PlayerInput UIInput;
    public PlayerInputActions UIInputActions;
    public InputActionAsset inputAsset;
    public InputActionMap UI;
    public InputSystemUIInputModule InputSystemUIInputModule;
    public EventSystem eventSystem;

    public GameObject currentButton;
    public GameObject playBtn;
    public GameObject quitBtn;
    public GameObject mainmenuBtn;
    public GameObject replayBtn;

    float time;

    private bool isPressed;

    private void Awake()
    {
        isPressed = false;
    }

    private void OnDisable()
    {
        UI.FindAction("Menu Confirm").performed -= ButtonPress;
        UI.FindAction("Menu Confirm").canceled -= ButtonPress;
    }

    public void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        isPressed = false;

        UIInput = GetComponent<PlayerInput>();
        UIInputActions = new PlayerInputActions();
        inputAsset = gameObject.GetComponent<PlayerInput>().actions;
        UI = inputAsset.FindActionMap("Player");

        UI.FindAction("Menu Confirm").performed += ButtonPress;
        UI.FindAction("Menu Confirm").canceled += ButtonPress;

        time = 0f;
    }

    public void Update()
    {
        time += Time.deltaTime;

        if (time >= 0.5f)
        {
            currentButton = eventSystem.currentSelectedGameObject;

            if (eventSystem.currentSelectedGameObject == playBtn)
            {
                if (isPressed && SceneManager.GetActiveScene().name == "MainMenu")
                {
                    SceneManager.LoadScene("Intro");
                }
                else if (isPressed && SceneManager.GetActiveScene().name == "Intro")
                {
                    SceneManager.LoadScene("Game");
                }
            }
            else if (eventSystem.currentSelectedGameObject == quitBtn)
            {
                if (isPressed)
                {
                    Application.Quit();
                }
            }
            else if (eventSystem.currentSelectedGameObject == mainmenuBtn)
            {
                if (isPressed)
                {
                    SceneManager.LoadScene("MainMenu");
                }
            }
            else if (eventSystem.currentSelectedGameObject == replayBtn)
            {
                if (isPressed)
                {
                    SceneManager.LoadScene("Game");
                }
            }
        }
    }

    public void ButtonPress(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isPressed = true;
        }

        if (context.canceled)
        {
            isPressed = false;
        }
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
