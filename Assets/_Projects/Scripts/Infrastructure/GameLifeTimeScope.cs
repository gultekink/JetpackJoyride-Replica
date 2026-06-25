using VContainer;
using VContainer.Unity;
using JetpackJoyrideReplica.Core;
using JetpackJoyrideReplica.Services;

namespace JetpackJoyrideReplica.Infrastructure
{
    public class GameLifeTimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IInputServices, InputService>(Lifetime.Singleton);
        }
    }
}
