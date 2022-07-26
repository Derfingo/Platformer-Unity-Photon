using UnityEngine;

namespace View
{
    public abstract class BasePanel : MonoBehaviour
    {
        public void Activate()
        {
            if (gameObject != null)
            {
                bool isActive = gameObject.activeSelf;
                gameObject.SetActive(!isActive);
            }
        }
    }
}
