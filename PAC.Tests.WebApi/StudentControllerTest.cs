namespace PAC.Tests.WebApi;
using System.Collections.ObjectModel;

using System.Data;
using Moq;
using PAC.IBusinessLogic;
using PAC.Domain;
using PAC.WebAPI;
using Microsoft.AspNetCore.Mvc;

[TestClass]
public class StudentControllerTest
{
    [TestClass]
    public class UsuarioControllerTest
    {
        private Mock<IStudentLogic>? mock;
        private StudentController? controller;
        private Student? student;

        [TestInitialize]
        public void InitTest()
        {
            mock = new Mock<IStudentLogic>(MockBehavior.Strict);
            controller = new StudentController(mock.Object);
        }

        [TestMethod]
        public void PostStudentOk()
        {
            var result = controller!.Post(student!);
            var objectResult = result as ObjectResult;
            var statusCode = objectResult!.StatusCode;

            mock!.VerifyAll();
            Assert.AreEqual(200, statusCode);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void PostStudentFail()
        {
            mock!.Setup(x => x.InsertStudents(It.IsAny<Student>())).Throws(new Exception());
            var result = controller!.Post(It.IsAny<Student>());
            var objectResult = result as ObjectResult;
            var statusCode = objectResult!.StatusCode;

            mock.VerifyAll();
            Assert.AreEqual(500, statusCode);
        }
    }
}
