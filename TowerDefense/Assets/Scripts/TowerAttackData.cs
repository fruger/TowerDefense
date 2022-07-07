using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu(fileName = "TowerAttackData", menuName = "ScriptableObjects/TowerAttackData")]
    public class TowerAttackData : ScriptableObject
    {
        [field: SerializeField]
        public LayerMask EnemyLayerMask { get; set; }
        [field: SerializeField]
        public float AttackRadius { get; set; }
        [field: SerializeField]
        public float FireRate { get; set; }

        [field: SerializeField]
        public int Damage { get; set; }

        [field: SerializeField]
        public Projectile ProjectilePrefab { get; set; }
    }
}
