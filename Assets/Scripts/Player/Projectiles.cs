using UnityEngine;

public class Projectiles : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private LayerMask whatIsCollidable;
    [SerializeField] private LayerMask whatIsEnemy;

    [Header("General Stats")]
    [SerializeField] private bool useGravity;
    [SerializeField] public float damage;
    [SerializeField] private int maxCollisions;
    [SerializeField] private int collisions;
    [SerializeField] private float destroyDelay;

    [Header("What is it")]
    [SerializeField] private bool isBullet;

    private void Awake()
    {
        Setup();
    }

    private void Setup()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.useGravity = useGravity;

        collisions = 0;
    }

    private void Update()
    {
        if (collisions >= maxCollisions)
        {
            Invoke(nameof(ProjectileDestroy), destroyDelay);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isBullet)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                EnemyAiController hitEnemy = collision.gameObject.GetComponent<EnemyAiController>();

                if (hitEnemy != null)
                {
                    hitEnemy.TakeDamage(damage);

                    Invoke(nameof(ProjectileDestroy), destroyDelay);
                }
            }

            collisions++;
        }
    }

    public void ProjectileDestroy()
    {
        Destroy(gameObject);
    }
}