 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildmanager : MonoBehaviour
{
    public static buildmanager main;
    [Header("references")]
    [SerializeField] private GameObject [] towerprefabs;

    private int selectedtower = 0;

    private void Awake()
    {
        main = this;
    }

    public GameObject GetSelectedTower()
    {
        return towerprefabs[selectedtower];
    }

    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
