using UnityEngine;

namespace TowerDefense
{
    public class CameraController : MonoBehaviour
    {
        [field: SerializeField]
        private Transform CameraSlot { get; set; }

        [field: SerializeField]
        private float MoveSpeed { get; set; }

        [field: Header("Max position of the camera to the left")]
        [field: SerializeField]
        private float MaxX { get; set; }
        [field: Header("Max position of the camera to the right")]
        [field: SerializeField]
        private float MinX { get; set; }
        [field: Header("Max rear position of the camera")]
        [field: SerializeField]
        private float MaxZ { get; set; }
        [field: Header("Max front position of the camera")]
        [field: SerializeField]
        private float MinZ { get; set; }

        private float XPosition { get; set; }
        private float ZPosition { get; set; }

        protected virtual void Awake()
        {
            Initialize();
        }

        protected virtual void Update()
        {
            MoveCamera();
        }

        private void Initialize()
        {
            XPosition = CameraSlot.position.x;
            ZPosition = CameraSlot.position.z;
        }

        private void MoveCamera()
        {
            XPosition += Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime * -1;
            ZPosition += Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime * -1;

            XPosition = Mathf.Clamp(XPosition, MinX, MaxX);
            ZPosition = Mathf.Clamp(ZPosition, MinZ, MaxZ);

            CameraSlot.position = new Vector3(XPosition, CameraSlot.position.y, ZPosition);
        }
    }
}
