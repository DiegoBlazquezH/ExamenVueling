using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using TipsCalculator.AutofacConfiguration;

namespace TipsCalculator.Business.Logic.Facade
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.DependencyResolver =
                new AutofacWebApiDependencyResolver(
                    IocConfig.Build(Assembly.GetExecutingAssembly()));

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
