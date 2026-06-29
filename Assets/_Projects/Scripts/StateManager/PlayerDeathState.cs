namespace JetpackJoyrideReplica.Player.States
{
    public class PlayerDeathState : IState
    {
        private readonly PlayerMotor _playerMotor;

        public PlayerDeathState(PlayerMotor playerMotor)
        {
            _playerMotor = playerMotor;
        }


        public void Enter()
        {
            _playerMotor.StopAction();
           
        }

        public void Exit()
        {
            
        }

        public void FixedTick()
        {
            
        }

        public void Tick()
        {
           
        }

    }

}
