using VContainer;
using VContainer.Unity;
using JetpackJoyrideReplica.Core;
using JetpackJoyrideReplica.Services;
using JetpackJoyrideReplica.Player;

namespace JetpackJoyrideReplica.Infrastructure
{
    public class GameLifeTimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IInputService, InputService>(Lifetime.Singleton);
            builder.RegisterComponentInHierarchy<PlayerController>();
        }
    }
}
