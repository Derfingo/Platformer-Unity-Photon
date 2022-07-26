using Photon.Pun;
using UnityEngine;

namespace Core
{
    public class Aim : MonoBehaviour
    {
        [SerializeField] private Transform _aimPosition;
        [SerializeField] private Transform _bulletPosition;
        private IInput _input;
        private Vector2 _targetPosition;
        private readonly float _bulletForce = 50f;

        public void Initialize(IInput input)
        {
            _input = input;

            AddListeners();
        }

        private void Update()
        {
            var aimDirection = (_targetPosition - (Vector2)transform.position).normalized;
            float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
            _aimPosition.eulerAngles = new Vector3(0, 0, angle);
        }

        private void Fire()
        {
            var bullet = PhotonNetwork.Instantiate("BulletPrefab", _bulletPosition.position, Quaternion.identity);
            var rigidbody2D = bullet.GetComponent<Rigidbody2D>();
            var direction = (_targetPosition - (Vector2)transform.position).normalized;
            rigidbody2D.AddForce(direction * _bulletForce, ForceMode2D.Impulse);
        }

        private void AddListeners()
        {
            _input.OnLook += (position) => _targetPosition = Camera.main.ScreenToWorldPoint(position);
            _input.OnFire += Fire;
        }

        private void RemoveListeners()
        {
            _input.OnLook -= (position) => _targetPosition = Camera.main.ScreenToWorldPoint(position);
            _input.OnFire -= Fire;
        }
    }
}
