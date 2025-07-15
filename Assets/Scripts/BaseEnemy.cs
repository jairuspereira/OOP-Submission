using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private int maxHits = 2;

    private int currentHits;
    protected Transform player;
    private bool isDead = false;

    // ENCAPSULATION
    public float Speed
    {
        get { return speed; }
        set { speed = Mathf.Max(0, value); }
    }

    
    public int MaxHits // ENCAPSULATION
    {
        get { return maxHits; }
        set
        {
            maxHits = Mathf.Max(1, value);
            currentHits = maxHits; 
        }
    }

    
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

    protected virtual void MoveTowardsPlayer() // ABSTRACTION
    {
        if (player == null) return;

        Vector3 direction = player.position - transform.position;
        direction.y = 0;
        transform.position += direction.normalized * speed * Time.deltaTime;
        transform.LookAt(player);
    }

    public virtual void TakeHit() // ABSTRACTION
    {
        if (isDead) return;
        currentHits--;
        if (currentHits <= 0)
        {
            isDead = true;
            Die();
        }
    }

    protected virtual void Die() // ABSTRACTION
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