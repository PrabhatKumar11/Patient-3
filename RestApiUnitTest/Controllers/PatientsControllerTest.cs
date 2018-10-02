using Autofac;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using PatientService.Interfaces;
using RestApi.Controllers;
using RestApi.Models;
using System;
using System.Data.Entity;
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
            IContainer container = IoCBuilder.Build();

            var builder = new ContainerBuilder();
            //override registrations within the DI container.
            //Autofac will use the last registered component as the default provider of that service
            builder.RegisterType<InMemoryPatientContext>()
                .As<IPatientContext>()
                .InstancePerLifetimeScope();

            var nContainer = builder.Build();
            var inMemoryContext = nContainer.Resolve<IPatientContext>();
            var patientService = container.Resolve<IPatientService>();
            objController = new PatientsController(inMemoryContext, patientService);
        }

        [Test]
        public void GetPatientByIdPass()
        {
            var result = objController.GetPatientById(1);

            //Assert
            Assert.IsNotNull(result);
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
        [TearDown]
        public void DisposeAllObjects()
        {
            objController = null;
        }
    }
}
