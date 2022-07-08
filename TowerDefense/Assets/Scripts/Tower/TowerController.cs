using College;
using UnityEngine;

namespace TowerDefense
{
    public class TowerController : MonoBehaviour
    {
        [field: SerializeField]
        private float MaxRaycastDistance { get; set; }

        [field: SerializeField]
        public LayerMask EnemyLayerMask { get; set; }

        [field: SerializeField]
        private LayerMask FloorLayerMask { get; set; }

        [field: SerializeField]
        private LayerMask BuildGroundLayerMask { get; set; }

        [field: SerializeField]
        public TowerAttackData AttackData { get; set; }

        [field: SerializeField]
        public Transform ProjectileParent { get; private set; }

        [field: SerializeField]
        public OnTowerBuildEvent OnTowerBuild { get; set; }

        private Camera MainCamera { get; set; }
        private bool IsOnBuildGround { get; set; }
        private bool IsColliding { get; set; }
        public Collider[] CachedHits { get; set; }
        public float TimeSinceLastShot { get; private set; }
        public bool IsPlaced { get; set; }


        private void Awake()
        {
            MainCamera = Camera.main;
            IsPlaced = false;
        }

        private void Update()
        {
            TimeSinceLastShot += Time.deltaTime;

            TowerPosition();
            CheckIfCanBePlaced();
            PlaceTower();

            TryTakeShot();
        }

        private void TowerPosition()
        {
            if (IsPlaced == false)
            {
                Ray vRay = MainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(vRay, out RaycastHit vHit, MaxRaycastDistance, FloorLayerMask) == true)
                {
                    transform.position = new Vector3(vHit.point.x, 0.0f, vHit.point.z);
                }

                IsOnBuildGround = Physics.Raycast(vRay, MaxRaycastDistance, BuildGroundLayerMask);
                Debug.Log(IsOnBuildGround == true ? "Can be placed" : "Cannot Be Placed");
            }

        }

        private void PlaceTower()
        {
            if (Input.GetMouseButton(0) && CheckIfCanBePlaced())
            {
                IsPlaced = true;
                OnTowerBuild.Invoke(this);
            }
        }

        public bool CheckIfCanBePlaced()
        {
            return IsOnBuildGround == true && IsColliding == false;
        }

        private void OnTriggerStay(Collider other)
        {
            IsColliding = true;
        }

        private void OnTriggerExit(Collider other)
        {
            IsColliding = false;
        }

        private void TryTakeShot()
        {
            int size = Physics.OverlapSphereNonAlloc(transform.position, AttackData.AttackRadius, CachedHits, AttackData.EnemyLayerMask);

            if (size > 0)
            {
                Projectile projectile = Instantiate(AttackData.ProjectilePrefab, ProjectileParent);

                IHitable enemyTarget = CachedHits[0].GetComponent<IHitable>();

                if (enemyTarget != null)
                {
                    projectile.LaunchAtTarget(enemyTarget, CachedHits[0].transform, AttackData.Damage);
                    TimeSinceLastShot = 0.0f;
                }
            }
        }
    }
}
