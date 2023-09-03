using AI.Abstract;
using AI.Concretes.Manager;
using UnityEngine;

namespace AI.Concretes.States
{
    public class DeathState : IState
    {
        private Transform _transform;
        private Animator _animator;
        private Collider _collider;
        private Enemy _enemy;
        private float _counter;
        private float _waitTime;
        private bool isOrder;
        
        public DeathState(Transform transform)
        {
            _transform = transform;
            _animator = _transform.GetComponent<Animator>();
            _collider = _transform.GetComponent<Collider>();
            _enemy = _transform.GetComponent<Enemy>();
        }
        public void OnEnter()
        {
            _counter = 0f;
            _waitTime = 2f;
            _collider.enabled = false;
            _animator.SetTrigger("DeadTrigger");
        }

        public void OnUpdate()
        {
            if (isOrder) return;
            
            _counter += Time.deltaTime;

            if (_counter >= _waitTime)
            {
                AI_Manager.Instance.Despawn(_enemy);
                isOrder = true;
            }
        }
        public void OnExit()
        {
            isOrder = false;
            _collider.enabled = true;
        }
    }
}