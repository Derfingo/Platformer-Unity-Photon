using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Network
{
    public class RoomCreator : MonoBehaviourPunCallbacks
    {
        [SerializeField] private InputField _roomNameInputField;
        [SerializeField] private InputField _maxPlayersInputField;
        [SerializeField] private LogFeedback _feedback;

        private const int MAX_PLAYERS_IN_ROOM = 10;

        // calls with Unity event
        public void OnCreateRoomButtonClicked()
        {
            if (_roomNameInputField.Equals(string.Empty) || _roomNameInputField == null)
            {
                _feedback.AddLogFeedback("invalid name room");
                Debug.Log("invalid name room");
                return;
            }

            string roomName = _roomNameInputField.text;

            byte.TryParse(_maxPlayersInputField.text, out byte maxPlayers);

            if (maxPlayers > MAX_PLAYERS_IN_ROOM)
            {
                _feedback.AddLogFeedback("invalid value -> max players is 10");
                Debug.Log("invalid value players");
                return;
            }

            // TypedLobby
            RoomOptions options = new RoomOptions { MaxPlayers = maxPlayers, PlayerTtl = 10000 };
            PhotonNetwork.CreateRoom(roomName, options, null);
            Debug.Log("Joined room");
        }
    }
}
