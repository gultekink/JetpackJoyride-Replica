using JetpackJoyrideReplica.Core;

namespace JetpackJoyrideReplica.Player.States
{
    public class PlayerRunningState : IState
    {
        private readonly PlayerMotor _playerMotor;
        private readonly IInputServices _input;
        private readonly PlayerStateMachine _playerStateMachine;

        public PlayerRunningState(PlayerMotor playerMotor, PlayerStateMachine playerState, IInputServices inputServices)
        {
            _playerMotor = playerMotor;
            _playerStateMachine = playerState;
            _input = inputServices;
        }

        public void Enter()
        {

        }

        public void Exit()
        {

        }

        public void Tick()
        {
          

            if (_input.IsFlying)
            {
                _playerStateMachine.ToFlying();
            }
        }

        public void FixedTick()
        {
            _playerMotor.MoveForward();
        }

    }

}
