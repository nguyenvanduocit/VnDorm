using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace VNDorm.Collections
{
    public class GenderCollection : ObservableCollection<string>
    {
        private static object _threadLock = new Object();
        private static GenderCollection current;
        public GenderCollection()
            : base()
        { }
        public static GenderCollection Current
        {
            get
            {
                lock ( _threadLock )
                    if ( current == null )
                    {
                        current = new GenderCollection();
                        current.Add( "Nam" );
                        current.Add( "Nữ" );
                        current.Add( "Bí mật" );
                    }
                return current;
            }

        }
    }
}
