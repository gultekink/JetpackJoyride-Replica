namespace JetpackJoyrideReplica.Player.States
{
    public interface IState
    {
        void Enter();
        void Tick();
        void FixedTick();
        void Exit();
    }
}