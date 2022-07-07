using UnityEngine;

namespace TowerDefense
{
    public class Projectile : MonoBehaviour
    {
        [field:SerializeField]
        public int Damage { get; set; }

        [field: SerializeField]
        public Transform Target { get; set; }

        [field: SerializeField]
        public float Speed { get; private set; }

        public void Update()
        {
            transform.LookAt(Target);
            transform.position += Time.deltaTime * Speed * transform.forward;
        }

        public void LaunchAtTarget(IHitable enemyTarget, Transform targetTransform, int damage)
        {
            Damage = damage;
            Target = targetTransform;
        }
    }
}

