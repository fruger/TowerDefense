using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class EnemySpawner : MonoBehaviour
    {
        [field: Space, Header("Navigation Points References")]
        [field: SerializeField]
        private Transform SpawnPoint { get; set; }

        [field: SerializeField]
        private Transform EndPoint { get; set; }

        [field: Space, Header("Enemy Prefabs")]
        [field: SerializeField]
        private List<Enemy> EnemyPrefabCollection { get; set; } = new List<Enemy>();

        [field: SerializeField]
        private KeyCode SpawnEnemyKey { get; set; } = KeyCode.K;

        [field: SerializeField]
        private KeyCode DestroyEnemyKey { get; set; } = KeyCode.L;

        private List<Enemy> EnemySpawnedCollection { get; set; } = new List<Enemy>();

        protected virtual void Start()
        {
            SpawnEnemy();
        }

        protected virtual void Update()
        {
            HandleKeyboardInput();
        }

        private void SpawnEnemy()
        {
            int prefabIndex = Random.Range(0, EnemyPrefabCollection.Count);

            Enemy spawnedEnemy = Instantiate(EnemyPrefabCollection[prefabIndex], SpawnPoint.position, SpawnPoint.rotation, SpawnPoint);
            spawnedEnemy.Initialize(EndPoint.position);
            spawnedEnemy.OnEnemyDestroy.AddListener(UnregisteredEnemy);

            EnemySpawnedCollection.Add(spawnedEnemy);
        }

        private void UnregisteredEnemy(Enemy enemy)
        {
            EnemySpawnedCollection.Remove(enemy);
            enemy.OnEnemyDestroy.RemoveListener(UnregisteredEnemy);
        }

        private void DestroySpawnedEnemies()
        {
            foreach (Enemy enemy in EnemySpawnedCollection)
            {
                Destroy(enemy.gameObject);
            }

            EnemySpawnedCollection.Clear();
        }

        private void HandleKeyboardInput()
        {
            if (Input.GetKey(SpawnEnemyKey) == true)
            {
                SpawnEnemy();
            }

            if (Input.GetKey(DestroyEnemyKey) == true)
            {
                DestroySpawnedEnemies();
            }
        }
    }
}
