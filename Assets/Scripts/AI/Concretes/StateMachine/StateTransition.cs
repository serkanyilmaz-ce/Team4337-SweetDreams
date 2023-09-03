using AI.Abstract;

namespace AI.Concretes
{
    public class StateTransition
    {
        public IState From { get; }
        public IState To { get; }
        public System.Func<bool> Condition { get; }

        public StateTransition(IState from, IState to, System.Func<bool> condition)
        {
            From = from;
            To = to;
            Condition = condition;
        }
    }
}