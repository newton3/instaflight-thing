using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Autofac;
using Autofac.Integration.WebApi;
using Instaflight.Service;
using Microsoft.Owin;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NLog;
using Owin;

[assembly: OwinStartup(typeof(Instaflight_thing.Startup))]
namespace Instaflight_thing
{
    public class Startup
    {
        private static Logger Logger = LogManager.GetCurrentClassLogger();

        public void Configuration(IAppBuilder app)
        {
            Logger.Info("Startup");
            Logger.Info("Initializing WebApi");
            var config = new HttpConfiguration();
            var builder = new ContainerBuilder();

            //Build dependencies here

            builder
            .Register(o =>
                ServiceFactory.ServiceWithOauth<IInstaflightApi>("https://api.sabre.com"))
                    .As<IInstaflightApi>()
                    .InstancePerRequest();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);

            SwaggerConfig.Register(config);
            WebApiConfig.Register(config);
            config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            app.UseWebApi(config);

            Logger.Info("Startup Complete");
        }
    }
}