using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enrollment_DSS.Data.Infrastructures
{
    public class TDTStatic
    {
        private static EnrollmentDSSStatic tdtEntity = null;
        public static EnrollmentDSSStatic getTDTEntity()
        {
            if ( tdtEntity == null )
                tdtEntity = new EnrollmentDSSStatic();
            return tdtEntity;
        }

        public static EnrollmentDSSStatic getTDTEntity( bool isSingleton )
        {
            if ( isSingleton )
            {
                if ( tdtEntity == null )
                    tdtEntity = new EnrollmentDSSStatic();

                return tdtEntity;
            }
            else
            {
                tdtEntity = new EnrollmentDSSStatic();
                return tdtEntity;
            }
        }

        public static void setTdtEntity()
        {
            tdtEntity = new EnrollmentDSSStatic();
        }


    }
}
