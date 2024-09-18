using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.Mathematics;

public class turret : MonoBehaviour
{

    [Header("References")]
    [SerializeField] private Transform turrotRotationPoint;
    [SerializeField] private LayerMask enemymask;


    [Header("Attribute")]
    [SerializeField] private float targetingRange = 5f;
    [SerializeField] private float rotationspeed = 5f;  

    private Transform target;

    private void Update()
    {
        if (target == null){
            FindTarget();
            return;
        }
        RotateTowardsTarget();
        if (!CheckTargetIsInRange());{
              target = null;
        }
    }

    private void FindTarget(){
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f,enemymask);

        if (hits.Length > 0){
            target = hits[0].transform;
        }
    }

    private bool CheckTargetIsInRange() {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

        private  void RotateTowardsTarget(){
            float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f; 
            
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
            turrotRotationPoint.rotation = Quaternion.RotateTowards(turrotRotationPoint.rotation, targetRotation,rotationspeed * Time.deltaTime);
        }


    private void OnDrawnGizmosSelected()
    {
        Handles.color = Color.cyan;
        Handles.DrawWireDisc(transform.position, transform.forward, targetingRange);
    }
    




    void Start()    
    {
        
    }

    // Update is called once per frame
   

}