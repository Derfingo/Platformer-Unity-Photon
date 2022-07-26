using UnityEngine;

namespace Core
{
    public class FallDetection : MonoBehaviour
    {
        [SerializeField] private Transform _spawnPosition;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == 6)
            {
                collision.TryGetComponent<Player>(out var player);
                player.Teleport(_spawnPosition);
            }

            if (collision.gameObject.layer == 7)
            {
                Destroy(collision);
            }
        }
    }
}
