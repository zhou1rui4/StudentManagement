using System.Collections.Generic;
using System.Linq;
using AutoMoq;
using FluentAssertions;
using NUnit.Framework;
using StudentManagement.Data.Models;
using StudentManagement.ILogic;
using StudentManagement.WebAPI.Controllers;

namespace StudentManagement.WebAPI.Tests
{
    [TestFixture]
    public class StudentControllerTest
    {
        private AutoMoqer _autoMoqer;
        private StudentController _studentController;

        [SetUp]
        public void SetUp()
        {
            _autoMoqer = new AutoMoqer();
            _studentController = _autoMoqer.Create<StudentController>();
        }

        [Test]
        public void GetAll_should_return_students()
        {
            //Arrange
            var student = new List<Student>();
            _autoMoqer.GetMock<IStudentLogic>().Setup(x => x.GetAll()).Returns(student);

            //Act
            var result = _studentController.GetAll();

            //Assert
            result.Count().Should().Be(0);
        }
    }
}   
