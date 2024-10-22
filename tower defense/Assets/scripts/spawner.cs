using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 4f;

    private float timeSinceLastSpawn;
    
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;

    private void Start()
    {
        StartWave();
    }

    private void Update()
    {
        if (!isSpawning) return;
        
        timeSinceLastSpawn += Time.deltaTime;
        
        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            timeSinceLastSpawn = 0f;
        }
    }

    private void StartWave()
    {
        isSpawning = true;
        enemiesLeftToSpawn = baseEnemies;
    }

    private void SpawnEnemy()
    {
        GameObject prefabToSpawn = enemyPrefabs[0];
        Instantiate(prefabToSpawn, LevelManager.main.startpoint.position, Quaternion.identity);
    }
}
