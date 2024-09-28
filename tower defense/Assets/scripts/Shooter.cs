using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Assign the projectile prefab in the Inspector
    public GameObject projectilePrefab;

    // Assign the target prefab in the Inspector
    public GameObject targetPrefab;

    // Speed at which the projectile moves
    public float projectileSpeed = 5f;

    // Delay between shots (in seconds)
    public float shootDelay = 1f;
    private float shootTimer = 0f;

    void Update()
    {
        if (projectilePrefab == null || targetPrefab == null)
        {
            Debug.LogWarning("ProjectilePrefab or TargetPrefab is not assigned.");
            return;
        }

        // Update the shoot timer
        shootTimer += Time.deltaTime;

        if (shootTimer >= shootDelay)
        {
            ShootAtTarget();
            shootTimer = 0f;
        }
    }

    void ShootAtTarget()
    {
        // Instantiate the projectile at the shooter's position
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Calculate the direction to the target
        Vector2 direction = (targetPrefab.transform.position - transform.position).normalized;

        // Set the projectile's velocity towards the target
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = direction * projectileSpeed;

            // Rotate the projectile to face the target (optional)
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            projectile.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        else
        {
            Debug.LogWarning("ProjectilePrefab does not have a Rigidbody2D component.");
        }
    }
}
