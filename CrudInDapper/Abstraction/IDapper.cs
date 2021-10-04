using CrudInDapper.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
//using System.Linq.Expressions;

namespace CrudInDapper.Abstraction
{
    public interface IDapper
    {

        DbConnection GetDbConnecton();

        Task<List<Student>> GetAllStudent();

        Task<Student> InsertStudent(Student student);
        Task<Student> UpdateStudent(Student student);
        Task<Student> DeleteStudent(int StudentId);
        Task<Student> GetStudentById(int StudentId);
       // ICollection<Student> GetPk(int pk);


    }
}
