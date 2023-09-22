using UnityEngine;

namespace Platformer.Core.Camera
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private float _lerpSpeed = 0.01f;
        [SerializeField] private Vector3 _offsetCamera;

        private void LateUpdate() // Йде оновлення після усіх айпдейтів
        {
            Vector3 newCamPosition = _player.position + _offsetCamera;
            transform.position = Vector3.Lerp(transform.position, newCamPosition, _lerpSpeed);
        }
    }
}