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
        [TestInitialize]
        public void InitTest()
        {
        }
    [TestMethod]
    public void PostStudentOk_Should_Return_CreatedResult()
    {
        // Arrange
        var studentLogicMock = new Mock<IStudentLogic>();
        var newStudent = new Student { Name = "Diseño" };

        studentLogicMock.Setup(m => m.InsertStudents(It.IsAny<Student>()))
                       .Callback<Student>(s => s.Id = 1); // Simula la inserción con éxito

        var controller = new StudentController(studentLogicMock.Object);

        // Act
        var result = controller.CreateStudent(newStudent);

        // Assert
        Assert.IsTrue(result is CreatedResult);
        var createdResult = (CreatedResult)result;
        Assert.AreEqual(201, createdResult.StatusCode);
        Assert.AreSame(newStudent, createdResult.Value);
    }

    public void PostStudentFail_Should_Return_BadRequest()
    {
        // Arrange
        var studentLogicMock = new Mock<IStudentLogic>();
        Student newStudent = null; // Estudiante nulo para simular una inserción fallida

        var controller = new StudentController(studentLogicMock.Object);

        // Act
        var result = controller.CreateStudent(newStudent);

        // Assert
        Assert.IsTrue(result is BadRequestObjectResult);
        var badRequestResult = (BadRequestObjectResult)result;
        Assert.AreEqual(400, badRequestResult.StatusCode);
        Assert.AreEqual("Datos del estudiante nulos", badRequestResult.Value);
    }
}
