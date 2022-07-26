using Core;
using UnityEngine;

namespace Initialization
{
    public class Initialization : MonoBehaviour
    {
        [SerializeField] private PlayerCreator _playerCreator;
        private PlayerInput _playerInput;

        private void Awake()
        {
            Application.targetFrameRate = 60;
            QualitySettings.vSyncCount = 1;
            Compose();
        }

        private void Compose()
        {
            _playerInput = new PlayerInput();

            _playerCreator.Initialize(_playerInput);
        }
    }
}
