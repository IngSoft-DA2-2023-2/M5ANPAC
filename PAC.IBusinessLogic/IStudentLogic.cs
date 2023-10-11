namespace PAC.IBusinessLogic;
using PAC.Domain;

public interface IStudentLogic
{
    IEnumerable<Student> GetStudents();
    Student GetStudentById(int id);
    void InsertStudents(Student? student);

}

