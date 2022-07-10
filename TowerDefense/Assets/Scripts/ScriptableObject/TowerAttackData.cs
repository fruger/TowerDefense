using UnityEngine;

namespace TowerDefense
{
    [CreateAssetMenu(fileName = "TowerAttackData", menuName = "ScriptableObjects/TowerAttackData")]
    public class TowerAttackData : ScriptableObject
    {
        [field: SerializeField]
        public LayerMask EnemyLayerMask { get; private set; }
        [field: SerializeField]
        public float AttackRadius { get; private set; }
        [field: SerializeField]
        public float FireRate { get; private set; }

        [field: SerializeField]
        public int Damage { get; private set; }

        [field: SerializeField]
        public Projectile ProjectilePrefab { get; private set; }
    }
}
