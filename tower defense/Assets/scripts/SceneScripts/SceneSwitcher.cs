using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    
    

    // wanner een gameobject met een collider met een trigger in een gameobject met een collider gaat 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // dan kijkt het of de gameobject de tag Enemy heeft 
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // en dan laad het de geactiveerde scene die 1 meer is dan de scene waar je in zat
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
