using Autofac;
using Autofac.Integration.WebApi;
using PatientService.Interfaces;
using PatientService.Models.Search;
using RestApi.Controllers;
using System.Configuration;
using System.Reflection;
using System.Web.Http;

namespace RestApi.Models
{
    public class IoCBuilder
    {
        public static IContainer Build()
        {
            var builder = new ContainerBuilder();

            //Register your Web API controllers.  
            builder.RegisterApiControllers(typeof(PatientsController).Assembly);
            builder.RegisterModule(new AutoFacModule());

            var container = builder.Build();
            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;

            return container;
        }
    }
}