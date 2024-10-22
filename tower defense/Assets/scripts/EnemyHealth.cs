using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3; // Set the number of hits the enemy can take
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth; // Initialize enemy health
    }

    // This function is called when the enemy takes damage
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Reduce current health by damage amount

        if (currentHealth <= 0)
        {
            Die(); // Destroy enemy if health is depleted
        }
    }

    // Destroy the enemy game object
    void Die()
    {
        // Optional: Add death effects like animations or sound here

        Destroy(gameObject);
    }

    // Detect collision with projectiles
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is tagged as "Projectile"
        if (collision.CompareTag("Projectile"))
        {
            TakeDamage(1); // Apply damage (adjust the value as needed)

            Destroy(collision.gameObject); // Destroy the projectile upon collision
        }
    }
}
