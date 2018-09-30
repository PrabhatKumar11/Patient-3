using PatientService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientService.Models;

namespace PatientService.Models.Search
{
    public class SearchPatient : ISearchPatient
    {
        public List<Patient> Search(List<Patient> patients, string value)
        {
            if(patients!= null && patients.Any() && !string.IsNullOrEmpty(value))
            {
                return patients.Where(x => x.FirstName.IndexOf(value, StringComparison.CurrentCultureIgnoreCase)!=-1 
                || x.LastName.IndexOf(value, StringComparison.CurrentCultureIgnoreCase) != -1
                || x.NhsNumber.IndexOf(value, StringComparison.CurrentCultureIgnoreCase) != -1).ToList();
            }
            return null;
        }
    }
}
