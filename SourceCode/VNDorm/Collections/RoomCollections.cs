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
    class RoomCollections : ObservableCollection<Room>
    {
        #region Fields
        private static object _threadLock = new Object();
        private static RoomCollections current = null;


        public static RoomCollections Current
        {
            get
            {
                lock ( _threadLock )
                    if ( current == null )
                        current = new RoomCollections( RoomRepository.GetRepository().Select().AsEnumerable() );
                return current;
            }
        }
        #endregion //Fields

        #region Constructor
        private RoomCollections()
            : base()
        {

        }

        private RoomCollections( IEnumerable<Room> enumRoom )
            : base( enumRoom )
        {

        }
        #endregion //Constructor

        #region Method
        public void AddRoom(
              string name
            , string note
            , string rowid
            , int MaxStudent
            , bool status
            )
        {
            Room aNewRoom = new Room()
            {
                RoomID = name,
                Name = name,
                Note = note,
                RowID = rowid,
                MaxStudent = MaxStudent,
                Status = status,
            };
            RoomRepository.GetRepository().Save( aNewRoom );
            Add( aNewRoom );
        }

        public void ModifyItem( Room item )
        {
            RoomRepository.GetRepository().Save( item );
        }

        public void RemoveRoom( Room item )
        {
            RoomRepository.GetRepository().Delete( item );
            Remove( item );
        }

        /*public ObservableCollection<Room> Search( string keyword )
        {
            return new ObservableCollection<Room>( RoomRepository.GetRepository().SearchByKeyWord( keyword ) );
        }

        public ObservableCollection<Room> SearchByInfo( SearchRoomInfo info )
        {
            return new ObservableCollection<Room>( SqlRoomRepository.GetRepository().SearchByObjectInfo( info ).ToList() );
        }*/

        public void ClearCollection()
        {
            current = null;
        }
        public int studentCount(string roomID)
        {
            return RoomRepository.GetRepository().studentCount( roomID );
        }
        public static ObservableCollection<Room> getRoomByBlockFloor( string block , int floor)
        {
            return new ObservableCollection<Room>( RoomRepository.GetRepository().Select(block,floor).AsEnumerable());
        }
        #endregion  //Method
    }
}
