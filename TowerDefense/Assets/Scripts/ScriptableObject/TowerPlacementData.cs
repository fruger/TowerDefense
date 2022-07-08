using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu(fileName = "TowerPlacementData", menuName = "ScriptableObjects/TowerPlacementData")]
    public class TowerPlacementData : ScriptableObject
    {
        [field: SerializeField]
        public LayerMask FloorLayerMask { get; set; }

        [field: SerializeField]
        public LayerMask BuildGroundLayerMask { get; set; }

        [field: SerializeField]
        public float MaxRaycastDistance { get; set; }
    }
}

