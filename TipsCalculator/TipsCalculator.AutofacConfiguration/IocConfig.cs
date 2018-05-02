using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;

namespace TipsCalculator.AutofacConfiguration
{
    public class IocConfig
    {
        public static IContainer Build(Assembly ApiAssemblies)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(ApiAssemblies);

            builder.RegisterModule(new RedisModule());

            builder.RegisterModule(new WSVuelingModule());

            builder.RegisterModule(new DaoLogicModule());

            builder.RegisterModule(new TipsLogicModule());

            return builder.Build();
        }
    }
}
