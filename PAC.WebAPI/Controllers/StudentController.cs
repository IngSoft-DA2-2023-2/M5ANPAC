using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PAC.Domain;
using PAC.IBusinessLogic;
using PAC.WebAPI.Filters;

namespace PAC.WebAPI
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentLogic _studentLogic;

        public StudentController(IStudentLogic studentLogic)
        {
            this._studentLogic = studentLogic;
        }

        // Endpoint para obtener todos los estudiantes
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _studentLogic.GetStudents();
            return Ok(students);
        }

        // Endpoint para obtener un estudiante por identificador
        [HttpGet("{studentId}")]
        public IActionResult GetStudentById(int studentId)
        {
            var student = _studentLogic.GetStudentById(studentId);

            if (student == null)
            {
                return NotFound(); // Devuelve un código 404 si el estudiante no se encuentra
            }

            return Ok(student);
        }

        // Endpoint para crear un estudiante
        [AuthorizationFilter]
        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest("Datos del estudiante nulos");
            }

            _studentLogic.InsertStudents(student);
            return Created($"student/{student.Id}", student); // Devuelve un código 201 si el estudiante se crea con éxito
        }
    }
}
