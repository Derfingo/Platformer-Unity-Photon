using Photon.Pun;
using Photon.Pun.UtilityScripts;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Network
{
    public class PlayerEntry : MonoBehaviour
    {
        [SerializeField] private Text _playerNameText;

        private int _playerId;

        public void Initialize(int playerId, string playerName)
        {
            _playerId = playerId;
            _playerNameText.text = playerName;
        }

        public void SetPlayerProperties()
        {
            // set custom properties
            PhotonNetwork.LocalPlayer.SetScore(0);

            if (PhotonNetwork.IsMasterClient)
            {
                // is ready
            }
        }

        private void OnPlayerNumberingChanged()
        {
            foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
            {
                if (player.ActorNumber == _playerId)
                {
                    // set color for image
                }
            }
        }

        private void OnEnable()
        {
            PlayerNumbering.OnPlayerNumberingChanged += OnPlayerNumberingChanged;
        }

        private void OnDisable()
        {
            PlayerNumbering.OnPlayerNumberingChanged -= OnPlayerNumberingChanged;
        }
    }
}