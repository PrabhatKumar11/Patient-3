using Autofac;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using PatientService.Interfaces;
using RestApi.Controllers;
using RestApi.Models;
using System;
using System.Linq;

namespace RestApiUnitTest.Controllers
{
    [TestFixture]
    public class PatientsControllerTest
    {
        PatientsController objController;
        [SetUp]
        public void SetUp()
        {
            IContainer container = IoCBuilder.Build("DefaultConnection");
            var patientService = container.Resolve(typeof(IPatientService)) as RestApi.Models.PatientService;
            objController = new PatientsController(patientService);
        }

        [Test]
        public void GetPatientByIdPass()
        {
            var result = objController.GetPatientById(1);

            //Assert
            Assert.AreEqual(result.Episodes.Count(), 3);
            Assert.AreEqual("1111111111", result.NhsNumber);
            Assert.AreEqual("Millicent", result.FirstName);
            Assert.AreEqual(1, result.PatientId);
        }

        [Test]
        public void GetPatientByIdFail()
        {
            var result = objController.GetPatientById(1);
            //Assert
            Assert.AreNotEqual(result.Episodes.Count(), 0);
            Assert.AreNotEqual("", result.NhsNumber);
            Assert.AreNotEqual("", result.FirstName);
            Assert.AreNotEqual(0, result.PatientId);
        }

        [Test]
        public void ExpectAnExceptionByType()
        {
            ActualValueDelegate<object> testDelegate = () => objController.GetPatientById(0);

            //Assert
            Assert.That(testDelegate, Throws.TypeOf<ArgumentException>());
        }
    }
}
