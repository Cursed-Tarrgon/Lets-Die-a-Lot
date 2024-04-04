using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public TextMeshProUGUI TimeSurvived;
    public TextMeshProUGUI DeathCount;
    public TextMeshProUGUI KillCount;

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

            TimeSurvived.text = "Time Survived: " + timeInGame.ToString("0:00.00");

            if (deathCount < 10)
            {
                DeathCount.text = "Death Count: " + deathCount.ToString("0");
            }
            else if (deathCount > 10 && deathCount < 100)
            {
                DeathCount.text = "Death Count: " + deathCount.ToString("00");
            }
            else if (deathCount > 100)
            {
                DeathCount.text = "Death Count: " + deathCount.ToString("000");
            }
            if (killCount < 10)
            {
                KillCount.text = "Enemies Killed: " + killCount.ToString("0");
            }
            else if (killCount > 10 &&  killCount < 100)
            {
                KillCount.text = "Enemies Killed: " + killCount.ToString("00");
            }
            else if (killCount > 100 && killCount < 1000)
            {
                KillCount.text = "Enemies Killed: " + killCount.ToString("000");
            }
            else if (killCount > 1000 && killCount < 10000)
            {
                KillCount.text = "Enemies Killed: " + killCount.ToString("0000");
            }
            else if (killCount > 10000 && killCount < 100000)
            {
                KillCount.text = "Enemies Killed: " + killCount.ToString("00000");
            }
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
