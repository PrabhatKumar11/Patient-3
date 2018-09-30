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
        //private static readonly string conString = ConfigurationManager.AppSettings["Connection"].ToString();
        public static IContainer Build(string conString="")
        {
            if(string.IsNullOrEmpty(conString))
            {
                conString = "PatientContext";
            }
            var builder = new ContainerBuilder();

            //Register your Web API controllers.  
            builder.RegisterApiControllers(typeof(PatientsController).Assembly);
            builder.RegisterModule(new AutoFacModule(conString));

            var container = builder.Build();
            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;

            return container;
        }
    }
}