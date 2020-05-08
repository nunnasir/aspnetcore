using System;
using System.Collections.Generic;
using System.Text;

namespace StudnetsGrade.Framework
{
    public interface IStudentService : IDisposable
    {
        void CreateStudent(Student student);
        List<Student> GetAllStudent();
    }
}
