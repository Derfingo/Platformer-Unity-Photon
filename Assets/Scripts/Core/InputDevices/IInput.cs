using System;
using UnityEngine;

namespace Core
{
    public interface IInput
    {
        public event Action<Vector2> OnHorizontalDirection;
        public event Action<Vector2> OnJump;
        public event Action<Vector2> OnLook;
        public event Action OnFire;
    }
}
