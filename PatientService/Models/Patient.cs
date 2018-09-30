using System;
using System.Collections.Generic;

namespace PatientService.Models
{
    public class Patient
    {
        public int PatientId { get; set; }

        public string NhsNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public IEnumerable<Episode> Episodes { get; set; }
    }
}