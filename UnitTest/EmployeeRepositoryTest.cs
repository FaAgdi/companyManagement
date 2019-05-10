using System;
using CompanyManagement.Models;
using NUnit.Framework;
using CompanyManagement.Repositories;
using CompanyManagement.ViewModel;
using Moq;
using System.Collections.Generic;
using NUnit.Framework.Constraints;

namespace EmployeeRepositoryTest
{
    [TestFixture]
    public class EmployeeRepositoryTest
    {

        public readonly IEmployeeRepository MockEmployeeRepository;

        [SetUp]
        public void Setup()
        {
        }
        public EmployeeRepositoryTest()
        {
            List<EmployeeViewModel> employees = new List<EmployeeViewModel>
                {
                    new EmployeeViewModel {
                        codeEmployee = "LG21543",
                        nameEmployee = "Unit Test",
                        address = "Test",
                        birthday = new DateTime(1995, 02, 15),
                        email = "test@gmail.com",
                        tel = "0632659869",
                        salary = 2500,
                        IdCompany = 2,
                        IdCategory = 1
                    },
                    new EmployeeViewModel {
                        codeEmployee = "LG1111",
                        nameEmployee = "Unit Test3",
                        address = "Test",
                        birthday = new DateTime(1996, 05, 01),
                        email = "test3@gmail.com",
                        tel = "0631111169",
                        salary = 2500,
                        IdCompany = 2,
                        IdCategory = 1
                    }
                };
            Mock<IEmployeeRepository> mockEmpRepository = new Mock<IEmployeeRepository>();

            mockEmpRepository.Setup(mr => mr.AddEmployee(It.IsAny<EmployeeViewModel>())).Returns(
                 () =>{  return "True"; });

            this.MockEmployeeRepository = mockEmpRepository.Object;
        }

        [Test]
        public void AddEmployee_Employee_ReturnTrue()
        {
            EmployeeViewModel emp = new EmployeeViewModel()
            {
                codeEmployee = "LG1111",
                nameEmployee = "Unit Test3",
                address = "Test",
                birthday = new DateTime(1996, 05, 01),
                email = "test3@gmail.com",
                tel = "0631111169",
                salary = 2500,
                IdCompany = 2,
                IdCategory = 1
            };

            var result = this.MockEmployeeRepository.AddEmployee(emp);
            Assert.That(result, Is.EqualTo("True"));
        }
        [Test]
        public void AddEmployee_Null_ReturnException()
        {
            //Assert.Throws<ArgumentNullException>(() => this.MockEmployeeRepository.AddEmployee(null));
            ActualValueDelegate<object> testDelegate = () => this.MockEmployeeRepository.AddEmployee(null);

            Assert.That(testDelegate, Throws.TypeOf<NullReferenceException>());
        }
        [Test]
        public void AddEmployee_EmployeeVide_ReturnException()
        {
            EmployeeViewModel emp = new EmployeeViewModel()
            {
                nameEmployee = "Unit Test3",
                address = "Test",
                birthday = new DateTime(1996, 05, 01),
                email = "test3@gmail.com",
                tel = "0631111169",
                salary = 2500,
                IdCompany = 2,
                IdCategory = 1
            };

            var result = this.MockEmployeeRepository.AddEmployee(emp);
            Assert.That(result, Is.EqualTo("True"));
        }
    }
}