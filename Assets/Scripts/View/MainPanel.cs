using UnityEngine;

namespace View
{
    public class MainPanel : MonoBehaviour
    {
        public void Activate(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}
