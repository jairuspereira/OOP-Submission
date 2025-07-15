using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private int maxHits = 2;

    private int currentHits;
    protected Transform player;
    private bool isDead = false;

    // Property for speed (can get and set, but not below zero)
    public float Speed
    {
        get { return speed; }
        set { speed = Mathf.Max(0, value); }
    }

    // Property for maxHits (can get and set, but at least 1)
    public int MaxHits
    {
        get { return maxHits; }
        set
        {
            maxHits = Mathf.Max(1, value);
            currentHits = maxHits; // Reset current hits if maxHits changes
        }
    }

    // Read-only property for currentHits
    public int CurrentHits => currentHits;

    protected virtual void Start()
    {
        currentHits = maxHits;
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    protected virtual void Update()
    {
        MoveTowardsPlayer();
    }

    protected virtual void MoveTowardsPlayer()
    {
        if (player == null) return;

        Vector3 direction = player.position - transform.position;
        direction.y = 0;
        transform.position += direction.normalized * speed * Time.deltaTime;
        transform.LookAt(player);
    }

    public virtual void TakeHit()
    {
        if (isDead) return;
        currentHits--;
        if (currentHits <= 0)
        {
            isDead = true;
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindFirstObjectByType<GameOverManager>()?.TriggerGameOver();
        }
    }
}