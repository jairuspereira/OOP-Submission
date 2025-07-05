using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 5f; 

    private Vector3 direction;

    public void SetDirection(Vector3 dir)
    {
        dir.y = 0; 
        direction = dir.normalized;
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;

        // Destroy if far from origin (adjust as needed)
        if (Mathf.Abs(transform.position.x) > 100 || Mathf.Abs(transform.position.z) > 100)
        {
            Destroy(gameObject);
        }
    }
}