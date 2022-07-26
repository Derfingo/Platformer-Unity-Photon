using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Network
{
    public class RoomEntry : MonoBehaviour
    {
        [SerializeField] private Text _roomNameText;
        [SerializeField] private Text _RoomAmountPlayerText;
        [SerializeField] private Button _joinRoomButton;

        private string _roomName;

        public void Initialize(string roomName, byte currentPlayers, byte maxPlayers)
        {
            _roomName = roomName;
            _roomNameText.text = roomName;
            _RoomAmountPlayerText.text = currentPlayers + " / " + maxPlayers;
        }

        private void Start()
        {
            _joinRoomButton.onClick.AddListener(JoinRoom);
        }

        private void JoinRoom()
        {
            if (PhotonNetwork.InLobby)
            {
                PhotonNetwork.LeaveLobby();
            }

            PhotonNetwork.JoinRoom(_roomName);
        }

        private void OnDisable()
        {
            _joinRoomButton.onClick.RemoveListener(JoinRoom);
        }
    }
}