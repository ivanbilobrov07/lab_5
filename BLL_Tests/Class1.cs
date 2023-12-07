global using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;
using DAL;

namespace BLL_Tests
{
    [TestClass()]
    public class EntityServiceTests
    {
        EntityService ?entityService;

        [TestInitialize]
        public void TestInitialize()
        {
            entityService = new EntityService("json", "test");
        }

        [TestMethod()]
        public void AddTest()
        {
            // Arrange
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

            Assert.AreEqual(1, entityService.EntityList.Count());
            Assert.AreEqual(student.FirstName, "qwe");
            Assert.AreEqual(student.LastName, lastName);
            Assert.AreEqual(student.Course, course);
            Assert.AreEqual(student.StudentId, id);
            Assert.AreEqual(student.Hometown, hometown);
            Assert.AreEqual(student.PassportNumber, passportNumber);

            entityService.Remove(0);
        }
    }
}
