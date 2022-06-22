using UnityEngine;
using UnityEngine.AI;

namespace TowerDefense
{
    public class Enemy : MonoBehaviour
    {
        [field: SerializeField]
        private NavMeshAgent Agent { get; set; }

        public void Initialize(Vector3 targetPosition)
        {
            Agent.SetDestination(targetPosition);
        }
    }
}
