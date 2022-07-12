using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TowerDefense
{
    public class TowerManager : SingletonMonoBehaviour<TowerManager>
    {
        private TowerController CurrentTower { get; set; }

        private List<TowerController> TowerPrefabCollection { get; set; } = new List<TowerController>();

        public void TowerBuild(TowerController towerPrefab)
        {
            CurrentTower = null;
            towerPrefab.OnTowerBuild.RemoveListener(TowerBuild);
        }

        public void TrySpawnTowerPrefab(TowerController towerPrefab)
        {
            IsCurrentTowerNull();
            CurrentTower = Instantiate(towerPrefab);
            TowerPrefabCollection.Add(CurrentTower);
            CurrentTower.OnTowerBuild.AddListener(TowerBuild);
        }

        private void IsCurrentTowerNull()
        {
            if (CurrentTower != null)
            {
                Destroy(TowerPrefabCollection.Last().gameObject);
                TowerPrefabCollection.Remove(TowerPrefabCollection.Last());
            }
        }
    }
}
