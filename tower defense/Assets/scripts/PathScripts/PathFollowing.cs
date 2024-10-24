using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathfollowing : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float movespeed = 2f;

    private Transform target; 
    private int pathIndex = 0;  
    void Start()
    {
        target = pathpoints.main.path[pathIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(target.position, transform.position) <= 0.1f){
            pathIndex++;

            if (pathIndex >= pathpoints.main.path.Length){
                Destroy(gameObject);
                return;
            } else {
                target = pathpoints.main.path[pathIndex];
            }
        }
    }
    private void FixedUpdate() {
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * movespeed;
    }
}
