using UnityEngine;
using UnityEngine.EventSystems;

public class ReplaceWithPrefabOnClick2D : MonoBehaviour
{
    // Assign the prefab you want to instantiate in the Unity Inspector
    public GameObject prefabToInstantiate;

    void OnMouseDown()
    {
        // Check if the prefab is assigned
        if (prefabToInstantiate != null)
        {
            // Instantiate the prefab at the object's position and rotation
            Instantiate(prefabToInstantiate, transform.position, transform.rotation);
        }
        else
        {
            Debug.LogWarning("Prefab to instantiate is not assigned.");
        }

        // Destroy the current GameObject
        Destroy(gameObject);
    }
}
