using JetpackJoyrideReplica.Player.States;
using UnityEngine;

namespace JetpackJoyrideReplica.Player
{
    public class PlayerStateMachine
    {
        private IState _runningState;
        private IState _flyingState;

        public IState CurrentState { get; private set; }


        public void Initialize(IState runningState, IState flyingState)
        {
            _runningState = runningState;
            _flyingState = flyingState;
        }

        public void ChangeState(IState state)
        {
            CurrentState?.Exit();
            CurrentState = state;
            CurrentState?.Enter();
        }

        public void Tick()
        {
            CurrentState?.Tick();
        }

        public void FixedTick()
        {
            CurrentState?.FixedTick();
        }

        public void ToRunning()
        {
            ChangeState(_runningState);
        }

        public void ToFlying()
        {
            ChangeState(_flyingState);
        }
    }

}
