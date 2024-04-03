using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiController : MonoBehaviour
{
    [Header("References")]
    public FirstPersonController firstPersonController;
    public float displayHealth;
    public GameObject playerHealthBar;
    public Slider playerHealthSlider;
    public GameObject playerStaminaBar;
    public Slider playerStaminaSlider;
    public TextMeshProUGUI ammoCount;

    private void Start()
    {
        if (GameStateManager.Instance.uiController == null)
        {
            GameStateManager.Instance.uiController = this;
        }
    }

    private void Update()
    {
        if (firstPersonController == null)
        {
            firstPersonController = GameStateManager.Instance.firstPersonController;
        }

        if (firstPersonController != null && playerStaminaSlider != null && playerHealthSlider != null)
        {
            playerHealthSlider.maxValue = firstPersonController.maxHealth;
            playerStaminaSlider.maxValue = firstPersonController.maxStamina;
        }

        if (firstPersonController != null)
        {
            UpdateHealth(firstPersonController.health);
            ammoCount.SetText(firstPersonController.Weapon.currentClipSize / firstPersonController.Weapon.bulletsPerTap + " / " + firstPersonController.Weapon.currentAmmoSize / firstPersonController.Weapon.bulletsPerTap);
        }
    }

    private void OnEnable()
    {
        if (firstPersonController != null)
        {
            FirstPersonController.OnStaminaChange += UpdateStamina;
        }
    }

    private void OnDisable()
    {
        if (firstPersonController != null)
        {
            FirstPersonController.OnStaminaChange -= UpdateStamina;
        }
    }

    private void UpdateHealth(float health)
    {
        displayHealth = health;

        playerHealthSlider.value = health;
    }

    private void UpdateStamina(FirstPersonController player, float currentStamina)
    {
        playerStaminaSlider.value = currentStamina;
    }
}
