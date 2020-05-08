using StudnetsGrade.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudnetsGrade.Framework
{
    public class SubjectRepository : Repository<Subject, int, FrameworkContext>, ISubjectRepository
    {
        public SubjectRepository(FrameworkContext context) 
            : base(context)
        {
        }

    }
}
