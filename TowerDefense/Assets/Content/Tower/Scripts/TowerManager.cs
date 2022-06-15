using UnityEngine;

public class TowerManager : MonoBehaviour
{
    [field: SerializeField]
    private TowerController TowerPrefab { get; set; }

    private TowerController CurrentTower { get; set; }

    [field: SerializeField]
    private KeyCode createTower { get; set; } = KeyCode.T;
    
    void Update()
    {
        if (Input.GetKeyDown(createTower) == true)
        {
            SpawnTower();
        }
    }

    public void SpawnTower()
    {
        CurrentTower = Instantiate(TowerPrefab);
    }


}
