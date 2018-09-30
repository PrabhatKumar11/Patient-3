using PatientService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientService.Interfaces
{
    public interface ISearchPatient
    {
        List<Patient> Search(List<Patient> patients, string value);
    }
}
