using College;
using UnityEngine;

namespace TowerDefense
{
    public class TowerController : MonoBehaviour
    {
        [field: SerializeField]
        public LayerMask EnemyLayerMask { get; set; }

        [field: SerializeField]
        public TowerAttackData AttackData { get; set; }

        [field: SerializeField]
        public TowerPlacementData PlacementData { get; set; }

        [field: SerializeField]
        public Transform ProjectileParent { get; private set; }

        [field: SerializeField]
        public OnTowerBuildEvent OnTowerBuild { get; set; }

        public Collider[] CachedHits { get; set; } = new Collider[1];
        public float TimeSinceLastShot { get; private set; }
        public bool IsPlaced { get; set; }
        private Camera MainCamera { get; set; }
        private bool IsOnBuildGround { get; set; }
        private bool IsColliding { get; set; }

        protected virtual void Awake()
        {
            MainCamera = Camera.main;
            IsPlaced = false;
        }

        protected virtual void Update()
        {
            TimeSinceLastShot += Time.deltaTime;

            TowerPosition();
            CheckIfCanBePlaced();
            PlaceTower();

            if (TimeSinceLastShot >= AttackData.FireRate)
            {
                TryTakeShot();
            }
        }

        private void TowerPosition()
        {
            if (IsPlaced == false)
            {
                Ray vRay = MainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(vRay, out RaycastHit vHit, PlacementData.MaxRaycastDistance, PlacementData.FloorLayerMask) == true)
                {
                    transform.position = new Vector3(vHit.point.x, 0.0f, vHit.point.z);
                }

                IsOnBuildGround = Physics.Raycast(vRay, PlacementData.MaxRaycastDistance, PlacementData.BuildGroundLayerMask);
                //Debug.Log(IsOnBuildGround == true ? "Can be placed" : "Cannot Be Placed");
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

        protected virtual void OnTriggerStay(Collider other)
        {
            IsColliding = true;
        }

        protected virtual void OnTriggerExit(Collider other)
        {
            IsColliding = false;
        }

        private void TryTakeShot()
        {
            if (IsPlaced == false)
            {
                return;
            }

            int size = Physics.OverlapSphereNonAlloc(transform.position, AttackData.AttackRadius, CachedHits, AttackData.EnemyLayerMask);
            TimeSinceLastShot = 0;

            if (size > 0)
            {
                Projectile projectile = Instantiate(AttackData.ProjectilePrefab, ProjectileParent);

                Enemy enemyTarget = CachedHits[0].GetComponent<Enemy>();

                if (enemyTarget != null)
                {
                    projectile.LaunchAtTarget(enemyTarget.Target, AttackData.Damage);
                    TimeSinceLastShot = 0.0f;
                }
            }
        }
    }
}
