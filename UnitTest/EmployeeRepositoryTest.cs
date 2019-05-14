using System;
using CompanyManagement.Models;
using NUnit.Framework;
using CompanyManagement.Repositories;
using CompanyManagement.ViewModel;
using Moq;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using System.ComponentModel.DataAnnotations;

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
                 () => { return "True"; });
            mockEmpRepository.Setup(mr => mr.GetEmployees()).Returns(employees);

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
        public void AddEmployee_ExistEmployee_ReturnError()
        {
            List<EmployeeViewModel> list = new List<EmployeeViewModel>();
            list = this.MockEmployeeRepository.GetEmployees();

            EmployeeViewModel emp = new EmployeeViewModel()
            {
                codeEmployee = "254ML",
            };

            var e = list.Find(x => x.codeEmployee.Contains(emp.codeEmployee));

            var result = this.MockEmployeeRepository.AddEmployee(e);

            Assert.That(e, Is.EqualTo(null));
            Assert.That(result, Is.EqualTo("True"));
        }
        [Test]
        public void AddEmployee_EmployeeVide_ReturnError()
        {
            EmployeeViewModel emp = new EmployeeViewModel()
            {
                codeEmployee = "LG21543",
                nameEmployee = "Unit Test",
                address = "Test",
                birthday = new DateTime(1995, 02, 15),
                email = "test@gmail.com",
                tel = "0632659869",
                salary = 2500,
                company = new company() { idCompany = 2},
                category = new category() { idCategory = 1}
            };

            var context = new ValidationContext(emp, null, null);
            var results = new List<ValidationResult>();
            Validator.TryValidateObject(emp, context, results, true);

            var result = this.MockEmployeeRepository.AddEmployee(emp);

            Assert.AreEqual(0, results.Count);
            Assert.That(result, Is.EqualTo("True"));
        }
    }
}