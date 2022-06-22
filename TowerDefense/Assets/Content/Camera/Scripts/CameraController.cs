using UnityEngine;

namespace TowerDefense
{
    public class CameraController : MonoBehaviour
    {
        [field: SerializeField]
        private Transform CameraSlot { get; set; }

        [field: SerializeField]
        private float MoveSpeed { get; set; }

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

            // XPosition = Mathf.Clamp(XPosition, MinX, MaxX);

            CameraSlot.position = new Vector3(XPosition, CameraSlot.position.y, ZPosition);
        }
    }
}
