using UnityEngine;

namespace Core
{
    public class Player : MonoBehaviour
    {
        public void Teleport(Transform position)
        {
            transform.position = position.position;
        }
    }
}
