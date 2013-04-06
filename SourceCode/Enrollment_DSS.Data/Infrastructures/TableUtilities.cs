using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;
using System.Data.Objects;
using System.Data;

namespace Enrollment_DSS.Data.Infrastructures
{
    public class TableUtilities
    {


        public static bool isAttach( ObjectContext context, EntityObject entity )
        {
            var entry = context.ObjectStateManager.GetObjectStateEntry( entity );
            if ( entry.State == EntityState.Detached )
                return false;
            else
                return true;
        }

    }
}
