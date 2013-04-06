using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enrollment_DSS.Data.Entities;

namespace Enrollment_DSS.Data.Infrastructures
{
    public class EnrollmentDSSStatic
    {
        private static Enrollment_DSSEntities _entities;

        public static Enrollment_DSSEntities GetEntities()
        {
            if (null == _entities)
            {
                _entities = new Enrollment_DSSEntities();
                
            }
            return _entities;
        }

    }
}
