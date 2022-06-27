using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class TowerManager : MonoBehaviour
    {
        private TowerController CurrentTower { get; set; }

        private List<TowerController> TowerPrefabCollection { get; set; } = new List<TowerController>();

        public static TowerManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        public void TrySpawnTowerPrefab(TowerController towerPrefab)
        {
            CurrentTower = Instantiate(towerPrefab);
            TowerPrefabCollection.Add(CurrentTower);
        }
    }
}
