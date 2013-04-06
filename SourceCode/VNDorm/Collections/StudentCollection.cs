using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enrollment_DSS.Data.Entities;
using Enrollment_DSS.Data.Concretes;
using Enrollment_DSS.Data.Infrastructures;

namespace VNDorm.Collections
{
    public class StudentCollection : ObservableCollection<Student>
    {
        private StudentRepository _repos = new StudentRepository();
        public StudentCollection()
        {
            //IEnumerable<Student> studentList = new StudentRepository().GetAllStudents();

            //foreach (Student item in studentList)
            //{
            //    this.Add(item);
            //}
        }
        public StudentCollection(string RoomID)
        {
            IEnumerable<Student> studentList = new StudentRepository().GetAllStudentByRoom(RoomID);

            foreach (Student item in studentList)
            {
                this.Add(item);
            }
        }
        public IQueryable<Student> GetAllStudents()
        {
            return _repos.GetAllStudents();
        }
        public IQueryable<Student> GetAllStudentsByRoom( string RoomID )
        {
            return _repos.GetAllStudentByRoom(RoomID).AsQueryable();
        }
        public IQueryable<Student> GetStudentsToFilter( string sub )
        {
            return ( from m in EnrollmentDSSStatic.GetEntities().Students
                     where ( m.FirstName.IndexOf( sub ) != -1 || m.LastName.IndexOf( sub ) != -1 || m.StudentID.IndexOf( sub ) != -1 )
                     select m );
        }
        public List<Student> GetStudentsToFilter( string sub, ObservableCollection<Student> AllStudentList )
        {
            return AllStudentList.Where( vm => vm.StudentID.IndexOf( sub ) != -1 || vm.LastName.IndexOf( sub ) != -1 || vm.FirstName.IndexOf( sub ) != -1 ).ToList();
        }
        public IQueryable<Student> GetAllBySearch( string _searchedText )
        {
            //int termID = termRepos.GetTermID(_semester, _year);

            return _repos.GetAllBySearch( _searchedText );
        }
        public int RemoveStudent( Student item )
        {
            if ( StudentRepository.GetRepository().Delete( item ) == 1 )
            {
                Remove( item );
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public void ModifyItem( Student item )
        {
            StudentRepository.GetRepository().UpdateStudent( item );
            
        }
        public void addStudent(Student student)
        {
            StudentRepository.GetRepository().Save(student);
            Add(student);
        }
    }
}
