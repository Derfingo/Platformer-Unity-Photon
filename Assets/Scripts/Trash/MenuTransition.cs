using System;
using System.Collections.Generic;
using UnityEngine;

namespace View
{
    public class MenuTransition : MonoBehaviour
    {
        [SerializeField] private LoginPanel _loginPanel;
        [SerializeField] private SelectionPanel _selectionPanel;
        [SerializeField] private RoomListPanel _roomListPanel;
        [SerializeField] private CreateRoomPanel _createRoomPanel;
        [SerializeField] private LoadingPanel _loadingPanel;

        [SerializeField] private List<BasePanel> _panels;
        public enum Panels
        {

        }

        private void Start()
        {
            Enum.Parse(typeof(Panels), _panels.ToString());
        }

        public void SetActivePanel(BasePanel panel)
        {

        }

        public enum Menus
        {
            LoginPanel,
            SelectionPanel,
            CreateRoomPanel,
            LoadingPanel,
            RoomListPanel
        }
    }
}
