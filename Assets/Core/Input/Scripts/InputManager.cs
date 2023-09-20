using System;
using UnityEngine;

namespace Platformer.Core.Input
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance;

        public event Action EventMoveLeft;
        public event Action EventMoveRight;
        public event Action EventJump;

        private Controls _controls;

        private void Awake()
        {
            _controls = new Controls();

            _controls.Main.MoveLeft.performed += context => MoveLeft();
            _controls.Main.MoveRight.performed += context => MoveRight();
            _controls.Main.Jump.performed += context => Jump();

            if (Instance == null)
            {
                Instance = this as InputManager;
                DontDestroyOnLoad(gameObject);
                return;
            }
            Destroy(Instance.gameObject);
        }

        private void OnEnable() => _controls.Enable();
        private void OnDisable() => _controls.Disable();
        private void MoveLeft() => EventMoveLeft?.Invoke();
        private void MoveRight() => EventMoveRight?.Invoke();
        private void Jump() => EventJump?.Invoke();
    }
}
     