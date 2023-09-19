using UnityEngine;

namespace Platformer.Core.Camera
{
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Transform Player; // Player Object
        [SerializeField] private float _speed = 0.01f; // Speed of camera (Lerp)

        private Transform _camera; // Camera Object

        private void Awake()
        {
            _camera = GetComponent<Transform>();
        }

        private void Update()
        {
            var cameraPosition = _camera.position; // Get position of Camera
            cameraPosition.x = Mathf.Lerp(cameraPosition.x, Player.position.x, _speed); // Edit position

            _camera.position = cameraPosition; // Update Camera position
        }
    }
}