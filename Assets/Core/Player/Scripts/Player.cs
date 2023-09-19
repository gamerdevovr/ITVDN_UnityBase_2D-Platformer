using UnityEngine;

namespace Platformer.Core.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _forceUp;
        [SerializeField] private float _forceLeftRight;

        private Rigidbody2D _player;

        private void Awake()
        {
            _player = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            // Check keyboard keys

            if (Input.GetKey(KeyCode.Space))
            {
                AddForceToPlayer(new Vector2(0, _forceUp)); // Move to up
            }

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                AddForceToPlayer(new Vector2(-_forceLeftRight, 0)); // Move to left
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                AddForceToPlayer(new Vector2(_forceLeftRight, 0)); // Move to right
            }
        }

        private void AddForceToPlayer(Vector2 force)
        {
            _player.AddForce(force); // Add force to player
        }
    }
}
