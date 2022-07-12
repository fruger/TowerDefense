using UnityEngine;

namespace TowerDefense
{
    public class Projectile : MonoBehaviour
    {
        [field: SerializeField]
        public float Speed { get; private set; }

        public int Damage { get; private set; }
        public Transform Target { get; private set; }
        private bool IsColliding { get; set; }

        public void Update()
        {
            transform.LookAt(Target);
            transform.position += Time.deltaTime * Speed * transform.forward;
        }

        public void LaunchAtTarget(Transform targetTransform, int damage)
        {
            Damage = damage;
            Target = targetTransform;
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (IsColliding == true)
            {
                Destroy(gameObject);
            }
        }
    }
}

