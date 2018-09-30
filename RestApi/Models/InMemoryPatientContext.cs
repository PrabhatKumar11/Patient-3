using PatientService.Interfaces;
using PatientService.Models;
using System.Data.Entity;


namespace RestApi.Models
{
    public class InMemoryPatientContext : IPatientContext
    {
        private readonly InMemoryDbSet<Patient> _patients = new InMemoryDbSet<Patient>();
        private readonly InMemoryDbSet<Episode> _episodes = new InMemoryDbSet<Episode>();

        public IDbSet<Patient> Patients
        {
            get { return _patients; }
        }

        public IDbSet<Episode> Episodes
        {
            get { return _episodes; }
        }
    }
}