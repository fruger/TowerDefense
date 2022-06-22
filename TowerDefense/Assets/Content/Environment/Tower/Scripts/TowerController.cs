using UnityEngine;

public class TowerController : MonoBehaviour
{
    [field: SerializeField]
    private LayerMask FloorLayerMask { get; set; }

    [field: SerializeField]
    private float MaxRaycastDistance { get; set; }

    private Camera MainCamera { get; set; }

    [field: SerializeField]
    private LayerMask BuildGroundLayerMask { get; set; }
    private bool IsOnBuildGround { get; set; }
    private bool IsColliding { get; set; }

    private void Awake()
    {
        MainCamera = Camera.main;
    }

    private void Update()
    {
        TowerPosition();
        CheckIfCanBePlaced();
    }

    private void TowerPosition()
    {
        Ray vRay = MainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(vRay, out RaycastHit vHit, MaxRaycastDistance, FloorLayerMask) == true)
        {
            transform.position = new Vector3(vHit.point.x, 0.0f, vHit.point.z);
        }

        IsOnBuildGround = Physics.Raycast(vRay, MaxRaycastDistance, BuildGroundLayerMask);
        Debug.Log(IsOnBuildGround == true ? "Can be placed" : "Cannot Be Placed");
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
}
