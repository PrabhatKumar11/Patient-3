using PatientService.Interfaces;
using PatientService.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace RestApi.Models
{
    public class InMemoryPatientContext : DbContext, IPatientContext
    {
        public InMemoryPatientContext(): base("DefaultConnection")
        {
            Database.SetInitializer<InMemoryPatientContext>(null);
        }

        public IDbSet<Patient> Patients { get; set; }
        public IDbSet<Episode> Episodes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}