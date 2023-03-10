using UnityEngine;
using UnityEngine.AI;

namespace TowerDefense
{
    public class Enemy : MonoBehaviour, IHitable
    {
        [field: SerializeField]
        public OnEnemyDestroyEvent OnEnemyDestroy { get; private set; }

        [field: SerializeField]
        public int CurrentHealth { get; private set; }

        [field: SerializeField]
        public Transform Target { get; set; }

        [field: SerializeField]
        private LayerMask CastleLayerMask { get; set; }

        [field: SerializeField]
        private NavMeshAgent Agent { get; set; }

        [field: SerializeField]
        private int Damage { get; set; }

        public void Initialize(Vector3 targetPosition)
        {
            Agent.SetDestination(targetPosition);
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (CastleLayerMask.CheckIfContainsLayer(other.gameObject.layer) == true)
            {
                EnterCastle();
            }
        }

        private void EnterCastle()
        {
            GameManager.Instance.TakeDamage(Damage);
            Destroy(gameObject);
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            OnEnemyDestroy.Invoke(this);
        }
    }
}
