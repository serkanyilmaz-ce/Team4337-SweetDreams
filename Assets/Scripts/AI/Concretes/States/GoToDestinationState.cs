using AI.Abstract;
using AI.Concretes.Manager;
using UnityEngine;
using UnityEngine.AI;

namespace AI.Concretes.States
{
    public class GoToDestinationState : IState
    {
        private Transform _target;
        private Transform _transform;
        private NavMeshAgent _agent;
        private Animator _animator;
        private Enemy _enemy;

        public GoToDestinationState(Transform target, Transform transform)
        {
            _target = target;
            _transform = transform;
            _agent = _transform.GetComponent<NavMeshAgent>();
            _animator = _transform.GetComponent<Animator>();
            _enemy = _transform.GetComponent<Enemy>();
        }
        public void OnEnter()
        {
            _agent.isStopped = false;
            _agent.destination = _target.position;
            _animator.SetBool("isRun",true);
        }
        public void OnUpdate()
        {
            float dist = AI_Manager.Instance.GetDistance2D(_agent.transform.position, _target.position);

            if (dist <= 1f)
            {
                _enemy.canAttack = true;
            }
            else
            {
                _agent.destination = _target.position;
            }
        }
        public void OnExit()
        {
            _agent.isStopped = true;
            _animator.SetBool("isRun",false);
        }
    }
}