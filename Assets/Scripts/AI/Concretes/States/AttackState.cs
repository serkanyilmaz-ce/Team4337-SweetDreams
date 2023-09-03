using AI.Concretes.Manager;
using Unity.VisualScripting;
using IState = AI.Abstract.IState;
using UnityEngine;
using UnityEngine.AI;

namespace AI.Concretes.States
{
    public class AttackState : IState
    {
        private Transform _target;
        private Transform _transform;
        private NavMeshAgent _agent;
        private Animator _animator;
        private Enemy _enemy;

        public AttackState(Transform target,Transform transform)
        {
            _target = target;
            _transform = transform;
            _animator = _transform.GetComponent<Animator>();
            _enemy = _transform.GetComponent<Enemy>();
            _agent = _transform.GetComponent<NavMeshAgent>();
        }
        public void OnEnter()
        {
            _animator.SetBool("isAttack",true);
        }

        public void OnUpdate()
        {
            float dist = AI_Manager.Instance.GetDistance2D(_agent.transform.position, _target.position);

            if (dist > 1f)
            {
                _enemy.canAttack = false;
            }
        }

        public void OnExit()
        {
            _animator.SetBool("isAttack",false);
        }
    }
}