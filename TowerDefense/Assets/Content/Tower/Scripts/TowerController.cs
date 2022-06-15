using UnityEngine;

public class TowerController : MonoBehaviour
{
    [field: SerializeField]
    private LayerMask FloorLayerMask { get; set; }

    [field: SerializeField]
    private float MaxRaycastDistance { get;  set; }
   
    private Camera MainCamera { get; set; }
    
    private void Awake()
    {
        MainCamera = Camera.main;
    }

    private void Update()
    {
        Ray vRay = MainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(vRay, out RaycastHit vHit, MaxRaycastDistance, FloorLayerMask) == true)
        {
            transform.position = new Vector3(vHit.point.x, 0.0f, vHit.point.z);
        }
    }
}
