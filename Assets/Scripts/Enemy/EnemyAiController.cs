using UnityEngine;
using UnityEngine.AI;

public class EnemyAiController : MonoBehaviour
{
    [Header("Functional Options")]
    [SerializeField] public bool Reset;
    [SerializeField] private bool canMove;
    [SerializeField] private bool canAttack;
    [SerializeField] private bool canTakeDamage;

    [Header("References")]
    [SerializeField] private NavMeshAgent EnemyAgent;
    [SerializeField] private AudioSource SoundSource;
    [SerializeField] private LayerMask whatIsPlayer;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private LayerMask whatIsBullet;

    [Header("Player References")]
    [SerializeField] private GameObject Player;
    [SerializeField] private FirstPersonController firstPersonController;

    [Header("States")]
    public RegularEnemyState RegularEnemy;
    public bool isIdle;
    public bool isChasing;

    public enum RegularEnemyState
    {
        idle,
        chase,
        attack
    }

    [Header("Enemy Stats")]
    [SerializeField] private float speed;
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;
    [SerializeField] public float damage;

    [Header("Attacking")]
    [SerializeField] public float attackRange;
    [SerializeField] public float timeBetweenAttacks;
    [SerializeField] public float setReadyingAttackTime;
    public float readyingAttackTime;
    [SerializeField] private bool alreadyAttacked;
    [SerializeField] private bool readyToAttack;
    [SerializeField] private float playerDetectionRange;
    public bool playerInRange;
    private Vector3 movePoint;
    private bool getNextPoint;

    private void Start()
    {
        SetUp();
    }

    private void SetUp()
    {
        EnemyAgent = GetComponent<NavMeshAgent>();
        whatIsPlayer = LayerMask.GetMask("whatIsPlayer");
        whatIsGround = LayerMask.GetMask("whatIsGround");

        GameStateManager.Instance.AddEnemy(this);
        GameStateManager.Instance.currentEnemyCount++;

        maxHealth = GameStateManager.Instance.regularEnemyHealth;
        speed = GameStateManager.Instance.regularEnemySpeed;
        damage = GameStateManager.Instance.regularEnemyDamage;

        health = maxHealth;
    }

    private void StateHandler()
    {
        if (isIdle)
        {
            Idle();
            RegularEnemy = RegularEnemyState.idle;
            EnemyAgent.speed = speed / 2f;
        }
        else if (!isIdle && isChasing)
        {
            Chase();
            RegularEnemy = RegularEnemyState.chase;
            EnemyAgent.speed = speed;
            
        }
        else if (playerInRange)
        {
            AttackPlayer();
            RegularEnemy = RegularEnemyState.attack;
            EnemyAgent.speed = 0f;
        }
    }

    private void Update()
    {
        if (Player == null)
        {
            Player = GameStateManager.Instance.Player;
        }

        if (firstPersonController == null)
        {
            firstPersonController = GameStateManager.Instance.firstPersonController;
        }

        StateHandler();

        if (canMove)
        {
            if (firstPersonController != null)
            {
                if (Vector3.Distance(transform.position, firstPersonController.transform.position) <= playerDetectionRange && !isChasing)
                {
                    isIdle = false;
                    isChasing = true;
                }

                if (canAttack)
                {
                    readyingAttackTime -= Time.deltaTime;

                    if (readyingAttackTime <= 0f)
                    {
                        readyingAttackTime = 0f;
                        readyToAttack = true;

                        HandleAttackRangeCheck();
                    }
                }
            }
        }

        if (Reset)
        {
            ResetCharacter();
        }
    }

    private void Idle()
    {
        if (RandomPoint(transform.position, 10f, out movePoint) && getNextPoint)
        {
            if (Vector3.Distance(transform.position, movePoint) > 2f)
            {
                EnemyAgent.SetDestination(movePoint);
                getNextPoint = false;
            }
        }
        else if (Vector3.Distance(transform.position, movePoint) <= 2f)
        {
            getNextPoint = true;
        }
    }

    private void Chase()
    {
        if (firstPersonController != null)
        {
            EnemyAgent.SetDestination(firstPersonController.transform.position);
        }
    }

    public void AttackPlayer()
    {
        if (readyToAttack)
        {
            EnemyAgent.speed = 0f;
            EnemyAgent.SetDestination(transform.position);

            FirstPersonController.OnDamage(firstPersonController, damage);

            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void HandleAttackRangeCheck()
    {
        if (readyToAttack)
        {
            if (firstPersonController != null)
            {
                if (Vector3.Distance(transform.position, firstPersonController.transform.position) <= attackRange)
                {
                    isChasing = false;
                    playerInRange = true;
                }
            }
        }
    }

    private void ResetAttack()
    {
        readyingAttackTime = setReadyingAttackTime;
        playerInRange = false;
        isChasing = true;
        isIdle = false;

        readyToAttack = false;
    }

    public void TakeDamage(float damage)
    {
        if (canTakeDamage)
        {
            health -= damage;

            isIdle = false;

            EnemyAgent.SetDestination(transform.position);
            EnemyAgent.speed /= 2f;

            if (health <= 0)
            {
                GameStateManager.Instance.killCount++;
                GameStateManager.Instance.RemoveEnemy(this);
                
                Destroy(gameObject);
            }
        }
    }

    public void ResetCharacter()
    {
        GameStateManager.Instance.RemoveEnemy(this);
        Destroy(this.gameObject);
    }

    private bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;

            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
}