﻿using PatientService.Interfaces;
using PatientService.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using PatientService.Models.Search;

namespace RestApi.Models
{
    public class PatientService : IPatientService
    {
        private IPatientContext _patientContext;
        public PatientService(IPatientContext context)
        {
            _patientContext = context;
        }
        public Patient GetPatientById(int patientId)
        {
            var patientsAndEpisodes =
                from p in _patientContext.Patients
                join e in _patientContext.Episodes on p.PatientId equals e.PatientId
                where p.PatientId == patientId
                select new { p, e };

            if (patientsAndEpisodes.Any())
            {
                var first = patientsAndEpisodes.First().p;
                first.Episodes = patientsAndEpisodes.Select(x => x.e).ToArray();
                return first;
            }
            return null;
        }

        public List<Patient> SearchPatient(string value, int pageNo, int pageSize, Sort sort)
        {
            var patients = GetPatients();
            var patientsFound = new SearchPatient().Search(patients, value);
            if (pageNo <= 0)
                pageNo = 1;
            if (pageSize <= 1)
                pageSize = 20;
            //Paging
            var result = patientsFound.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList();
            //Ordering
            return SortPatient(sort, result);
        }
        private List<Patient> SortPatient(Sort sort, List<Patient> patients)
        {
            List<Patient> patientList = new List<Patient>();
            switch (sort.FieldName.ToLower())
            {
                case "patientid":
                    {
                        patientList = sort.SortOrder.Equals("ASC", StringComparison.CurrentCultureIgnoreCase)
                            ? patients.OrderBy(x => x.PatientId).ToList()
                            : patients.OrderByDescending(x => x.PatientId).ToList();
                    }
                    break;
                case "firstname":
                    {
                        patientList = sort.SortOrder.Equals("ASC", StringComparison.CurrentCultureIgnoreCase)
                            ? patients.OrderBy(x => x.FirstName).ToList()
                            : patients.OrderByDescending(x => x.FirstName).ToList();
                    }
                    break;
                case "lastname":
                    {
                        patientList = sort.SortOrder.Equals("ASC", StringComparison.CurrentCultureIgnoreCase)
                            ? patients.OrderBy(x => x.LastName).ToList()
                            : patients.OrderByDescending(x => x.LastName).ToList();
                    }
                    break;
                case "nhsnumber":
                    {
                        patientList = sort.SortOrder.Equals("ASC", StringComparison.CurrentCultureIgnoreCase)
                            ? patients.OrderBy(x => x.NhsNumber).ToList()
                            : patients.OrderByDescending(x => x.NhsNumber).ToList();
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid input");
            }
            return patientList;
        }

        public List<Patient> GetPatients()
        {
            var patients = new List<Patient>();
            var patientsAndEpisodes =
                from p in _patientContext.Patients
                join e in _patientContext.Episodes on p.PatientId equals e.PatientId
                select new { p, e };

            if (patientsAndEpisodes.Any())
            {
                var first = patientsAndEpisodes.First().p;
                first.Episodes = patientsAndEpisodes.Select(x => x.e).ToArray();
                patients.Add(first);
            }
            return patients;
        }
    }
}