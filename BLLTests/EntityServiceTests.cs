using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL.Tests
{
    [TestClass()]
    public class EntityServiceTests
    {
        EntityService? entityService;

        public void Setup()
        {
            entityService = new EntityService("json", "test");
            entityService.Clear();
        }

        [TestMethod()]
        public void AddStudentTest()
        {
            // Arrange
            Setup();
            string firstName = "test";
            string lastName = "test";
            int course = 3;
            string id = "10201232";
            string hometown = "Test";
            string passportNumber = "312312312";

            // Act
            entityService?.AddStudent(firstName, lastName, course, id, hometown, passportNumber);
            // Assert
            Student student = (Student)entityService!.EntityList[0];

            Assert.AreEqual(1, entityService.EntityList.Count);
            Assert.AreEqual(student.FirstName, firstName);
            Assert.AreEqual(student.LastName, lastName);
            Assert.AreEqual(student.Course, course);
            Assert.AreEqual(student.StudentId, id);
            Assert.AreEqual(student.Hometown, hometown);
            Assert.AreEqual(student.PassportNumber, passportNumber);
        }

        [TestMethod()]
        public void RemoveTest()
        {
            // Arrange
            Setup();
            string firstName = "test";
            string lastName = "test";
            int course = 3;
            string id = "10201232";
            string hometown = "Test";
            string passportNumber = "312312312";

            // Act
            entityService.AddStudent(firstName, lastName, course, id, hometown, passportNumber);
            entityService.Remove(0);
            // Assert

            Assert.AreEqual(0, entityService.EntityList.Count);
        }

        [TestMethod()]
        public void CalculatePercentageTest()
        {
            // Arrange
            Setup();
            string firstName1 = "test";
            string lastName1 = "test";
            int course1 = 3;
            string id1 = "10201232";
            string hometown1 = "Test";
            string passportNumber1 = "312312312";

            string firstName2 = "test";
            string lastName2 = "test";
            int course2 = 1;
            string id2 = "10201232";
            string hometown2 = "kyiv";
            string passportNumber2 = "312312312";

            string firstName3 = "test";
            string lastName3 = "test";
            int course3 = 1;
            string id3 = "10201232";
            string hometown3 = "Test";
            string passportNumber3 = "312312312";

            // Act
            entityService.AddStudent(firstName1, lastName1, course1, id1, hometown1, passportNumber1);
            entityService.AddStudent(firstName2, lastName2, course2, id2, hometown2, passportNumber2);
            entityService.AddStudent(firstName3, lastName3, course3, id3, hometown3, passportNumber3);

            int percent = (int)Math.Round(entityService.CalculatePercentage());
            // Assert

            Assert.AreEqual(33, percent);
        }
    }

    [TestClass()]
    public class StudentValidationTests
    {
        [TestMethod()]
        public void IsValidName()
        {
            // Arrange
            string name = "Ivan";
            string invalidName = "A";

            // Act
            bool result = StudentValidation.isValidName(name);

            // Assert
            Assert.AreEqual(result, true);
            Assert.ThrowsException<ValidationException>(() => StudentValidation.isValidName(invalidName));
        }

        [TestMethod()]
        public void IsValidCourse()
        {
            // Arrange
            int course = 3;
            int invalidCourse = 7;

            // Act
            bool result = StudentValidation.isValidCourse(course);

            // Assert
            Assert.AreEqual(result, true);
            Assert.ThrowsException<ValidationException>(() => StudentValidation.isValidCourse(invalidCourse));
        }

        [TestMethod()]
        public void IsValidPassportNumber()
        {
            // Arrange
            string number = "000123302";
            string invalidNumber = "qweq";

            // Act
            bool result = StudentValidation.isValidPassportNumber(number);

            // Assert
            Assert.AreEqual(result, true);
            Assert.ThrowsException<ValidationException>(() => StudentValidation.isValidPassportNumber(invalidNumber));

        }
    }

    [TestClass()]
    public class HelpersTests
    {
        [TestMethod()]
        public void IsValidIndex()
        {
            // Arrange
            string[] list = new string[7];
            int index1 = -1;
            int index2 = 0;
            int index3 = 6;
            int index4 = 7;

            // Act
            bool result1 = Helpers.isValidIndex(index1, list.Length);
            bool result2 = Helpers.isValidIndex(index2, list.Length);
            bool result3 = Helpers.isValidIndex(index3, list.Length);
            bool result4 = Helpers.isValidIndex(index4, list.Length);

            // Assert
            Assert.AreEqual(result1, false);
            Assert.AreEqual(result2, true);
            Assert.AreEqual(result3, true);
            Assert.AreEqual(result4, false);
        }
    }
}