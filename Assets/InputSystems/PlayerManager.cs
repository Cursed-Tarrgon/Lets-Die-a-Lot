using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private List<PlayerInput> players;
    [SerializeField] private List<GameObject> startingPoints;
    public List<GameObject> Spawners;

    private PlayerInputManager playerInputManager;

    private static PlayerManager playerManagerInstance;

    public static PlayerManager PlayerManagerInstance
    {
        get { return playerManagerInstance; }
    }

    private void Awake()
    {
        if (playerManagerInstance == null)
        {
            playerManagerInstance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        playerInputManager = gameObject.GetComponent<PlayerInputManager>();
    }

    public void Update()
    {
        if (GameStateManager.Instance.firstPersonController == null)
        {
            playerInputManager.playerPrefab = GameStateManager.Instance.PlayerPrefab;
        }

        if (playerInputManager.playerCount == 1)
        {
            playerInputManager.DisableJoining();
        }
        else
        {
            playerInputManager.EnableJoining();
        }
    }

    public void OnPlayerJoined(PlayerInput player)
    {
        players.Add(player);

        player.transform.position = startingPoints[players.Count - 1].transform.position;
    }

    public void OnPlayerLeft(PlayerInput player)
    {
        players.Remove(player);

        GameStateManager.Instance.players.Remove(player.GetComponent<FirstPersonController>());
    }
}