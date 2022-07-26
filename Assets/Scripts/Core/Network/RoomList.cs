using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Network
{
    public class RoomList : MonoBehaviourPunCallbacks
    {
        [SerializeField] private RoomEntry _roomEntryPrefab;
        [SerializeField] private Transform _ScrollViewContent;

        private Dictionary<string, RoomInfo> _cachedRoomList;
        private Dictionary<string, RoomEntry> _roomListEntries;

        private void Start()
        {
            _cachedRoomList = new Dictionary<string, RoomInfo>();
            _roomListEntries = new Dictionary<string, RoomEntry>();
        }

        private void UpdateCachedRoomList(List<RoomInfo> roomList)
        {
            foreach (RoomInfo info in roomList)
            {
                if (!info.IsOpen || !info.IsVisible || info.RemovedFromList)
                {
                    if (_cachedRoomList.ContainsKey(info.Name))
                    {
                        _cachedRoomList.Remove(info.Name);
                    }

                    continue;
                }

                if (_cachedRoomList.ContainsKey(info.Name))
                {
                    _cachedRoomList[info.Name] = info;
                }
                else
                {
                    _cachedRoomList.Add(info.Name, info);
                }
            }
        }

        private void UpdateRoomListEntries()
        {
            foreach (RoomInfo info in _cachedRoomList.Values)
            {
                RoomEntry entry = Instantiate(_roomEntryPrefab, _ScrollViewContent);
                entry.Initialize(info.Name, (byte)info.PlayerCount, info.MaxPlayers);
                _roomListEntries.Add(info.Name, entry);
            }
        }

        private void ClearRoomListEnties()
        {
            foreach (RoomEntry entry in _roomListEntries.Values)
            {
                Destroy(entry);
            }

            _roomListEntries.Clear();
        }

        public override void OnRoomListUpdate(List<RoomInfo> roomList)
        {
            Debug.Log("Update room list");
            ClearRoomListEnties();
            UpdateCachedRoomList(roomList);
            UpdateRoomListEntries();
        }

        public override void OnJoinedLobby()
        {
            Debug.Log("Joined lobby");
            _cachedRoomList?.Clear();
            ClearRoomListEnties();
        }

        public override void OnLeftLobby()
        {
            Debug.Log("Left lobby");
            _cachedRoomList.Clear();
            ClearRoomListEnties();
        }

        public override void OnJoinedRoom()
        {
            _cachedRoomList.Clear();
            // add player entries
        }

        public override void OnLeftRoom()
        {
            // clean up player entries
        }
    }
}
