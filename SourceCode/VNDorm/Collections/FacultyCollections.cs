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
    class FacultyCollections : ObservableCollection<Faculty>
    {
        #region Fields
        private static object _threadLock = new Object();
        private static FacultyCollections current = null;
        //private static IRepositoryPrototype<Faculty> facultyRepository = SqlFacultyRepository.GetFacultyRepository();
        public static FacultyCollections Current
        {
            get
            {
                lock ( _threadLock )
                    if ( current == null )
                        current = new FacultyCollections( FacultyRepository.GetFacultyRepository().Select().AsEnumerable() );
                return current;
            }
        }
        #endregion //Fields
        #region Constructor
        private FacultyCollections()
            : base()
        {

        }

        private FacultyCollections( IEnumerable<Faculty> enumFaculty )
            : base( enumFaculty )
        {

        }
        #endregion //Constructor
        #region Method
        public void AddItem( Faculty item )
        {
            FacultyRepository.GetFacultyRepository().Save( item );
            this.Add( item );
        }


        public void ModifyItem( Faculty item )
        {
            FacultyRepository.GetFacultyRepository().Save( item );
        }

        public void RemoveItem( Faculty item )
        {
            FacultyRepository.GetFacultyRepository().Delete( item );
            Remove( item );
        }
        #endregion  //Method

    }
}
