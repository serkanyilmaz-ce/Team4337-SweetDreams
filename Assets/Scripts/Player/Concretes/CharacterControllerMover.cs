using System;
using Player.Abstract;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player.Concretes
{
    public class CharacterControllerMover : IMover
    {
        private CharacterController _controller;
        private PlayerController _playerController;
        public CharacterControllerMover(PlayerController playerController)
        {
            _playerController = playerController;
            _controller = _playerController.GetComponent<CharacterController>();
        }
        public void MoveAction(Vector3 Direction, float moveSpeed)
        {
            if (Direction.magnitude == 0) return;
            
            Vector3 movement = Direction * moveSpeed * Time.deltaTime;
            _controller.Move(movement);
        }
        public void RotateAction(Vector2 Direction)
        {
            Ray ray = Camera.main.ScreenPointToRay(Direction);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayDistance;

            if (groundPlane.Raycast(ray, out rayDistance))
            {
                Vector3 point = ray.GetPoint(rayDistance);

                Vector3 correctedPoint = new Vector3(point.x, _controller.transform.GetChild(0).position.y, point.z);
                _controller.transform.GetChild(0).LookAt(correctedPoint);
            }
        }

        public void PlayButtonAction()
        {
            SceneManager.LoadScene("Level_Dream_01");
        }
    }
}