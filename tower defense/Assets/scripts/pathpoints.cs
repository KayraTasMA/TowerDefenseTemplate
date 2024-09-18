using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pathpoints : MonoBehaviour
{
    public static pathpoints main;

    public Transform startpoint;
    public Transform[] path; 

    private void Awake() {
        main = this;
    }
 

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
