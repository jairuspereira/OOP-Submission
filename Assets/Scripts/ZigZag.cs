using UnityEngine;

public class ZigZag : BaseEnemy // INHERITANCE
{
    
    [SerializeField] float zigzagStrength;
    [SerializeField] float zigzagSpeed ;
    protected override void Update()
    {
        MoveTowardsPlayer();
    }
    
    protected override void MoveTowardsPlayer() //POLYMORPHISM
    {
        if (player == null) return;

    // Main direction to player (on ground)
    Vector3 direction = player.position - transform.position;
    direction.y = 0;
    direction.Normalize();

    
    Vector3 perp = Vector3.Cross(direction, Vector3.up).normalized;

  
    float sine = Mathf.Sin(Time.time * zigzagSpeed);


    Vector3 zigzagDir = (direction + perp * sine * zigzagStrength).normalized;

    // Move
    transform.position += zigzagDir * Speed * Time.deltaTime;

   
    transform.LookAt(player);
    }
}
