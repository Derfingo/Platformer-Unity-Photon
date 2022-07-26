using Photon.Pun;
using Photon.Realtime;
using System.Threading.Tasks;
using UnityEngine;
using View;

namespace Core.Network
{
    public class Launcher : MonoBehaviourPunCallbacks
    {
        #region Private Serializable fields
        [SerializeField] private LoginPanel _loginPanel;
        [SerializeField] private SelectionPanel _selectionPanel;
        [SerializeField] private RoomListPanel _roomListPanel;
        [SerializeField] private CreateRoomPanel _createRoomPanel;
        [SerializeField] private LoadingPanel _loadingPanel;
        [Space]
        [SerializeField] private LogFeedback _feedback;
        [SerializeField] private byte _maxPlayersRoom = 4;

        #endregion

        #region Private fields

        private bool _isConnecting;
        private bool _isQuickStar;
        private string _gameVersion = "0.0.1";

        #endregion

        #region MonoBehaviour callbacks

        private void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        #endregion

        #region Public UI Buttons methods


        // calls with Unity event
        public void OnLoginButtonClicked()
        {
            _isConnecting = true;
            _loginPanel.Activate();

            _feedback.AddLogFeedback("Connecting...");
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = _gameVersion;
        }

        public void OnCreateRoomButtonClicked()
        {
            _selectionPanel.Activate();
            _createRoomPanel.Activate();
        }

        public void OnRoomListButtonClicked()
        {
            if (!PhotonNetwork.InLobby)
            {
                PhotonNetwork.JoinLobby();
            }

            _selectionPanel.Activate();
            _roomListPanel.Activate();
        }

        public void OnCancelButtonClicked()
        {
            // fix menu transition
            _roomListPanel.Activate();
            _selectionPanel.Activate();
        }

        public async void OnQuickStartButtonClicked()
        {
            PhotonNetwork.ConnectUsingSettings();
            await Task.Delay(1000);
            PhotonNetwork.JoinRandomRoom();
        }

        public void QuitApp()
        {
            Application.Quit();
        }

        #endregion

        #region MonoBehaviourPunCallbacks callbacks

        public override void OnConnectedToMaster()
        {
            if (_isConnecting)
            {
                _feedback.AddLogFeedback("On connected to Master: next -> try to join room");
                Debug.Log("Connected to Master");

                _selectionPanel.Activate();
            }
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            _feedback.AddLogFeedback("Join random room is failed: next -> create a new room");
            Debug.Log("Join random room is failed");
            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = _maxPlayersRoom });
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            _feedback.AddLogFeedback("Disconnected " + cause);
            Debug.Log("Disconnected");

            _isConnecting = false;
            _loginPanel.Activate();
        }

        public override void OnJoinedRoom()
        {
            _feedback.AddLogFeedback("Joined room with " + PhotonNetwork.CurrentRoom.PlayerCount + " Player(s)");
            Debug.Log("Joined room");

            if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
            {
                Debug.Log("We load the room for 1");

                PhotonNetwork.LoadLevel("Room");
            }
        }

        #endregion
    }
}
