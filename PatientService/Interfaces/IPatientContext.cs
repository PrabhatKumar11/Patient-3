
using System.Linq;
using PatientService.Models;
using System.Data.Entity;

namespace PatientService.Interfaces
{
    public interface IPatientContext
    {
        IDbSet<Patient> Patients { get; }

        IDbSet<Episode> Episodes { get; }
    }
}