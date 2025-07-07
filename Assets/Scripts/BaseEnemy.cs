using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public float speed = 3f;
    public int maxHits = 2; // how many hits it takes to destroy
    private int currentHits;

    protected Transform player;

    protected virtual void Start()
    {
        currentHits = maxHits;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected virtual void Update()
    {
        MoveTowardsPlayer();
    }

    protected virtual void MoveTowardsPlayer()
    {
        if (player == null) return;

        Vector3 direction = (player.position - transform.position);
        direction.y = 0; // stay on ground plane
        transform.position += direction.normalized * speed * Time.deltaTime;
        transform.LookAt(player);
    }

    public virtual void TakeHit()
    {
        currentHits--;
        if (currentHits <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}