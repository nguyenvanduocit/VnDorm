using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
namespace VNDorm.ViewModel.Student
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class StudentMainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the StudentMainViewModel class.
        /// </summary>
        public StudentMainViewModel()
        {
            FindStudentVM = new FindStudentViewModel();
            StudentListVM = new StudentListViewModel();
            ImportStudentVM = new ImportStudentViewModel();
            this.Content = this.StudentListVM;
        }

        #region For contentControl binding
        /// <summary>
        /// The <see cref="Content" /> property's name.
        /// </summary>
        public const string ContentPropertyName = "Content";

        private object _content = null;

        /// <summary>
        /// Sets and gets the Content property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public object Content
        {
            get
            {
                return _content;
            }
            set
            {
                if ( _content == value )
                {
                    return;
                }

                RaisePropertyChanging( ContentPropertyName );
                _content = value;
                RaisePropertyChanged( ContentPropertyName );
            }
        }
        #endregion

        #region Find student
        /// <summary>
        /// The <see cref="FindStudentVM" /> property's name.
        /// </summary>
        public const string FindStudentVMPropertyName = "FindStudentVM";

        private FindStudentViewModel _FindStudentVM = null;

        /// <summary>
        /// Sets and gets the FindStudentVM property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public FindStudentViewModel FindStudentVM
        {
            get
            {
                return _FindStudentVM;
            }

            set
            {
                if ( _FindStudentVM == value )
                {
                    return;
                }
                RaisePropertyChanging( FindStudentVMPropertyName );
                _FindStudentVM = value;
                RaisePropertyChanged( FindStudentVMPropertyName );
            }
        }
        public ICommand FindStudentViewCommand
        {
            get
            {
                return new RelayCommand( () => changeContent( FindStudentVMPropertyName ) );
            }
        }
        #endregion

        #region StudentListVM
        /// <summary>
        /// The <see cref="StudentListVM" /> property's name.
        /// </summary>
        public const string StudentListVMPropertyName = "StudentListVM";

        private StudentListViewModel _StudentListVM;

        /// <summary>
        /// Sets and gets the StudentListVM property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public StudentListViewModel StudentListVM
        {
            get
            {
                return _StudentListVM;
            }

            set
            {
                if ( _StudentListVM == value )
                {
                    return;
                }

                RaisePropertyChanging( StudentListVMPropertyName );
                _StudentListVM = value;
                RaisePropertyChanged( StudentListVMPropertyName );
            }
        }

        public ICommand StudentListViewCommand
        {
            get
            {
                return new RelayCommand( () => changeContent(StudentListVMPropertyName) );
            }
        }
        #endregion

        #region ImportStudent
        /// <summary>
        /// The <see cref="ImportStudentVM" /> property's name.
        /// </summary>
        public const string ImportStudentVMPropertyName = "ImportStudentVM";

        private ImportStudentViewModel _ImportStudentVM = null;

        /// <summary>
        /// Sets and gets the ImportStudentVM property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ImportStudentViewModel ImportStudentVM
        {
            get
            {
                return _ImportStudentVM;
            }

            set
            {
                if ( _ImportStudentVM == value )
                {
                    return;
                }

                RaisePropertyChanging( ImportStudentVMPropertyName );
                _ImportStudentVM = value;
                RaisePropertyChanged( ImportStudentVMPropertyName );
            }
        }
        public ICommand ImportStudentViewCommand
        {
            get
            {
                return new RelayCommand( () => changeContent( ImportStudentVMPropertyName ) );
            }
        }
        #endregion

        public void changeContent(string vm)
        {
            switch(vm)
            {
                case FindStudentVMPropertyName:
                    Content = FindStudentVM;
                    break;
                case StudentListVMPropertyName:
                    Content = StudentListVM;
                    break;
                case ImportStudentVMPropertyName:
                    Content = ImportStudentVM;
                    break;
            }
        }
    }
}