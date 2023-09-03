using Inputs.Abstract;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Inputs.Concretes
{
    public class InputReader : IInputReader
    {
        private PlayerInput _playerInput;
        public Vector3 Direction { get; private set; }
        public Vector2 MousePosition { get; private set; }
        public bool IsPressedLeftClick { get; private set; }
        public InputReader(PlayerInput playerInput)
        {
            _playerInput = playerInput;
            _playerInput.currentActionMap.actions[0].performed += Move;
            _playerInput.currentActionMap.actions[1].performed += MouseLook;
            _playerInput.currentActionMap.actions[2].performed += Shoot;
            _playerInput.currentActionMap.actions[2].canceled += ShootRelease;
            _playerInput.currentActionMap.Enable();
        }
        private void ShootRelease(InputAction.CallbackContext context)
        {
            IsPressedLeftClick = false;
        }
        private void Shoot(InputAction.CallbackContext context)
        {
            IsPressedLeftClick = context.action.triggered;
        }
        private void MouseLook(InputAction.CallbackContext context)
        {
            MousePosition = context.ReadValue<Vector2>();
        }
        private void Move(InputAction.CallbackContext context)
        {
            Vector3 direction2D = context.ReadValue<Vector2>();
            Direction = new Vector3(direction2D.x, 0, direction2D.y);
        }
    }
}