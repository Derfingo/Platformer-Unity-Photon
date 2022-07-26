using UnityEngine;

namespace Core
{
    public class CameraFollowing : MonoBehaviour
    {
        [SerializeField] private float _smoothSpeed = 5f;
        private Camera _camera;
        private Vector3 _centerOffset;

        private void Start()
        {
            _camera = Camera.main;
            _centerOffset = new Vector3(0, 2f);
            Cut();
        }

        private void LateUpdate()
        {
            FollowTarget();
        }

        private void FollowTarget()
        {
            _camera.transform.position = Vector3.Lerp(_camera.transform.position, transform.position + _centerOffset, _smoothSpeed * Time.deltaTime);
        }

        private void Cut()
        {
            _camera.transform.position = transform.position;
        }
    }
}
