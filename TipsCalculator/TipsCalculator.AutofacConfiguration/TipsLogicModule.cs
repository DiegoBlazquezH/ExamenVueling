using Autofac;
using TipsCalculator.Business.Logic;

namespace TipsCalculator.AutofacConfiguration
{
    class TipsLogicModule :  Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType(typeof(TipsLogic))
                .As(typeof(ITipsLogic))
                .InstancePerRequest();

            base.Load(builder);
        }
    }
}
