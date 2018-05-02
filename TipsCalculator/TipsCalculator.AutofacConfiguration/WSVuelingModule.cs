using Autofac;
using TipsCalculator.DataAccess.WSVueling;

namespace TipsCalculator.AutofacConfiguration
{
    class WSVuelingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterGeneric(typeof(WSVueling<>))
                .As(typeof(IWSVueling<>))
                .InstancePerRequest();

            base.Load(builder);
        }
    }
}