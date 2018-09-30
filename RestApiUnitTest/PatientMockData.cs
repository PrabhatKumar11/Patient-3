using PatientService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiUnitTest
{
    public class PatientMockData
    {
        public static Patient GetPatientMockDateById()
        {
            Patient patient = new Patient
            {
                DateOfBirth = new DateTime(1972, 10, 27),
                FirstName = "Millicent",
                PatientId = 1,
                LastName = "Hammond",
                NhsNumber = "1111111111",
                Episodes = new List<Episode>
                {
                    new Episode
                        {
                            AdmissionDate = new DateTime(2014, 11, 12),
                            Diagnosis = "Irritation of inner ear",
                            DischargeDate = new DateTime(2014, 11, 27),
                            EpisodeId = 1,
                            PatientId = 1
                        },
                    new Episode
                        {
                            AdmissionDate = new DateTime(2015, 3, 20),
                            Diagnosis = "Sprained wrist",
                            DischargeDate = new DateTime(2015, 4, 2),
                            EpisodeId = 2,
                            PatientId = 1
                        },
                    new Episode
                        {
                            AdmissionDate = new DateTime(2015, 11, 12),
                            Diagnosis = "Stomach cramps",
                            DischargeDate = new DateTime(2015, 11, 14),
                            EpisodeId = 3,
                            PatientId = 1
                        }
                }
            };
            return patient;
        }
    }
}
