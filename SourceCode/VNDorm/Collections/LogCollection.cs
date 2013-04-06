using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Enrollment_DSS.Data.Abstracts;
using Enrollment_DSS.Data.Entities;
using Enrollment_DSS.Data.Concretes;
using Enrollment_DSS.Data.Infrastructures;

namespace VNDorm.Collections
{
    public class LogCollection : ObservableCollection<Log>
    {
        public LogCollection()
        {
            IEnumerable<Log> list = new LogRepository().Select();
            foreach ( Log item in list )
            {
                this.Add(item);
            }
        }
        public LogCollection( string phanhe )
        {
            IEnumerable<Log> list = new LogRepository().Select( phanhe );
            foreach ( Log item in list )
            {
                this.Add( item );
            }
        }
    }
    public class ModuleCollection : ObservableCollection<string>
    {
        #region Fields
        public static ObservableCollection<string> getAllModuleName()
        {
            return new ObservableCollection<string>( LogRepository.getAllModuleName().AsEnumerable());
        }
        #endregion //Fields
    }
}


