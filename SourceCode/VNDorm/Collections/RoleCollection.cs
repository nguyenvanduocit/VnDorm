using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enrollment_DSS.Data.Entities;
using Enrollment_DSS.Data.Concretes;
using System.Collections.ObjectModel;

namespace VNDorm.Collections
{
    public class RoleCollection : ObservableCollection<Role>
    {
        private static object _threadLock = new Object();
        private static RoleCollection current = null;
        public static RoleCollection Current
        {
            get
            {
                lock ( _threadLock )
                    if ( current == null )
                        current = new RoleCollection( new RoleRepository().Select().AsEnumerable() );
                return current;
            }
        }
        public void ClearCollection()
        {
            current = null;
        }

        public RoleCollection()
            : base()
        { }

        private RoleCollection( IEnumerable<Role> enumTestingGroup )
            : base(enumTestingGroup)
        { }

        public Role GetRoleCombobox( int ID )
        {
            var result = ( from m in current
                           where m.RoleID == ID
                           select m ).FirstOrDefault();
            return result;
        }
    }
}
