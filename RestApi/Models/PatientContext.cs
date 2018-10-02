using PatientService.Interfaces;
using PatientService.Models;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace RestApi.Models
{
    public class PatientContext : DbContext, IPatientContext
    {
        public PatientContext(): base("PatientContext")
        {
            Database.SetInitializer<PatientContext>(null);
        }

        public IDbSet<Patient> Patients { get; set; }
        public IDbSet<Episode> Episodes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}