using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enrollment_DSS.Data.Abstracts;
using Enrollment_DSS.Data.Entities;
using Enrollment_DSS.Data.Infrastructures;

namespace Enrollment_DSS.Data.Concretes
{
    public class RoomRepository : SqlPrototype<Room>
    {
        #region Fields
        private static RoomRepository roomRepository;
        #endregion //Fields
        
        #region Constructor
        private RoomRepository()
        { }
        #endregion //Constructor

        public static RoomRepository GetRepository()
        {
            if ( roomRepository == null )
                roomRepository = new RoomRepository();
            return roomRepository;
        }

        #region IEntityRepository Members
        public IQueryable<Room> Select()
        {
            return from o in EnrollmentDSSStatic.GetEntities().Rooms select o;
        }
        public IQueryable<Room> Select(string block, int floor)
        {
            RowRoom rowroom = (from o in EnrollmentDSSStatic.GetEntities().RowRooms where (o.Block == block && o.Floor == floor) select o).FirstOrDefault();
            if ( rowroom.ID != string.Empty )
            {
                return from o in EnrollmentDSSStatic.GetEntities().Rooms where o.RowID == rowroom.ID select o;
            }
            return null;
        }
        public void Save( Room entity )
        {
            if ( entity != null )
            {
                Room temp = EnrollmentDSSStatic.GetEntities().Rooms.SingleOrDefault( x => x.RoomID == entity.RoomID );
                if ( temp == null )
                {
                    EnrollmentDSSStatic.GetEntities().AddToRooms( entity );
                }
                else
                {
                    temp.Name = entity.Name;
                    temp.Note = entity.Note;
                    temp.RowID = entity.RowID;
                    temp.MaxStudent = entity.MaxStudent;
                    temp.Status = entity.Status;
                }
                EnrollmentDSSStatic.GetEntities().SaveChanges();

            }
        }
        public void Delete( Room entity )
        {
            Student temp = EnrollmentDSSStatic.GetEntities().Students.FirstOrDefault( x => x.RoomID == entity.RoomID );
            if ( temp == null )
            {
                throw new System.Data.DataException( "Conflict DELETE statement" );
            }
            EnrollmentDSSStatic.GetEntities().Rooms.DeleteObject( entity );
            EnrollmentDSSStatic.GetEntities().SaveChanges();

        }

        public IQueryable<Room> SearchByID( object ID )
        {
            return (
                from o in EnrollmentDSSStatic.GetEntities().Rooms
                where o.RoomID == ( string )ID
                select o
            );
        }

        public int studentCount(string roomID)
        {
            return ( from o in EnrollmentDSSStatic.GetEntities().Students where o.RoomID == roomID select o ).Count();
        }
        #endregion //IEntityRepository Members
    }
}
