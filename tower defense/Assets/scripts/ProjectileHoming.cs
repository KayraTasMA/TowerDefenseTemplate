using UnityEngine;

public class ProjectileHoming : MonoBehaviour
{
    // The target the projectile will follow
    public Transform target;

    // Speed at which the projectile moves
    public float speed = 5f;

    // Rotate to face the target?
    public bool rotateTowardsTarget = true;

    void Update()
    {
        if (target == null)
        {
            // Target has been destroyed or not assigned
            Destroy(gameObject);
            return;
        }

        // Calculate the direction to the target
        Vector2 direction = (target.position - transform.position).normalized;

        // Move the projectile towards the target
        transform.position += (Vector3)(direction * speed * Time.deltaTime);

        // Rotate the projectile to face the target
        if (rotateTowardsTarget)
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform == target)
        {
            // Destroy both the projectile and the target
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
