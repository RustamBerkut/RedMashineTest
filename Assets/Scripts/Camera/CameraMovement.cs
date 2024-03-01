using UnityEngine;

namespace CameraBehaviour
{
    public class CameraMovement : MonoBehaviour
    {
        private Vector3 hit_position = Vector3.zero;
        private Vector3 current_position = Vector3.zero;
        private Vector3 camera_position = Vector3.zero;
        private Rigidbody2D _rigidbody;
        private bool _isCollider;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(myRay)) 
                _isCollider = true;
                else _isCollider = false;
                hit_position = Input.mousePosition;
            }
            if (_isCollider) return;
            if (Input.GetMouseButton(0))
            {
                CameraSmoothMove();
            }
        }
        private void CameraSmoothMove()
        {
            current_position = Input.mousePosition;
            current_position.z = hit_position.z = camera_position.y;
            Vector3 direction = Camera.main.ScreenToWorldPoint(current_position) - Camera.main.ScreenToWorldPoint(hit_position);
            direction *= -1;
            Vector3 position = camera_position + direction;
            _rigidbody.velocity = position;
        }
    }
}
