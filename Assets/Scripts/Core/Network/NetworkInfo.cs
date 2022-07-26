using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Network
{
    public class NetworkInfo : MonoBehaviourPunCallbacks
    {
        [SerializeField] private Text _pingText;

        private void Update()
        {
            _pingText.text = PhotonNetwork.NetworkingClient.LoadBalancingPeer.RoundTripTime.ToString();
        }
    }
}
