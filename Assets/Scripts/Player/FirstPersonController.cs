using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonController : MonoBehaviour
{
    public bool CanMove { get; set; } = true;
    private bool IsGrounded => characterController.isGrounded;
    private float GetCurrentOffSet => isSprinting ? baseStepSpeed * sprintStepMultiplier : baseStepSpeed;

    [Header("Functional Options")]
    [SerializeField] private bool canSprint = true;
    [SerializeField] private bool canJump = true;
    [SerializeField] private bool willSlideOnSlopes = true;
    [SerializeField] public bool useStamina = true;
    [SerializeField] public bool useFootSteps = true;
    [SerializeField] private bool canUseHeadBob = true;
    [SerializeField] private bool canZoom = true;
    [SerializeField] private bool canUseHealth = true;

    [Header("States")]
    public CharacterState characterState;
    public PlayerInput playerInput;
    public PlayerInputActions playerInputActions;
    public InputActionAsset inputAsset;
    public InputActionMap player;
    public InputAction playerMove;
    public InputAction cameraMove;

    public enum CharacterState
    {
        idle,
        walk,
        sprint,
        jump,
        fall,
    }

    [Header("References")]
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private LayerMask whatIsWall;
    [SerializeField] private LayerMask whatIsEnemy;
    [SerializeField] public CharacterController characterController;
    [SerializeField] private CapsuleCollider capsuleCollider;
    [SerializeField] private GameObject cameraHolder;
    [SerializeField] public Camera cameraComp;
    [SerializeField] public Camera uiCameraOverlay;
    [SerializeField] public UiController uiController;
    [SerializeField] private GameObject footsteps;
    [SerializeField] private AudioSource footstepAudioSource;
    [SerializeField] private GameObject crosshair;
    [SerializeField] private GameObject Gun;
    [SerializeField] public ProjectileSystem gunProjectileSystem;

    [Header("Look Parameters")]
    [SerializeField, Range(1, 100)] private float lookSpeedX;
    [SerializeField, Range(1, 100)] private float lookSpeedY;
    [SerializeField, Range(1, 100)] private float upperLookLimit;
    [SerializeField, Range(1, 100)] private float lowerLookLimit;
    private Vector2 lookVector;
    private float rotationX;

    [Header("Headbob Parameters")]
    [SerializeField] private float walkBobSpeed;
    [SerializeField] private float walkBobAmount;
    [SerializeField] private float sprintBobSpeed;
    [SerializeField] private float sprintBobAmount;
    [SerializeField] private float crouchBobSpeed;
    [SerializeField] private float crouchBobAmount;
    private float defaultYPos;
    private float timer;

    [Header("Zoom Parameters")]
    [SerializeField] private float timeToZoom;
    [SerializeField] private float zoomFOV;
    private float defaultFOV;
    private Coroutine zoomRoutine;

    [Header("Movement Parameters")]
    [SerializeField] private float momentumDrag;
    [SerializeField] private float moveSpeed;
    [SerializeField] public float walkSpeed;
    [SerializeField] public float sprintSpeed;
    [SerializeField] private float slopeSpeed;
    private float moveDirectionY;
    private float moveDirectionZ;
    private float moveDirectionX;
    [HideInInspector] public Vector3 moveDirectionMomentum;
    private Vector2 inputVector;
    private Vector2 currentInput;
    private Vector3 moveDirection;
    private Vector3 hitPointNormal;

    [Header("Jump Parameters")]
    [SerializeField] private float gravity;
    [SerializeField] private float upwardsGravityScale;
    [SerializeField] private float downwardsGravityScale;
    public float upwardsJumpForce;
    public float forwardsJumpForce;
    [SerializeField] private float jumpCooldown;
    private bool readyToJump;
    private bool exitingSlope;

    [Header("Player Stats")]
    [SerializeField] public float health;
    [SerializeField] public float maxHealth;
    [HideInInspector] public static Action<FirstPersonController, float> OnDamage;
    public bool isDead = false;

    [Header("Weapon Stuff")]
    [SerializeField] public ProjectileSystem Weapon;
    [HideInInspector] public bool isShooting;

    [Header("Stamina Parameters")]
    [SerializeField] public float currentStamina;
    [SerializeField] public float maxStamina;
    [SerializeField] private float sprintingStaminaUseMultiplier = 5f;
    [SerializeField] private float timeBeforeStaminaRegenStarts = 5f;
    [SerializeField] private float staminaValueIncrement = 2f;
    [SerializeField] private float staminaTimeIncrement = 0.1f;
    public bool canUseStamina;
    public bool isSprinting;
    public bool currentlySprinting;
    public Coroutine regeneratingStamina;
    public static Action<FirstPersonController, float> OnStaminaChange;

    [Header("Footstep Parameters")]
    [SerializeField] private float baseStepSpeed = 0.5f;
    [SerializeField] private float sprintStepMultiplier = 0.6f;
    [SerializeField] private AudioClip[] DefaultClips;
    [SerializeField] private AudioClip[] InsideClips;
    [SerializeField] private AudioClip[] OutsideClips;
    private float footstepTimer = 0;

    [HideInInspector] public bool player2 = false;
    [HideInInspector] public bool player1 = false;

    private void OnEnable()
    {
        OnDamage += ApplyDamage;

        player.FindAction("Jump").performed += HandleJump;
        player.FindAction("Sprint").performed += IsSprinting;
        player.FindAction("Sprint").canceled += IsSprinting;
        player.FindAction("Zoom").performed += HandleZoom;
        player.FindAction("Zoom").canceled += HandleZoom;
        player.FindAction("Shoot").performed += HandleWeapons;
        player.FindAction("Shoot").canceled += HandleWeapons;
        player.FindAction("Reload").performed += HandleReload;
        player.FindAction("Reload Cancel").performed += HandleReloadCancel;
        player.FindAction("Reload Cancel").canceled += HandleReloadCancel;

        playerMove = player.FindAction("HandleMovementInput");
        cameraMove = player.FindAction("HandleCameraInput");

        playerInputActions.Enable();
    }

    private void OnDisable()
    {
        OnDamage -= ApplyDamage;

        player.FindAction("Jump").performed -= HandleJump;
        player.FindAction("Sprint").performed -= IsSprinting;
        player.FindAction("Sprint").canceled -= IsSprinting;
        player.FindAction("Zoom").performed -= HandleZoom;
        player.FindAction("Zoom").canceled -= HandleZoom;
        player.FindAction("Shoot").performed -= HandleWeapons;
        player.FindAction("Shoot").canceled -= HandleWeapons;
        player.FindAction("Reload").performed -= HandleReload;
        player.FindAction("Reload Cancel").performed -= HandleReloadCancel;
        player.FindAction("Reload Cancel").canceled -= HandleReloadCancel;

        playerInputActions.Disable();
    }

    private void Awake()
    {
        whatIsGround = LayerMask.GetMask("whatIsGround");
        whatIsWall = LayerMask.GetMask("whatIsWall");
        whatIsEnemy = LayerMask.GetMask("whatIsEnemy");

        playerInput = GetComponent<PlayerInput>();
        playerInputActions = new PlayerInputActions();
        inputAsset = gameObject.GetComponent<PlayerInput>().actions;
        player = inputAsset.FindActionMap("Player");
        playerInputActions.Player.Enable();

        GameStateManager.Instance.AddPlayer(this);
    }

    private void Start()
    {
        if (GameStateManager.Instance.Player == null)
        {
            GameStateManager.Instance.Player = this.gameObject;
        }

        if (GameStateManager.Instance.firstPersonController == null)
        {
            GameStateManager.Instance.firstPersonController = this;
        }

        SetUp();
    }

    private void SetUp()
    {
        readyToJump = true;
        exitingSlope = false;
        health = maxHealth;
        canUseStamina = true;
        currentStamina = maxStamina;
        defaultYPos = cameraComp.transform.localPosition.y;
        defaultFOV = cameraComp.fieldOfView;
    }

    private void Update()
    {
        if (CanMove)
        {
            StateHandler();
            HandleMovementInput();

            if (!canUseStamina || inputVector == Vector2.zero)
            {
                isSprinting = false;
            }

            HandleCameraInput();

            HandleHeadbob();

            if (useStamina)
            {
                HandleStamina();
            }

            if (useFootSteps)
            {
                HandleFootsteps();
            }

            ApplyFinalMovements();
        }
    }

    private void StateHandler()
    {
        if (!isDead)
        {
            if (moveDirection.magnitude <= 0f && IsGrounded)
            {
                characterState = CharacterState.idle;
                moveSpeed = walkSpeed;
            }
            else if (moveDirection.magnitude > 0f && IsGrounded && !isSprinting)
            {
                characterState = CharacterState.walk;
                moveSpeed = walkSpeed;
            }
            else if (moveDirection.magnitude > 0f && IsGrounded && isSprinting)
            {
                characterState = CharacterState.sprint;
                moveSpeed = sprintSpeed;
            }
            else if (moveDirection.magnitude > 0f && !IsGrounded && !readyToJump)
            {
                characterState = CharacterState.jump;
            }
            else if (moveDirection.magnitude > 0f && !IsGrounded && readyToJump)
            {
                characterState = CharacterState.fall;
            }
        }
        else if (isDead)
        {
            canUseStamina = true;
            transform.position = GameStateManager.Instance.SpawnPoint.transform.position;
            
        }
    }

    private void HandleMovementInput()
    {
        inputVector = playerMove.ReadValue<Vector2>();

        if (inputVector != Vector2.zero)
        {
            currentInput = inputVector * moveSpeed;
        }
        else
        {
            currentInput = Vector2.zero;
        }

        moveDirection = (transform.forward * currentInput.y) + (transform.right * currentInput.x);
    }

    private void HandleCameraInput()
    {
        if (playerInput.currentControlScheme == "Player / Gamepad")
        {
            lookSpeedY = 70;
            lookSpeedX = 60;
        }

        lookVector = cameraMove.ReadValue<Vector2>() * Time.smoothDeltaTime;
        rotationX -= lookVector.y * lookSpeedY;
        rotationX = Mathf.Clamp(rotationX, -upperLookLimit, lowerLookLimit);
        cameraHolder.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
        transform.rotation *= Quaternion.Euler(0, lookVector.x * lookSpeedX, 0f);
    }

    private void ApplyFinalMovements()
    {
        if (!IsGrounded)
        {
            if (characterController.velocity.y > 0f)
            {
                moveDirectionY -= gravity * upwardsGravityScale * 10 * Time.deltaTime;
            }

            if (characterController.velocity.y <= 0f)
            {
                moveDirectionY -= gravity * downwardsGravityScale * 10 * Time.deltaTime;
            }
        }

        if (characterController.velocity.y < -1f && IsGrounded)
        {
            moveDirectionY = 0f;
        }

        if (willSlideOnSlopes && IsSliding)
        {
            moveDirection += new Vector3(hitPointNormal.x, hitPointNormal.y, hitPointNormal.z) * slopeSpeed;
        }

        moveDirection.y = moveDirectionY;
        moveDirection.z += moveDirectionZ;
        moveDirection.x += moveDirectionX;

        moveDirection += moveDirectionMomentum;

        characterController.Move(moveDirection * Time.deltaTime);

        if (characterController.velocity.magnitude >= currentInput.y)
        {
            moveDirectionZ = 0f;
        }

        if (characterController.velocity.magnitude >= currentInput.x)
        {
            moveDirectionX = 0f;
        }

        if (moveDirectionMomentum.magnitude >= 0f)
        {
            moveDirectionMomentum -= momentumDrag * Time.deltaTime * moveDirectionMomentum;

            if (moveDirectionMomentum.magnitude <= 0.0f)
            {
                moveDirectionMomentum = Vector3.zero;
            }

            if (IsGrounded)
            {
                moveDirectionMomentum = Vector3.zero;
            }
        }
    }

    public void HandleJump(InputAction.CallbackContext context)
    {
        if (canJump && IsGrounded && context.performed)
        {
            moveDirectionY = upwardsJumpForce;

            if (moveDirection.z > 0f)
            {
                moveDirectionZ = forwardsJumpForce;
            }
            else if (moveDirection.z < 0f)
            {
                moveDirectionZ = (forwardsJumpForce * -1);
            }
            else if (moveDirection.z == 0f)
            {
                moveDirectionZ = 0f;
            }

            if (moveDirection.x > 0f)
            {
                moveDirectionX = (forwardsJumpForce / 2);
            }
            else if (moveDirection.x < 0f)
            {
                moveDirectionX = ((forwardsJumpForce / 2) * -1);
            }
            else if (moveDirection.x == 0f)
            {
                moveDirectionX = 0f;
            }

            readyToJump = false;

            exitingSlope = true;

            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void ResetJump()
    {
        readyToJump = true;

        exitingSlope = false;
    }

    private void HandleWeapons(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Weapon.shooting = true;
        }
        else if (context.canceled)
        {
            Weapon.shooting = false;
        }
    }

    private void HandleReload(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Weapon.shouldReload = true;
        }
    }

    private void HandleReloadCancel(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Weapon.cancelReload = true;
        }
        else if (context.canceled)
        {
            Weapon.cancelReload = false;
        }
    }

    private void HandleHeadbob()
    {
        if (canUseHeadBob)
        {
            if (!IsGrounded)
            {
                return;
            }

            if (Mathf.Abs(moveDirection.x) > 0.1f || Mathf.Abs(moveDirection.z) > 0.1f)
            {
                timer += Time.deltaTime * (isSprinting ? sprintBobSpeed : walkBobSpeed);
                cameraComp.transform.localPosition = new Vector3(
                    cameraComp.transform.localPosition.x,
                    defaultYPos + Mathf.Sin(timer) * (isSprinting ? sprintBobAmount : walkBobAmount),
                    cameraComp.transform.localPosition.z);
            }
        }
    }

    private void HandleZoom(InputAction.CallbackContext context)
    {
        if (canZoom && context.performed)
        {
            if (zoomRoutine != null)
            {
                StopCoroutine(zoomRoutine);
                zoomRoutine = null;
            }

            zoomRoutine = StartCoroutine(ToggleZoom(true));
        }

        if (canZoom && context.canceled)
        {
            if (zoomRoutine != null)
            {
                StopCoroutine(zoomRoutine);
                zoomRoutine = null;
            }

            zoomRoutine = StartCoroutine(ToggleZoom(false));
        }
    }

    private void HandleFootsteps()
    {
        if (!IsGrounded)
        {
            return;
        }

        if (characterController.velocity == Vector3.zero)
        {
            return;
        }

        footstepTimer -= Time.deltaTime;

        if (footstepTimer <= 0 && DefaultClips.Length != 0)
        {
            if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 5f))
            {
                footstepAudioSource.pitch = UnityEngine.Random.Range(1f, 1.5f);

                switch (hit.collider.tag)
                {
                    /*case "FootstepsOutside":
                        footstepAudioSource.PlayOneShot(InsideClips[UnityEngine.Random.Range(0, InsideClips.Length - 1)]);
                        break;
                    case "FootstepsInside":
                        footstepAudioSource.PlayOneShot(OutsideClips[UnityEngine.Random.Range(0, OutsideClips.Length - 1)]);
                        break;*/
                    default:
                        footstepAudioSource.PlayOneShot(DefaultClips[UnityEngine.Random.Range(0, DefaultClips.Length - 1)]);
                        break;
                }
            }

            footstepTimer = GetCurrentOffSet;
        }

    }

    private void HandleStamina()
    {
        if (isSprinting && currentInput != Vector2.zero)
        {
            if (regeneratingStamina != null)
            {
                StopCoroutine(regeneratingStamina);
                regeneratingStamina = null;
            }

            currentStamina -= sprintingStaminaUseMultiplier * Time.deltaTime;

            if (currentStamina < 0)
            {
                currentStamina = 0;
            }

            OnStaminaChange?.Invoke(this, currentStamina);

            if (currentStamina <= 0)
            {
                canUseStamina = false;
            }
        }

        if (!isSprinting)
        {
            if (currentStamina < maxStamina && regeneratingStamina == null)
            {
                regeneratingStamina = StartCoroutine(RegenerateStamina());
            }
        }
    }

    private void ApplyDamage(FirstPersonController player, float dmg)
    {
        if (canUseHealth)
        {
            if (player == this)
            {
                health -= dmg;
            }

            if (health <= 0)
            {
                isDead = true;
            }
        }
    }

    private bool IsSliding
    {
        get
        {
            if (IsGrounded && Physics.Raycast(transform.position, Vector3.down, out RaycastHit slopeHit, 2f))
            {
                hitPointNormal = slopeHit.normal;
                return Vector3.Angle(hitPointNormal, Vector3.up) > characterController.slopeLimit;
            }
            else
            {
                return false;
            }
        }
    }

    private void IsSprinting(InputAction.CallbackContext context)
    {
        if (canSprint && canUseStamina && context.performed)
        {
            isSprinting = true;
        }

        if (context.canceled)
        {
            isSprinting = false;
        }
    }

    private IEnumerator RegenerateStamina()
    {
        yield return new WaitForSeconds(timeBeforeStaminaRegenStarts);
        WaitForSeconds timeToWait = new WaitForSeconds(staminaTimeIncrement);

        while (currentStamina < maxStamina)
        {
            if (currentStamina > 0)
            {
                canUseStamina = true;
            }

            currentStamina += staminaValueIncrement;

            if (currentStamina > maxStamina)
            {
                currentStamina = maxStamina;
            }

            OnStaminaChange?.Invoke(this, currentStamina);

            yield return timeToWait;
        }

        regeneratingStamina = null;
    }

    private IEnumerator ToggleZoom(bool IsEnter)
    {
        float targetFOV = IsEnter ? zoomFOV : defaultFOV;
        float startingFOV = cameraComp.fieldOfView;
        float timeElapsed = 0f;

        while (timeElapsed < timeToZoom)
        {
            cameraComp.fieldOfView = Mathf.Lerp(startingFOV, targetFOV, timeElapsed / timeToZoom);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        cameraComp.fieldOfView = targetFOV;
        zoomRoutine = null;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Portal"))
        {
            GameStateManager.hasWon = true;
        }
    }
}
