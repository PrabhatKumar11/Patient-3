using Autofac;
using PatientService.Interfaces;
using PatientService.Models.Search;
using System.Configuration;

namespace RestApi.Models
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PatientContext>()
                   .As<IPatientContext>()
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