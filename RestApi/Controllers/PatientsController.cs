using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using RestApi.Models;
using PatientService.Interfaces;
using PatientService.Models;

namespace RestApi.Controllers
{
    public class PatientsController : ApiController
    {
        //initialize service object
        IPatientContext _patientContext;
        IPatientService _patientService;
        public PatientsController(IPatientContext patientContext, IPatientService patientService)
        {
            _patientContext = patientContext;
            _patientService = patientService;
        }
        [HttpGet]
        public Patient GetPatientById(int patientId)
        {
            if (patientId <= 0)
                throw new ArgumentException("Invalid Patient Id.");
            var patient = _patientService.GetPatientById(patientId);
            if (patient != null)
                return patient;
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
        [HttpPost]
        public List<Patient> SearchPatient(string value, int pageNo, int pageSize, Sort sort)
        {
            if (!string.IsNullOrEmpty(value))
                throw new ArgumentException("Invalid Search Input.");
            var patient = _patientService.SearchPatient(value,pageNo, pageSize,sort);
            if (patient != null)
                return patient;
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
        [HttpGet]
        [NonAction]
        public IEnumerable<Patient> GetPatients()
        {
            var patient = _patientService.GetPatients();
            if (patient != null)
                return patient;
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
    }
}