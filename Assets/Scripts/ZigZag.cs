using UnityEngine;

public class ZigZag : BaseEnemy
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float zigzagStrength = 5f;
    [SerializeField] float zigzagSpeed = 10f;
    protected override void Update()
    {
        MoveTowardsPlayer();
    }
    
    protected override void MoveTowardsPlayer()
    {
        if (player == null) return;

    // Main direction to player (on ground)
    Vector3 direction = player.position - transform.position;
    direction.y = 0;
    direction.Normalize();

    // Find a perpendicular direction for the zig-zag
    Vector3 perp = Vector3.Cross(direction, Vector3.up).normalized;

    // Sine-based oscillation factor
         // How fast to zigzag (tweak for faster/slower)
    float sine = Mathf.Sin(Time.time * zigzagSpeed);

    // Final movement direction: forward plus oscillating side movement
    Vector3 zigzagDir = (direction + perp * sine * zigzagStrength).normalized;

    // Move
    transform.position += zigzagDir * Speed * Time.deltaTime;

    // Look at player (optional: use direction, or use zigzagDir for a 'drunken' look)
    transform.LookAt(player);
    }
}
