using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enrollment_DSS.Data.Abstracts;
using Enrollment_DSS.Data.Entities;
using Enrollment_DSS.Data.Infrastructures;

namespace Enrollment_DSS.Data.Concretes
{
    public class StudentRepository
    {
        private static StudentRepository studentRepository;
        private LogRepository log = new LogRepository();

        public static StudentRepository GetRepository()
        {
            if ( studentRepository == null )
                studentRepository = new StudentRepository();
            return studentRepository;
        }
        public IQueryable<Student> GetAllStudents()
        {
            var students = from m in EnrollmentDSSStatic.GetEntities().Students
                           select m;
            return students;
        }

        public IQueryable<Student> GetAllStudentByRoom( string RoomID )
        {
            return from o in EnrollmentDSSStatic.GetEntities().Students where o.RoomID == RoomID select o;
        }

        public List<Student> GetAllStudentBy( int classID )
        {
            var students = ( from m in EnrollmentDSSStatic.GetEntities().Students
                             where m.ClassID.Equals( classID )
                             select m ).ToList();
            return students;
        }

        public List<Student> GetAllStudentBy( string facultyID )
        {
            var students = ( from m in EnrollmentDSSStatic.GetEntities().Students
                             where m.FacultyID == facultyID
                             select m ).ToList();
            return students;
        }

        public IQueryable<string> GetAllStudentIDByClassID( string className )
        {
            return from m in EnrollmentDSSStatic.GetEntities().Students
                   where m.ClassID.ToUpper().Equals( className.ToUpper() )
                   select m.StudentID;
        }
        // Đếm sinh viên có cùng lớp
        public int CountStudent( string classID )
        {
            var count = ( from m in EnrollmentDSSStatic.GetEntities().Students
                          where m.ClassID == classID
                          select m ).Count();
            return count;
        }
        public void UpdateClassForStudent( string classID, string studentID )
        {
            Student student = ( from m in EnrollmentDSSStatic.GetEntities().Students
                                where m.StudentID.Equals( studentID )
                                select m ).FirstOrDefault();
            student.ClassID = classID;
            EnrollmentDSSStatic.GetEntities().SaveChanges();
        }

        public void QuickEditStudent( Student _student )
        {
            Student student = ( from m in EnrollmentDSSStatic.GetEntities().Students
                                where m.StudentID == _student.StudentID
                                select m ).FirstOrDefault();

            student.LastName = _student.LastName;
            student.FirstName = _student.FirstName;
            student.Sex = _student.Sex;
            student.BirthDay = _student.BirthDay;
            student.ClassID = _student.ClassID;
            student.RoomID = _student.RoomID;

            EnrollmentDSSStatic.GetEntities().SaveChanges();
        }
        public void UpdateStudent( Student student )
        {
            var kq = ( from m in EnrollmentDSSStatic.GetEntities().Students
                       where m.StudentID.Equals( student.StudentID )
                       select m ).FirstOrDefault();
            kq = student;
            EnrollmentDSSStatic.GetEntities().SaveChanges();
            log.GhiNhanThongTinThaoTac( "Updated the student " + student.StudentID, 1 );
        }
        public int DeleteStudent(Student student)
        {
            EnrollmentDSSStatic.GetEntities().DeleteObject( student );
            EnrollmentDSSStatic.GetEntities().SaveChanges();
            return 1;
        }
        public IQueryable<Student> GetAllBySearch( string searchText )
        {
            var _result = from m in EnrollmentDSSStatic.GetEntities().Students
                          where m.StudentID.Equals( searchText ) || m.FirstName.Equals( searchText )
                          || m.LastName.Equals( searchText )
                          select m;
            return _result;
        }
        public string GetFirstName( string studentID )
        {
            return ( from m in EnrollmentDSSStatic.GetEntities().Students
                     where m.StudentID.Equals( studentID )
                     select m.FirstName ).FirstOrDefault();
        }
        public string GetLastName( string studentID )
        {
            return ( from m in EnrollmentDSSStatic.GetEntities().Students
                     where m.StudentID.Equals( studentID )
                     select m.LastName ).FirstOrDefault();
        }
        public int GetOrderTermStudentByYear( string studentID, string termYear, int termSemester )
        {
            int x;
            int.TryParse( studentID, out x );
            var year2c = 0;
            if ( x != 0 ) // Nếu x khác null => mã số sv mới
                year2c = int.Parse( studentID.Substring( 1, 2 ) );
            else // Nếu x = null => mã số sv cũ
                year2c = int.Parse( studentID.Substring( 0, 2 ) );
            var order = ( int.Parse( termYear ) % 2000 - year2c + 1 ) * 2;
            if ( termSemester == 1 )
                order--;
            return order;
        }
        public void changeRoom( string StudentID, string RoomID )
        {
            var kq = ( from m in EnrollmentDSSStatic.GetEntities().Students
                       where m.StudentID.Equals( StudentID )
                       select m ).FirstOrDefault();
            kq.RoomID = RoomID;
            EnrollmentDSSStatic.GetEntities().SaveChanges();
        }
        public int Delete( Student entity )
        {
            if ( CheckExist( entity.StudentID ) )
            {
                EnrollmentDSSStatic.GetEntities().Students.DeleteObject( entity );
                EnrollmentDSSStatic.GetEntities().SaveChanges();
                log.GhiNhanThongTinThaoTac("Deleted the student " + entity.StudentID, 1 );
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public bool CheckExist( string StudentID )
        {
            var result = ( from m in EnrollmentDSSStatic.GetEntities().Students
                           where m.StudentID.Equals( StudentID )
                           select m ).Count();
            if ( result > 0 )
                return true;
            return false;
        }
        public void Save( Student entity )
        {
            if ( entity != null )
            {
                Student temp = EnrollmentDSSStatic.GetEntities().Students.SingleOrDefault( x => x.StudentID == entity.StudentID );
                if ( temp == null )
                {
                    EnrollmentDSSStatic.GetEntities().AddToStudents( entity );
                }
                else
                {
                    UpdateStudent( entity );
                }
                EnrollmentDSSStatic.GetEntities().SaveChanges();

            }
        }
    }
}
