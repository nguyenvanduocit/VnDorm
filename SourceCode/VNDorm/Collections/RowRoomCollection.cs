using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enrollment_DSS.Data.Entities;
using System.Collections.ObjectModel;
using Enrollment_DSS.Data.Abstracts;
using Enrollment_DSS.Data.Concretes;

namespace VNDorm.Collections
{
    class RowRoomCollection : ObservableCollection<RowRoom>
    {
        #region Fields
        private static object _threadLock = new Object();
        private static RowRoomCollection current = null;

        public static RowRoomCollection Current
        {
            get
            {
                lock ( _threadLock )
                    if ( current == null )
                        current = new RowRoomCollection( RowRoomRepository.GetRepository().Select().AsEnumerable() );
                return current;
            }
        }
        #endregion //Fields
        #region Constructor
        private RowRoomCollection() : base()
        {

        }

        private RowRoomCollection(IEnumerable<RowRoom> enumRowRoom)
            : base(enumRowRoom)
        {
 
        }
        #endregion //Constructor
    }

    public class BlockCollection : ObservableCollection<string>
    {
        #region Fields
        private static object _threadLock = new Object();
        private static BlockCollection current = null;

        public static BlockCollection Current
        {
            get
            {
                lock ( _threadLock )
                    if ( current == null )
                        current = new BlockCollection( RowRoomRepository.GetRepository().getAllBlock().AsEnumerable() );
                return current;
            }
        }
        #endregion //Fields
        #region Constructor
        private BlockCollection()
            : base()
        {

        }

        private BlockCollection( IEnumerable<string> enumRowRoom )
            : base( enumRowRoom )
        {

        }
        #endregion //Constructor
    }

    public class FloorCollection : ObservableCollection<int>
    {
        #region Fields
        private static object _threadLock = new Object();

        public static ObservableCollection<int> getFloorByBlock( string block )
        {
            return new ObservableCollection<int>( RowRoomRepository.GetRepository().getAllFloorByBlock( block ).AsEnumerable() );
        }
        #endregion //Fields
        #region Constructor
        private FloorCollection()
            : base()
        {

        }

        private FloorCollection( IEnumerable<int> enumRowRoom )
            : base( enumRowRoom )
        {

        }
        #endregion //Constructor
    }
}
