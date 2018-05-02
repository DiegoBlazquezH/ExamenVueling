using Autofac;
using TipsCalculator.DataAccess.Redis;

namespace TipsCalculator.AutofacConfiguration
{
    class RedisModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterGeneric(typeof(RedisDaoAsync<>))
                .As(typeof(IGetAsync<>))
                .As(typeof(ISetAsync<>))
                .InstancePerRequest();

            base.Load(builder);
        }
    }
}