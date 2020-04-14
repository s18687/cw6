using cw6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cw6.Services
{
    public class SqlServerStudentService : IStudentDbService
    {
        public Student GetStudent(string index)
        {
            if(index=="s18541")
            {
                return new Student { IdStudent = 1,FirstName = "Michal", LastName = "Malinewski" };
            }
            return null;
        }

        public IEnumerable<Student> GetStudents()
        {
            throw new NotImplementedException();
        }
    }
}
