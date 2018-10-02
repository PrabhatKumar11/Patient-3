using PatientService.Models;
using RestApi.Models;
using System.Collections.Generic;

namespace PatientService.Interfaces
{
    public interface IPatientService 
    {
        Patient GetPatientById(int Id);
        List<Patient> SearchPatient(string value, int pageNo, int PageSize, Sort sort);
        List<Patient> GetPatients();
    }
}