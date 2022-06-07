using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [field: SerializeField]
    private Transform SpawnPoint { get; set; }

    [field: SerializeField]
    private Enemy EnemyPrefab { get; set; }

    [field: SerializeField]
    private Transform EndPoint { get; set; }

    private List<Enemy> EnemySpawnedCollection { get; set; } = new List<Enemy>();

    protected virtual void Start()
    {
        SpawnEnemy();
    }

    protected virtual void Update()
    {
        if (Input.GetKey(KeyCode.K) == true)
        {
            SpawnEnemy();
        }

        if (Input.GetKey(KeyCode.L) == true)
        {
            DestroySpawnedEnemies();
        }
    }

    private void SpawnEnemy()
    {
        Enemy spawnedEnemy = Instantiate(EnemyPrefab, SpawnPoint.position, SpawnPoint.rotation, SpawnPoint);
        spawnedEnemy.Initialize(EndPoint.position);

        EnemySpawnedCollection.Add(spawnedEnemy);
    }

    private void DestroySpawnedEnemies()
    {
        foreach (Enemy item in EnemySpawnedCollection)
        {
            Destroy(EnemyPrefab.gameObject);
        }

        EnemySpawnedCollection.Clear();
    }
}
