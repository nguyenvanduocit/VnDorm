using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enrollment_DSS.Data.Abstracts
{
    public interface SqlPrototype<T>
    {
        IQueryable<T> Select();
        void Save(T entity);
        void Delete(T entity);
    }
}
