using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DataHolder : MonoBehaviour
{
    public float timeInGame;
    public float deathCount;
    public float killCount;

    public bool win;
    public bool lose;

    public GameObject Canvas;

    public PlayerInput UIInput;
    public MenuNav MenuNav;

    public GameObject WinSceneCanvas;
    public GameObject LoseSceneCanvas;

    private static DataHolder instance;

    public static DataHolder Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
        DontDestroyOnLoad(this.gameObject);
    }
   
    public void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            win = false;
            lose = false;
            Destroy(this.gameObject);
        }

        if (SceneManager.GetActiveScene().name == "Game Over")
        {
            Canvas.SetActive(true);
            MenuNav.enabled = true;
            UIInput.enabled = true;
        }

        if (win)
        {
            WinSceneCanvas.SetActive(true);
        }

        if (lose)
        {
            LoseSceneCanvas.SetActive(true);
        }
    }
}
