using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PAC.Domain;
using PAC.IDataAccess;

namespace PAC.DataAccess;

public class StudentsRepository<T> : IStudentsRepository<Student> where T : class
{
    private readonly DbContext context;

    public StudentsRepository(DbContext context)
    {
        this.context = context;
    }

    protected DbSet<Student> Entities
    {
        get
        {
            return this.context.Set<Student>();
        }
    }

    public Student GetStudentById(int id)
    {
        return this.Entities.Where(u => u.Id == id).FirstOrDefault()!;
    }

    public IEnumerable<Student> GetStudents()
    {
        return Entities.ToList();
    }

    public void InsertStudents(Student? student)
    {
        this.Entities.Add(student!);
        this.context.SaveChanges();
    }
}
