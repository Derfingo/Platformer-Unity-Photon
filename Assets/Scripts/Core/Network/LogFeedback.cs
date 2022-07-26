using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Network
{
    public class LogFeedback : MonoBehaviour
    {
        [SerializeField] private Text _feedbackText;

        private StringBuilder _feedback;

        private void Start()
        {
            _feedback = new StringBuilder();
            _feedbackText.text = "";
        }

        public void AddLogFeedback(string message)
        {
            if (_feedbackText == null)
            {
                return;
            }

            _feedback.Append(System.Environment.NewLine + message);
            _feedbackText.text = _feedback.ToString();
        }
    }
}
