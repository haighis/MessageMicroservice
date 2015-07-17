using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Akka.Actor;
using Akka.Configuration;
using Akka.Configuration.Hocon;
using Akka.Routing;
using DataModel;

namespace WebApplication
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //var section = (AkkaConfigurationSection)ConfigurationManager.GetSection("akka");

            //var _clusterConfig = section.AkkaConfig;

            //var config = ConfigurationFactory.ParseString("akka.remote.helios.tcp.port=" + 0).WithFallback(_clusterConfig);

            var system = ActorSystem.Create("GroupRouterSystem");

            var actor = system.ActorOf(Props.Empty.WithRouter(FromConfig.Instance), "test-group");

            actor.Tell(new Message("test from startup", Guid.NewGuid()));

            SystemActors.TodoCoordinator = actor;

        }
    }
}
