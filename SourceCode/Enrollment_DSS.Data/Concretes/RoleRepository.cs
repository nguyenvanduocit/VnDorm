using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enrollment_DSS.Data.Abstracts;
using Enrollment_DSS.Data.Entities;
using Enrollment_DSS.Data.Infrastructures;

namespace Enrollment_DSS.Data.Concretes
{
    public class RoleRepository : SqlPrototype<Role>
    {
        #region SqlPrototype<Role> Members
        public IQueryable<Role> Select()
        {
            return ( from m in EnrollmentDSSStatic.GetEntities().Roles
                     select m );
        }

        public void Save( Role t )
        {
            throw new NotImplementedException();
        }

        public void Delete( Role t )
        {
            throw new NotImplementedException();
        }

        #endregion

        public string GetRoleName( int roleID )
        {
            return ( from m in EnrollmentDSSStatic.GetEntities().Roles
                     where m.RoleID == roleID
                     select m.RoleName ).FirstOrDefault();
        }
    }
}
