namespace PAC.BusinessLogic;

using System.Collections.Generic;
using System.Data;
using IBusinessLogic;
using PAC.Domain;
using PAC.IDataAccess;

public class StudentLogic : IStudentLogic
{
    private readonly IStudentsRepository<Student> _studentsRepository;

    public StudentLogic(IStudentsRepository<Student> repository)
    {
        _studentsRepository = repository;
    }

    public Student GetStudentById(int id)
    {
        return _studentsRepository.GetStudentById(id);
    }

    public IEnumerable<Student> GetStudents()
    {
        return _studentsRepository.GetStudents();
    }

    public void InsertStudents(Student? student)
    {
        _studentsRepository.InsertStudents(student);
    }
}

