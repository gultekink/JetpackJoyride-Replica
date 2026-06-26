using JetpackJoyrideReplica.Core;
using JetpackJoyrideReplica.Player.States;
using UnityEngine;
using VContainer;

namespace JetpackJoyrideReplica.Player
{
    [RequireComponent(typeof(PlayerMotor))]
    public class PlayerController : MonoBehaviour
    {
        private PlayerMotor _playerMotor;
        private IInputServices _inputService;

        public PlayerStateMachine StateMachine { get; private set; }
        public PlayerRunningState RunningState { get; private set; }
        public PlayerFlyingState FlyingState { get; private set; }

        [Inject]
        public void Construct(IInputServices inputService)
        {
            _inputService = inputService;
            _playerMotor = GetComponent<PlayerMotor>();

            StateMachine = new PlayerStateMachine();
            RunningState = new PlayerRunningState(_playerMotor, StateMachine, _inputService);
            FlyingState = new PlayerFlyingState(_playerMotor, StateMachine, _inputService);

            StateMachine.Initialize(RunningState, FlyingState);
        }
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

        
    }

}
