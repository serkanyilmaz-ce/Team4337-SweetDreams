using AI.Abstract;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI.Concretes
{
    public class StateMachine
    {
        IState _currentState;

        readonly List<StateTransition> _stateTransitions;
        readonly List<StateTransition> _anyTransitions;
        public StateMachine()
        {
            _stateTransitions = new List<StateTransition>();
            _anyTransitions = new List<StateTransition>();
        }

        public void Initialize(IState startingState)
        {
            if (_currentState != null) return;

            _currentState = startingState;
            _currentState.OnEnter();
        }

        public void ChangeState(IState state)
        {
            if (state.Equals(_currentState)) return;

            _currentState?.OnExit();
            _currentState = state;
            _currentState.OnEnter();
        }

        public void RunMachine()
        {
            IState state = CheckState();

            if (state != null)
            {
                ChangeState(state);
            }

            _currentState.OnUpdate();
        }

        private IState CheckState()
        {
            foreach (var stateTransition in _anyTransitions)
            {
                if (stateTransition.Condition.Invoke())
                {
                    return stateTransition.To;
                }
            }

            foreach (var stateTransition in _stateTransitions)
            {
                if (stateTransition.Condition.Invoke() && stateTransition.From.Equals(_currentState))
                {
                    return stateTransition.To;
                }
            }

            return null;
        }

        public void AddStateTransition(IState from, IState to, System.Func<bool> condition)
        {
            _stateTransitions.Add(new StateTransition(from, to, condition));
        }

        public void AddAnyStateTransition(IState to, System.Func<bool> condition)
        {
            _anyTransitions.Add(new StateTransition(null, to, condition));
        }
    }
}