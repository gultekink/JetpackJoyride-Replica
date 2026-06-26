using JetpackJoyrideReplica.Core;
using UnityEngine;
namespace JetpackJoyrideReplica.Player.States
{
    public class PlayerFlyingState : IState
    {
        private readonly PlayerMotor _playerMotor;
        private readonly IInputServices _input;
        private readonly PlayerStateMachine _playerStateMachine;     

        public PlayerFlyingState(PlayerMotor player, PlayerStateMachine playerState, IInputServices inputServices)
        {
            _playerMotor = player;
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
           
            if (!_input.IsFlying)
            {
                _playerStateMachine.ToRunning();
            }
        }

        public void FixedTick()
        {
            _playerMotor.FlyUp();
            _playerMotor.MoveForward();

        }
    }
}

