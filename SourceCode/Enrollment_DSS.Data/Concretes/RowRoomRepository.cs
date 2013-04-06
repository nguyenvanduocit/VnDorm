using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using Enrollment_DSS.Data.Abstracts;
using Enrollment_DSS.Data.Entities;
using Enrollment_DSS.Data.Infrastructures;


namespace Enrollment_DSS.Data.Concretes
{
    public class RowRoomRepository : SqlPrototype<RowRoom>
    {
        #region Fields
        private static RowRoomRepository rowRoomRepository;
        #endregion //Fields

        #region Constructor
        private RowRoomRepository()
        { }
        #endregion //Constructor

        public static RowRoomRepository GetRepository()
        {
            if ( rowRoomRepository == null )
                rowRoomRepository = new RowRoomRepository();
            return rowRoomRepository;
        }
        #region IEntityRepository Members
        public IQueryable<RowRoom> Select()
        {
            return from o in EnrollmentDSSStatic.GetEntities().RowRooms select o;
        }

        public void Save( RowRoom entity )
        {
            throw new NotImplementedException();
        }

        public void Delete( RowRoom entity )
        {
            EnrollmentDSSStatic.GetEntities().AttachTo(EnrollmentDSSStatic.GetEntities().CreateObjectSet<RowRoom>().EntitySet.Name, entity);
            EnrollmentDSSStatic.GetEntities().ObjectStateManager.GetObjectStateEntry(entity).SetModified();
            EnrollmentDSSStatic.GetEntities().DeleteObject(entity);
            EnrollmentDSSStatic.GetEntities().SaveChanges();
        }
        #endregion //IEntityRepository Members
        public void AddRowRom( RowRoom entity )
        {
            if ( entity.ID.Equals(0) )
            {
                EnrollmentDSSStatic.GetEntities().AddToRowRooms( entity );

            }
            else if ( entity != null )
            {
                EnrollmentDSSStatic.GetEntities().AttachTo( EnrollmentDSSStatic.GetEntities().CreateObjectSet<RowRoom>().EntitySet.Name, entity );
                EnrollmentDSSStatic.GetEntities().ObjectStateManager.GetObjectStateEntry( entity ).SetModified();
                EnrollmentDSSStatic.GetEntities().Refresh( RefreshMode.ClientWins, entity );
            }
            EnrollmentDSSStatic.GetEntities().SaveChanges();
            EnrollmentDSSStatic.GetEntities().Detach( entity );
        }
        public IQueryable<string> getAllBlock()
        {
            return (from o in EnrollmentDSSStatic.GetEntities().RowRooms orderby o.Block select o.Block).Distinct();
        }
        public IQueryable<int> getAllFloorByBlock(string block)
        {
            return (from o in EnrollmentDSSStatic.GetEntities().RowRooms where o.Block == block select o.Floor.Value).Distinct();
        }
    }
}
