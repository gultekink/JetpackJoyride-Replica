using JetpackJoyrideReplica.Player.States;

namespace JetpackJoyrideReplica.Player
{
    public class PlayerStateMachine
    {
        private IState _runningState;
        private IState _flyingState;
        private IState _deathState;

        public IState CurrentState { get; private set; }


        public void Initialize(IState runningState, IState flyingState, IState deathState)
        {
            _runningState = runningState;
            _flyingState = flyingState;
            _deathState = deathState;
        }

        public void ChangeState(IState state)
        {
            if (state == CurrentState) 
                return; 

            CurrentState?.Exit();
            CurrentState = state;
            CurrentState?.Enter();
        }

        public void Tick( )
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

        public void ToDeath()
        {
            ChangeState(_deathState);
        }
    }

}
