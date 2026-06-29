using JetpackJoyrideReplica.Core;

namespace JetpackJoyrideReplica.Player.States
{
    public class PlayerRunningState : IState
    {
        private readonly PlayerMotor _playerMotor;
        private readonly IInputService _input;
        private readonly PlayerStateMachine _playerStateMachine;

        public PlayerRunningState(PlayerMotor playerMotor, PlayerStateMachine playerState, IInputService inputServices)
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
            _playerMotor.MoveForward();
            if (_input.IsFlying)
            {
                _playerStateMachine.ToFlying();
            }
        }

        public void FixedTick()
        {

        }

    }

}
