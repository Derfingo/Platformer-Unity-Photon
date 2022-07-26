using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Core
{
    public class PlayerInput : IInput
    {
        public event Action<Vector2> OnHorizontalDirection;
        public event Action<Vector2> OnJump;
        public event Action<Vector2> OnLook;
        public event Action OnFire;

        private readonly InputDevices _input;

        public PlayerInput()
        {
            _input = new InputDevices();
            _input.Enable();
            AddListeners();
        }

        private void DetectHorizontalInput(InputAction.CallbackContext context)
        {
            OnHorizontalDirection?.Invoke(context.ReadValue<Vector2>());
        }

        private void DetectJump(InputAction.CallbackContext context)
        {
            OnJump?.Invoke(context.ReadValue<Vector2>());
        }

        private void DetectLook(InputAction.CallbackContext context)
        {
            OnLook?.Invoke(context.ReadValue<Vector2>());
        }

        private void DetectFire()
        {
            OnFire?.Invoke();
        }

        private void AddListeners()
        {
            _input.Player.HorizontalMove.performed += context => DetectHorizontalInput(context);
            _input.Player.Jump.performed += context => DetectJump(context);
            _input.Player.Look.performed += context => DetectLook(context);
            _input.Player.Fire.performed += context => DetectFire();
        }

        private void RemoveListeners()
        {
            _input.Player.HorizontalMove.performed -= context => DetectHorizontalInput(context);
            _input.Player.Jump.performed -= context => DetectJump(context);
            _input.Player.Look.performed -= context => DetectLook(context);
            _input.Player.Fire.performed -= context => DetectFire();
        }
    }
}

