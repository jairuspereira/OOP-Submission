using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Hero3DController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Shooting")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    private CharacterController controller;
    private Camera mainCamera;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        mainCamera = Camera.main;
    }

    
    void Update()
    {
        if (Time.timeScale == 0f) return;
        HandleMovement();
        RotateTowardMouse();
        HandleShooting();
    }

    void HandleMovement()
    {
        float h = Input.GetAxis("Horizontal"); // A/D
        float v = Input.GetAxis("Vertical");   // W/S
        Vector3 move = new Vector3(h, 0, v).normalized;
        controller.SimpleMove(move * moveSpeed);
    }

    void RotateTowardMouse()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        if (groundPlane.Raycast(ray, out float distance))
        {
            Vector3 hitPoint = ray.GetPoint(distance);
            Vector3 lookDirection = hitPoint - transform.position;
            lookDirection.y = 0;

            if (lookDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
                transform.rotation = targetRotation;
            }
        }
    }

    void HandleShooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

            if (groundPlane.Raycast(ray, out float distance))
            {   
                Vector3 hitPoint = ray.GetPoint(distance);
                Vector3 shootDir = hitPoint - firePoint.position;
                shootDir.y = 0;
                shootDir.Normalize();

                GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(shootDir));
                bullet.GetComponent<Bullet>().SetDirection(shootDir);
            }
        }
    }
}