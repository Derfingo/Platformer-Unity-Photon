using Photon.Pun;
using UnityEngine;

namespace Core
{
    public class PlayerCreator : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPosition;

        private IInput _input;

        public void Initialize(IInput input)
        {
            _input = input;

            Create();
        }

        private void Create()
        {
            var player = PhotonNetwork.Instantiate("PlayerPrefab", _spawnPosition.position, Quaternion.identity);
            var movement = player.GetComponent<Movement>();
            var aim = player.GetComponent<Aim>();
            movement.Initialize(_input);
            aim.Initialize(_input);
        }
    }
}
