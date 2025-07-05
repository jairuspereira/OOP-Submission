using UnityEngine;

public class BaseEnemy : MonoBehaviour
{
    public float speed = 3f;
    public float damage = 10f;

    protected Transform player;

    protected virtual void Start()
    {
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

    // Example attack method - you can call this on contact or with a timer
    public virtual void Attack()
    {
        Debug.Log($"{gameObject.name} attacks for {damage} damage.");
        // Apply damage to player here
    }
}
