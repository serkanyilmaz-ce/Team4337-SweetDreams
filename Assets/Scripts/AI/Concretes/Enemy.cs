using System;
using AI.Abstract;
using AI.Concretes.Manager;
using AI.Concretes.States;
using Player.Controllers;
using UnityEngine;
using UnityEngine.AI;

namespace AI.Concretes
{
    public class Enemy : MonoBehaviour,IDamageable
    {
        public bool canAttack;
        public bool isDead;
        public float Health = 100f;

        private IState _runState;
        private IState _attackState;
        private IState _deathState;
        private StateMachine _stateMachine;
        private void Awake()
        {
            _stateMachine = new StateMachine();
            _runState = new GoToDestinationState(AI_Manager.Instance.target, transform);
            _attackState = new AttackState(AI_Manager.Instance.target, transform);
            _deathState = new DeathState(transform);
            
            _stateMachine.AddStateTransition(_runState,_attackState,() => canAttack == true);
            _stateMachine.AddStateTransition(_attackState,_runState,() => canAttack == false);
            _stateMachine.AddAnyStateTransition(_deathState, () => isDead == true);
            _stateMachine.Initialize(_runState);
        }
        private void OnEnable()
        {
            Health = 100f;
            _stateMachine.ChangeState(_runState);
        }

        private void Update()
        {
            _stateMachine.RunMachine();
        }

        public void TakeDamage(float amount)
        {
            Health -= amount;
            isDead = true;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Obstacle"))
            {
                TakeDamage(100f);
            }
        }
    }
}