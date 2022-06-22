using UnityEngine;

public class TowerButtonController : MonoBehaviour
{
    [field: SerializeField]
    private TowerController TowerPrefab { get; set; }

    public void NotifyOnTowerButtonClicked()
    {
        TowerManager.Instance.TrySpawnTowerPrefab(TowerPrefab);
    }
}
