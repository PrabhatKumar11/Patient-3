using Autofac;
using PatientService.Interfaces;
using PatientService.Models.Search;
using PatientService.Interfaces;
using System.Configuration;

namespace RestApi.Models
{
    public class AutoFacModule : Module
    {
        private readonly string conString;
        public AutoFacModule(string con)
        {
            conString = con; 
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PatientContext>()
                  .As<IPatientContext>()
                  .WithParameter(new TypedParameter(typeof(string), conString))
                  .InstancePerLifetimeScope();

            builder.RegisterType<PatientService>()
                   .As<IPatientService>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<SearchPatient>()
                  .As<ISearchPatient>()
                  .InstancePerLifetimeScope();

        }
    }
}