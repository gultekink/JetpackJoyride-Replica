using JetpackJoyrideReplica.Core;
using JetpackJoyrideReplica.Player;
using JetpackJoyrideReplica.Services;
using VContainer;
using VContainer.Unity;

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