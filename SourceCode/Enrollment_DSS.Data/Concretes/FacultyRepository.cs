using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enrollment_DSS.Data.Abstracts;
using Enrollment_DSS.Data.Entities;
using Enrollment_DSS.Data.Infrastructures;

namespace Enrollment_DSS.Data.Concretes
{
    public class FacultyRepository : SqlPrototype<Faculty>
    {
        #region Fields
        private static FacultyRepository facultyRepository;
        #endregion //Fields
        #region IEntityRepository<Faculty> Members

        public IQueryable<Faculty> Select()
        {
            return ( from m in EnrollmentDSSStatic.GetEntities().Faculties
                     select m );
        }
        public void Save( Faculty t )
        {
            throw new NotImplementedException();
        }

        public void Delete( Faculty t )
        {
            throw new NotImplementedException();
        }

        #endregion

        public string getFacultyIDByFacultyName( string name )
        {
            return ( from m in EnrollmentDSSStatic.GetEntities().Faculties
                     where m.FacultyName == name
                     select m.FacultyID ).FirstOrDefault();
        }
        public Faculty GetFacultyBy( string facultyID )
        {
            var faculty = ( from m in EnrollmentDSSStatic.GetEntities().Faculties
                            where m.FacultyID == facultyID
                            select m ).FirstOrDefault();
            return faculty;
        }

        public static FacultyRepository GetFacultyRepository()
        {
            if ( facultyRepository == null )
                facultyRepository = new FacultyRepository();
            return facultyRepository;
        }
        public List<Faculty> GetAllFacultyRows()
        {
            var list = ( from m in EnrollmentDSSStatic.GetEntities().Faculties
                         select m ).ToList();
            var tlist = ( from m in list select m ).ToList();
            return tlist;
        }
    }
}
