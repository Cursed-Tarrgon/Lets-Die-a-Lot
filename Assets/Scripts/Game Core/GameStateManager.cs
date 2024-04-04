using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    [Header("Game References")]
    public GameObject GameCamera;

    [Header("Player References")]
    public List<FirstPersonController> players;
    public GameObject PlayerPrefab;
    public GameObject Player;
    public FirstPersonController firstPersonController;
    public ProjectileSystem fpcGun;
    public UiController uiController;

    [Header("Player Stats")]
    public int killCount;
    public int deathCount;

    [Header("Death Upgrades")]
    public GameObject SpawnPoint;
    public float healthUpgrade;
    public float staminaUpgrade;
    public float speedUpgrade;
    public int ammoUpgrade;
    public float damageUpgrade;
    public float reloadSpeedUpgrade;
    public float bulletSpreadUpgrade;
    public float firerateUpgrade;
    public float maxEnemyCountIncrease;
    public float spawnEnemyCountDecrease;

    [Header("Enemy Stats")]
    public List<EnemyAiController> Enemies;
    public GameObject EnemyPrefab;
    public float regularEnemyHealth;
    public float regularEnemySpeed;
    public float regularEnemyDamage;

    [Header("Spawning References")]
    public List<GameObject> Spawners;
    public float maxEnemyCount;
    public float currentEnemyCount;
    public float timeBetweenEnemySpawning;

    [Header("Game Objectives")]
    public float timeInGame;
    public float maxTimeInGame;
    public float timeTillEnd;
    public bool canWinLose;
    public static bool hasWon = false;
    public static bool hasLost = false;

    private DataHolder dataHolder;

    //Debug
    public bool DebugSpawnEnemy;

    private static GameStateManager instance;

    public static GameStateManager Instance
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
    }

    private void Start()
    {
        hasLost = false;
        hasWon = false;
        timeInGame = 0f;
        timeTillEnd = maxTimeInGame;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (dataHolder == null)
        {
            dataHolder = GameObject.FindGameObjectWithTag("Data Holder").GetComponent<DataHolder>();
        }

        if (players.Count == 0)
        {
            GameCamera.SetActive(true);
        }
        else if (players.Count == 1)
        {
            GameCamera.SetActive(false);
        }

        if (firstPersonController != null)
        {
            if (firstPersonController.isDead)
            {
                Invoke(nameof(PlayerDied), 0f);
            }
            else if (!firstPersonController.isDead)
            {
                SpawnEnemies();
            }

            if (timeTillEnd <= 0f)
            {
                hasLost = true;
            }
            else
            {
                timeInGame += Time.deltaTime;
                timeTillEnd -= Time.deltaTime;
            }
        }

        if (canWinLose)
        {
            if (hasWon)
            {
                WinGame();
            }

            if (hasLost)
            {
                LoseGame();
            }
        }

        if (DebugSpawnEnemy)
        {
            InstantiateEnemy();

            DebugSpawnEnemy = false;
        }
    }

    private void WinGame()
    {
        dataHolder.win = true;
        dataHolder.timeInGame = timeInGame;
        dataHolder.deathCount = deathCount;
        dataHolder.killCount = killCount;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene("Game Over");
    }

    private void LoseGame()
    {
        dataHolder.lose = true;
        dataHolder.timeInGame = timeInGame;
        dataHolder.deathCount = deathCount;
        dataHolder.killCount = killCount;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene("Game Over");
    }

    public void AddPlayer(FirstPersonController player)
    {
        players.Add(player);
    }

    public void RemovePlayer(FirstPersonController player)
    {
        players.Remove(player);
    }

    public void AddEnemy(EnemyAiController enemy)
    {
        Enemies.Add(enemy);
    }

    public void RemoveEnemy(EnemyAiController enemy)
    {
        Enemies.Remove(enemy);
    }

    public void PlayerDied()
    {
        firstPersonController.isDead = false;

        deathCount++;

        foreach (EnemyAiController enemy in Enemies)
        {
            enemy.Reset = true;
        }

        firstPersonController.maxHealth *= healthUpgrade;
        firstPersonController.health = firstPersonController.maxHealth;
        uiController.playerHealthSlider.maxValue = firstPersonController.maxHealth;
        uiController.playerHealthSlider.value = firstPersonController.health;
        firstPersonController.maxStamina *= staminaUpgrade;
        firstPersonController.currentStamina = firstPersonController.maxStamina;
        uiController.playerStaminaSlider.maxValue = firstPersonController.maxStamina;
        uiController.playerStaminaSlider.value = firstPersonController.currentStamina;

        if (firstPersonController.walkSpeed < 10f)
        {
            firstPersonController.walkSpeed += speedUpgrade;
        }

        if (firstPersonController.sprintSpeed < 15f)
        {
            firstPersonController.sprintSpeed += speedUpgrade;
        }

        fpcGun.maxAmmoSize *= ammoUpgrade;
        fpcGun.maxClipSize *= ammoUpgrade;
        fpcGun.PickUpAmmo();
        fpcGun.damage *= damageUpgrade;

        if (fpcGun.reloadTime > 0f)
        {
            fpcGun.reloadTime -= reloadSpeedUpgrade;
        }

        if (fpcGun.spread > 0f)
        {
            fpcGun.spread -= bulletSpreadUpgrade;
        }
        
        if (fpcGun.firerate > 0.1f)
        {
            fpcGun.firerate -= firerateUpgrade;
        }

        maxEnemyCount *= maxEnemyCountIncrease;

        if (timeBetweenEnemySpawning > 0.1f)
        {
            timeBetweenEnemySpawning -= spawnEnemyCountDecrease;
        }

        currentEnemyCount = 0;
    }

    public void SpawnEnemies()
    {
        if (currentEnemyCount < maxEnemyCount)
        {
            Invoke(nameof(InstantiateEnemy), timeBetweenEnemySpawning);
        }
    }

    private void InstantiateEnemy()
    {
        if (currentEnemyCount < maxEnemyCount)
        {
            int randomSpawner = Random.Range(0, Spawners.Count - 1);

            Instantiate(EnemyPrefab, Spawners[randomSpawner].transform.position, Quaternion.identity);
        }
    }
}
