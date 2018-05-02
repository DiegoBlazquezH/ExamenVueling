using Autofac;
using TipsCalculator.DataAccess.Logic;

namespace TipsCalculator.AutofacConfiguration
{
    class DaoLogicModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType(typeof(DaoLogic))
                .As(typeof(IDaoLogic))
                .InstancePerRequest();

            base.Load(builder);
        }
    }
}