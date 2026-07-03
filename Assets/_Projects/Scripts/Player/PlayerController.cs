using JetpackJoyrideReplica.Core;
using JetpackJoyrideReplica.Player.States;
using UnityEngine;
using VContainer;

namespace JetpackJoyrideReplica.Player
{
    [RequireComponent(typeof(PlayerMotor))]
    public class PlayerController : MonoBehaviour
    {
        private IInputService _inputService;
        private PlayerMotor _playerMotor;

        public PlayerStateMachine StateMachine { get; private set; }
        public PlayerRunningState RunningState { get; private set; }
        public PlayerFlyingState FlyingState { get; private set; }
        public PlayerDeathState DeathState { get; private set; }

        private void Start()
        {
            StateMachine.ChangeState(RunningState);
        }

        private void Update()
        {
            StateMachine.Tick();
        }

        private void FixedUpdate()
        {
            StateMachine.FixedTick();
        }

        [Inject]
        public void Construct(IInputService inputService)
        {
            _inputService = inputService;
            _playerMotor = GetComponent<PlayerMotor>();

            StateMachine = new PlayerStateMachine();
            RunningState = new PlayerRunningState(_playerMotor, StateMachine, _inputService);
            FlyingState = new PlayerFlyingState(_playerMotor, StateMachine, _inputService);
            DeathState = new PlayerDeathState(_playerMotor);

            StateMachine.Initialize(RunningState, FlyingState, DeathState);
        }

        public void Die()
        {
            StateMachine.ToDeath();
        }
    }
}