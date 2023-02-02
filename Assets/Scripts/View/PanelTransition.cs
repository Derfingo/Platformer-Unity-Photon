using System.Collections.Generic;
using UnityEngine;
using View;

namespace Assets.Scripts.View
{
    public class PanelTransition : BasePanel
    {
        [SerializeField] private MainPanel _mainPanel;
        [SerializeField] private LoginPanel _loginPanel;
        [SerializeField] private RoomListPanel _roomList;
        [SerializeField] private SelectionPanel _selectionPanel;
        [SerializeField] private CreateRoomPanel _createRoomPanel;
        [SerializeField] private LoadingPanel _loadingPanel;

        private Dictionary<PanelType, BasePanel> _panels;
        private BasePanel _currentPanel;
        private BasePanel _previousPanel;

        private void Start()
        {
            _panels = new Dictionary<PanelType, BasePanel>
            {
                { PanelType.Main, _mainPanel },
                { PanelType.Login, _loginPanel },
                { PanelType.RoomList, _roomList },
                { PanelType.Selection, _selectionPanel },
                { PanelType.CreatingRoom, _createRoomPanel },
                { PanelType.Loading, _loadingPanel }
            };

            _currentPanel = _mainPanel;
            _previousPanel = _mainPanel;
        }

        public void SwitchPanel(PanelType type)
        {
            if (_panels.ContainsKey(type))
            {
                _currentPanel.Hide();
                BasePanel panel = _panels[type];
                _previousPanel = _currentPanel;
                _currentPanel = panel;
                _currentPanel.Show();
            }
            else
            {
                Debug.Log("Panel is not found");
            }
        }

        public void SwitchPreviousPanel(PanelType type)
        {
            _currentPanel.Hide();
            _currentPanel = _previousPanel;
            _currentPanel.Show();
        }
    }

    public enum PanelType
    {
        Main,
        Login,
        RoomList,
        Selection,
        CreatingRoom,
        Loading,
        Back
    }
}
