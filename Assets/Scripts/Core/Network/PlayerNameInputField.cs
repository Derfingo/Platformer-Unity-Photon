using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Network
{
    public class PlayerNameInputField : MonoBehaviour
    {
        [SerializeField] private LogFeedback _logFeedback;

        private const string PLAYER_NAME_KEY = "PlayerName";

        private void Start()
        {
            string defaultName = string.Empty;
            InputField inputField = GetComponent<InputField>();

            if (inputField != null)
            {
                if (PlayerPrefs.HasKey(PLAYER_NAME_KEY))
                {
                    defaultName = PlayerPrefs.GetString(PLAYER_NAME_KEY);
                    inputField.text = defaultName;
                }
            }

            PhotonNetwork.NickName = defaultName;
        }

        public void SetPlayerName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                Debug.LogError("Player name is empty");
                return;
            }

            PhotonNetwork.NickName = value;
            PlayerPrefs.SetString(PLAYER_NAME_KEY, value);
        }
    }
}
