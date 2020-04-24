using System;
using System.Collections.Generic;

namespace CourseManagement.Data
{
    public interface ISqlServerDataProvider<T>
    {
        (IList<T> result, int total, int totalDisplay) GetDat(string procedureName, IList<(string key, object value, bool isOut)> parameters);
    }
}
