using System;
using System.Collections.Generic;
using System.Text;

namespace StudnetsGrade.Framework
{
    public interface ISubjectService : IDisposable
    {
        void CreateSubject(Subject subject);
        List<Subject> GetAllSubject();
    }
}
