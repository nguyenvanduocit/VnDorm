using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace VNDorm.Collections
{
    class YearCollection : ObservableCollection<string>
    {
        private static object _threadLock = new Object();
        private static YearCollection current;
        public YearCollection()
            : base()
        { }
        public static YearCollection Current
        {
            get
            {
                lock ( _threadLock )
                    if ( current == null )
                    {
                        current = new YearCollection();
                        int currentYear = DateTime.Now.Year;
                        for ( int i=0 ; i < 5 ; i++ )
                        {
                            current.Add( ( currentYear - i ).ToString() );
                        }
                    }
                return current;
            }

        }
    }
}
