using Platformer.Core.Input;
using Platformer.Core.HealthBar;
using UnityEngine;

namespace Platformer.Core.Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    
    public class Player : MonoBehaviour
    {
        [SerializeField] private Health _playerHealth;
        [SerializeField] private float _forceUp;
        [SerializeField] private float _forceMove;

        private InputManager _inputManager => InputManager.Instance;
        private Rigidbody2D _player;
        private bool _isGround;

        private void Awake() => _player = GetComponent<Rigidbody2D>();

        private void Start()
        {
            _inputManager.EventMoveLeft += MoveLeft;
            _inputManager.EventMoveRight += MoveRight;
            _inputManager.EventJump += Jump;
        }

        private void OnDestroy()
        {
            _inputManager.EventMoveLeft -= MoveLeft;
            _inputManager.EventMoveRight -= MoveRight;
            _inputManager.EventJump -= Jump;
        }

        private void MoveLeft() => AddForceToPlayer(new Vector2(-_forceMove, 0));
        private void MoveRight() => AddForceToPlayer(new Vector2(_forceMove, 0));
        private void Jump()
        {
            if (_isGround)
            {
                AddForceToPlayer(new Vector2(0, _forceUp));
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _isGround = true;
                Debug.Log("Enter");
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _isGround = false;
                Debug.Log("Exit");
            }
        }

        private void AddForceToPlayer(Vector2 force)
        {
            if (_playerHealth.HealthCount <= 0)
            {
                return;
            }

            _player.AddForce(force);
            _playerHealth.DecreaseHealth();
        }
    }
}
