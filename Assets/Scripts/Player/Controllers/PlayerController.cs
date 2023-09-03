using System;
using System.Collections;
using System.Collections.Generic;
using Inputs.Abstract;
using Inputs.Concretes;
using Player.Abstract;
using Player.Concretes;
using Player.Controllers;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    private IInputReader _inputReader;
    private IMover _mover;
    private Vector3 _direction;
    private PlayerShooterController shooter;
    private void Awake()
    {
        _inputReader = new InputReader(GetComponent<PlayerInput>());
        shooter = GetComponent<PlayerShooterController>();
        _mover = new CharacterControllerMover(this);
    }
    private void Update()
    {
        _direction = _inputReader.Direction;
        _mover.RotateAction(_inputReader.MousePosition);

        if (_inputReader.IsPressedLeftClick)
        {
            shooter.StartFiring(new Vector3(_inputReader.MousePosition.x, transform.position.y,_inputReader.MousePosition.y));
            /*shooter.Shoot();*/
        }
    }
    private void FixedUpdate()
    {
        _mover.MoveAction(_direction, _moveSpeed);
    }
}
