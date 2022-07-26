using UnityEngine;

namespace Core
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Movement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private Transform _overlapPoint;
        [SerializeField] private float _overlapRadius;
        [SerializeField] private LayerMask _surfaceType;
        [Space]
        [SerializeField, Range(1f, 10f)] private float _speed;
        [SerializeField, Range(0.1f, 0.5f)] private float _jumpTime;
        [SerializeField, Range(1f, 10f)] private float _jumpForce;

        private IInput _input;
        private Vector2 _horizontalOffset;
        private Vector2 _verticalOffset;
        private float _jumpTimeCounter;
        private bool _isGround;
        private bool _isJumping;

        public void Initialize(IInput input)
        {
            _input = input;
            _rigidbody2D.freezeRotation = true;
            AddListeners();
        }

        private void FixedUpdate()
        {
            var delta = Time.fixedDeltaTime;
            Move(_horizontalOffset, delta);
        }

        private void Update()
        {
            var delta = Time.deltaTime;
            _isGround = Physics2D.OverlapCircle(_overlapPoint.position, _overlapRadius, _surfaceType);

            if (_isGround)
            {
                _isJumping = true;
                _jumpTimeCounter = _jumpTime;
                Jump(_verticalOffset, delta);
            }

            if (_verticalOffset != Vector2.zero && _isJumping)
            {
                JumpWithDuration(_verticalOffset, delta);
            }
            else
            {
                _isJumping = false;
            }
        }

        private void Move(Vector2 direction, float delta)
        {
            _rigidbody2D.velocity = new Vector3(direction.x * _speed, _rigidbody2D.velocity.y);
        }

        private void Jump(Vector2 direction, float delta)
        {
            _rigidbody2D.velocity = _jumpForce * direction;
        }

        private void JumpWithDuration(Vector2 direction, float delta)
        {
            if (_jumpTimeCounter > 0f)
            {
                _rigidbody2D.velocity = _jumpForce * direction;
                _jumpTimeCounter -= delta;
            }
            else
            {
                _isJumping = false;
            }
        }

        private void AddListeners()
        {
            _input.OnHorizontalDirection += (direction => _horizontalOffset = direction);
            _input.OnJump += (up => _verticalOffset = up);
        }

        private void RemoveListeners()
        {
            _input.OnHorizontalDirection -= (direction => _horizontalOffset = direction);
            _input.OnJump -= (up => _verticalOffset = up);
        }
    }
}

