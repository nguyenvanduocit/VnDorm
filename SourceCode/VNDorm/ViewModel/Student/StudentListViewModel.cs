using GalaSoft.MvvmLight;
using System.Linq;
using Enrollment_DSS.Data.Concretes;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Enrollment_DSS.Data.Entities;
using VNDorm.Collections;
using System;
using GalaSoft.MvvmLight.Command;
using System.Windows;
namespace VNDorm.ViewModel.Student
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class StudentListViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the StudentListViewModel class.
        /// </summary>
        public StudentListViewModel()
        {
            LoadCboFaculty();
            loadCboProvince();
            loadCboGender();
            loadCboYear();
            loadCboBlock();
        }

        #region Repository
        StudentRepository studentRepo = new StudentRepository();
        FacultyRepository facultyRepo = new FacultyRepository();
        #endregion

        #region field

        /// <summary>
        /// The <see cref="CboProvince" /> property's name.
        /// </summary>
        public const string CboProvincePropertyName = "CboProvince";

        private ObservableCollection<string> _CboProvince = null;

        /// <summary>
        /// Sets and gets the CboProvince property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<string> CboProvince
        {
            get
            {
                return _CboProvince;
            }

            set
            {
                if ( _CboProvince == value )
                {
                    return;
                }

                RaisePropertyChanging( CboProvincePropertyName );
                _CboProvince = value;
                RaisePropertyChanged( CboProvincePropertyName );
            }
        }
        /// <summary>
        /// The <see cref="ProvinceItem" /> property's name.
        /// </summary>
        public const string ProvinceItemPropertyName = "ProvinceItem";

        private string _ProvinceItem = string.Empty;

        /// <summary>
        /// Sets and gets the ProvinceItem property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ProvinceItem
        {
            get
            {
                return _ProvinceItem;
            }

            set
            {
                if ( _ProvinceItem == value )
                {
                    return;
                }

                RaisePropertyChanging( ProvinceItemPropertyName );
                _ProvinceItem = value;
                RaisePropertyChanged( ProvinceItemPropertyName );
            }
        }
        /// <summary>
        /// The <see cref="FacultyItem" /> property's name.
        /// </summary>
        public const string FacultyItemPropertyName = "FacultyItem";

        private Faculty _FacultyItem = null;

        /// <summary>
        /// Sets and gets the FacultyItem property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Faculty FacultyItem
        {
            get
            {
                return _FacultyItem;
            }

            set
            {
                if ( _FacultyItem == value )
                {
                    return;
                }

                RaisePropertyChanging( FacultyItemPropertyName );
                _FacultyItem = value;
                RaisePropertyChanged( FacultyItemPropertyName );
            }
        }

        /// <summary>
        /// The <see cref="CboFaculty" /> property's name.
        /// </summary>
        public const string CboFacultyPropertyName = "CboFaculty";

        private ObservableCollection<Faculty> _CboFaculty = null;

        /// <summary>
        /// Sets and gets the CboFaculty property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Faculty> CboFaculty
        {
            get
            {
                return _CboFaculty;
            }

            set
            {
                if ( _CboFaculty == value )
                {
                    return;
                }

                RaisePropertyChanging( CboFacultyPropertyName );
                _CboFaculty = value;
                RaisePropertyChanged( CboFacultyPropertyName );
            }
        }
        /// <summary>
        /// The <see cref="CboGender" /> property's name.
        /// </summary>
        public const string CboGenderPropertyName = "CboGender";

        private ObservableCollection<string> _CboGender = null;

        /// <summary>
        /// Sets and gets the CboGender property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<string> CboGender
        {
            get
            {
                return _CboGender;
            }

            set
            {
                if ( _CboGender == value )
                {
                    return;
                }

                RaisePropertyChanging( CboGenderPropertyName );
                _CboGender = value;
                RaisePropertyChanged( CboGenderPropertyName );
            }
        }
        /// <summary>
        /// The <see cref="GenderItem" /> property's name.
        /// </summary>
        public const string GenderItemPropertyName = "GenderItem";

        private string _GenderItem = string.Empty;

        /// <summary>
        /// Sets and gets the GenderItem property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string GenderItem
        {
            get
            {
                return _GenderItem;
            }

            set
            {
                if ( _GenderItem == value )
                {
                    return;
                }

                RaisePropertyChanging( GenderItemPropertyName );
                _GenderItem = value;
                RaisePropertyChanged( GenderItemPropertyName );
            }
        }

        /// <summary>
        /// The <see cref="CboYear" /> property's name.
        /// </summary>
        public const string CboYearPropertyName = "CboYear";

        private ObservableCollection<string> _CboYear = null;

        /// <summary>
        /// Sets and gets the CboYear property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<string> CboYear
        {
            get
            {
                return _CboYear;
            }

            set
            {
                if ( _CboYear == value )
                {
                    return;
                }

                RaisePropertyChanging( CboYearPropertyName );
                _CboYear = value;
                RaisePropertyChanged( CboYearPropertyName );
            }
        }
        /// <summary>
        /// The <see cref="YearItem" /> property's name.
        /// </summary>
        public const string YearItemPropertyName = "YearItem";

        private string _myProperty = string.Empty;

        /// <summary>
        /// Sets and gets the YearItem property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string YearItem
        {
            get
            {
                return _myProperty;
            }

            set
            {
                if ( _myProperty == value )
                {
                    return;
                }

                RaisePropertyChanging( YearItemPropertyName );
                _myProperty = value;
                RaisePropertyChanged( YearItemPropertyName );
            }
        }

        /// <summary>
        /// The <see cref="CboBlock" /> property's name.
        /// </summary>
        public const string CboBlockPropertyName = "CboBlock";

        private ObservableCollection<string> _CboBlock = null;

        /// <summary>
        /// Sets and gets the CboBlock property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<string> CboBlock
        {
            get
            {
                return _CboBlock;
            }

            set
            {
                if ( _CboBlock == value )
                {
                    return;
                }

                RaisePropertyChanging( CboBlockPropertyName );
                _CboBlock = value;
                RaisePropertyChanged( CboBlockPropertyName );
            }
        }
        /// <summary>
        /// The <see cref="BlockItem" /> property's name.
        /// </summary>
        public const string BlockItemPropertyName = "BlockItem";

        private string _BlockItem = string.Empty;

        /// <summary>
        /// Sets and gets the BlockItem property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string BlockItem
        {
            get
            {
                return _BlockItem;
            }

            set
            {
                if ( _BlockItem == value )
                {
                    return;
                }

                RaisePropertyChanging( BlockItemPropertyName );
                _BlockItem = value;
                RaisePropertyChanged( BlockItemPropertyName );
                loadCboFloor();

            }
        }
        /// <summary>
        /// The <see cref="CboFloor" /> property's name.
        /// </summary>
        public const string CboFloorPropertyName = "CboFloor";

        private ObservableCollection<int> _CboFloor = null;

        /// <summary>
        /// Sets and gets the CboFloor property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<int> CboFloor
        {
            get
            {
                return _CboFloor;
            }

            set
            {
                if ( _CboFloor == value )
                {
                    return;
                }

                RaisePropertyChanging( CboFloorPropertyName );
                _CboFloor = value;
                RaisePropertyChanged( CboFloorPropertyName );
            }
        }
        /// <summary>
        /// The <see cref="FloorItem" /> property's name.
        /// </summary>
        public const string FloorItemPropertyName = "FloorItem";

        private int _FloorItem = -1;

        /// <summary>
        /// Sets and gets the FloorItem property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int FloorItem
        {
            get
            {
                return _FloorItem;
            }

            set
            {
                if ( _FloorItem == value )
                {
                    return;
                }

                RaisePropertyChanging( FloorItemPropertyName );
                _FloorItem = value;
                RaisePropertyChanged( FloorItemPropertyName );
                loadDboRoom();
            }
        }

        /// <summary>
        /// The <see cref="FirstName" /> property's name.
        /// </summary>
        public const string FirstNamePropertyName = "FirstName";

        private string _FirstName = string.Empty;

        /// <summary>
        /// Sets and gets the FirstName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string FirstName
        {
            get
            {
                return _FirstName;
            }

            set
            {
                if ( _FirstName == value )
                {
                    return;
                }

                RaisePropertyChanging( FirstNamePropertyName );
                _FirstName = value;
                RaisePropertyChanged( FirstNamePropertyName );
            }
        }

        /// <summary>
        /// The <see cref="LastName" /> property's name.
        /// </summary>
        public const string LastNamePropertyName = "LastName";

        private string _LastName = string.Empty;

        /// <summary>
        /// Sets and gets the LastName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string LastName
        {
            get
            {
                return _LastName;
            }

            set
            {
                if ( _LastName == value )
                {
                    return;
                }

                RaisePropertyChanging( LastNamePropertyName );
                _LastName = value;
                RaisePropertyChanged( LastNamePropertyName );
            }
        }

        /// <summary>
        /// The <see cref="Ethnicity" /> property's name.
        /// </summary>
        public const string EthnicityPropertyName = "Ethnicity";

        private string _Ethnicity = string.Empty;

        /// <summary>
        /// Sets and gets the Ethnicity property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Ethnicity
        {
            get
            {
                return _Ethnicity;
            }

            set
            {
                if ( _Ethnicity == value )
                {
                    return;
                }

                RaisePropertyChanging( EthnicityPropertyName );
                _Ethnicity = value;
                RaisePropertyChanged( EthnicityPropertyName );
            }
        }
        /// <summary>
        /// The <see cref="BirthDay" /> property's name.
        /// </summary>
        public const string BirthDayPropertyName = "BirthDay";

        private DateTime _BirthDay = DateTime.Today;

        /// <summary>
        /// Sets and gets the BirthDay property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime BirthDay
        {
            get
            {
                return _BirthDay;
            }

            set
            {
                if ( _BirthDay == value )
                {
                    return;
                }

                RaisePropertyChanging( BirthDayPropertyName );
                _BirthDay = value;
                RaisePropertyChanged( BirthDayPropertyName );
            }
        }
        /// <summary>
        /// The <see cref="Address" /> property's name.
        /// </summary>
        public const string AddressPropertyName = "Address";

        private string _Address = string.Empty;

        /// <summary>
        /// Sets and gets the Address property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Address
        {
            get
            {
                return _Address;
            }

            set
            {
                if ( _Address == value )
                {
                    return;
                }

                RaisePropertyChanging( AddressPropertyName );
                _Address = value;
                RaisePropertyChanged( AddressPropertyName );
            }
        }

        /// <summary>
        /// The <see cref="ClassID" /> property's name.
        /// </summary>
        public const string ClassIDPropertyName = "ClassID";

        private string _ClassID = string.Empty;

        /// <summary>
        /// Sets and gets the ClassID property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ClassID
        {
            get
            {
                return _ClassID;
            }

            set
            {
                if ( _ClassID == value )
                {
                    return;
                }

                RaisePropertyChanging( ClassIDPropertyName );
                _ClassID = value;
                RaisePropertyChanged( ClassIDPropertyName );
            }
        }
        /// <summary>
        /// The <see cref="StudentID" /> property's name.
        /// </summary>
        public const string StudentIDPropertyName = "StudentID";

        private string _StudentID = string.Empty;

        /// <summary>
        /// Sets and gets the StudentID property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string StudentID
        {
            get
            {
                return _StudentID;
            }

            set
            {
                if ( _StudentID == value )
                {
                    return;
                }

                RaisePropertyChanging( StudentIDPropertyName );
                _StudentID = value;
                RaisePropertyChanged( StudentIDPropertyName );
                if ( CurrentStudent == null || StudentID != CurrentStudent.StudentID )
                {
                    this.canAdd = true;
                    this.canEdit = false;
                    this.canDelete = false;
                }
                else
                if ( StudentID == CurrentStudent.StudentID )
                {
                    this.canEdit = true;
                    this.canDelete = true;
                    this.canAdd = false;
                }
            }
        }
        /// <summary>
        /// The <see cref="Phone" /> property's name.
        /// </summary>
        public const string PhonePropertyName = "Phone";

        private string _Phone = string.Empty;

        /// <summary>
        /// Sets and gets the Phone property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Phone
        {
            get
            {
                return _Phone;
            }

            set
            {
                if ( _Phone == value )
                {
                    return;
                }

                RaisePropertyChanging( PhonePropertyName );
                _Phone = value;
                RaisePropertyChanged( PhonePropertyName );
            }
        }
        /// <summary>
        /// The <see cref="Religion" /> property's name.
        /// </summary>
        public const string ReligionPropertyName = "Religion";

        private string _Religion = string.Empty;

        /// <summary>
        /// Sets and gets the Religion property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Religion
        {
            get
            {
                return _Religion;
            }

            set
            {
                if ( _Religion == value )
                {
                    return;
                }

                RaisePropertyChanging( ReligionPropertyName );
                _Religion = value;
                RaisePropertyChanged( ReligionPropertyName );
            }
        }
        /// <summary>
        /// The <see cref="IdentityID" /> property's name.
        /// </summary>
        public const string IdentityIDPropertyName = "IdentityID";

        private string _IdentityID = string.Empty;

        /// <summary>
        /// Sets and gets the IdentityID property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string IdentityID
        {
            get
            {
                return _IdentityID;
            }

            set
            {
                if ( _IdentityID == value )
                {
                    return;
                }

                RaisePropertyChanging( IdentityIDPropertyName );
                _IdentityID = value;
                RaisePropertyChanged( IdentityIDPropertyName );
            }
        }
        /// <summary>
        /// The <see cref="ValidityDate" /> property's name.
        /// </summary>
        public const string ValidityDatePropertyName = "ValidityDate";

        private DateTime _ValidityDate = DateTime.Today;

        /// <summary>
        /// Sets and gets the ValidityDate property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime ValidityDate
        {
            get
            {
                return _ValidityDate;
            }

            set
            {
                if ( _ValidityDate == value )
                {
                    return;
                }

                RaisePropertyChanging( ValidityDatePropertyName );
                _ValidityDate = value;
                RaisePropertyChanged( ValidityDatePropertyName );
            }
        }
        /// <summary>
        /// The <see cref="CurrentStudent" /> property's name.
        /// </summary>
        public const string CurrentStudentPropertyName = "CurrentStudent";

        private Enrollment_DSS.Data.Entities.Student _CurrentStudent = null;

        /// <summary>
        /// Sets and gets the CurrentStudent property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Enrollment_DSS.Data.Entities.Student CurrentStudent
        {
            get
            {
                return _CurrentStudent;
            }

            set
            {
                if ( _CurrentStudent == value || value  == null)
                {
                    return;
                }

                RaisePropertyChanging( CurrentStudentPropertyName );
                _CurrentStudent = value;
                RaisePropertyChanged( CurrentStudentPropertyName );
                GridViewItemToControls();
            }
        }
        /// <summary>
        /// The <see cref="CboRoom" /> property's name.
        /// </summary>
        public const string CboRoomPropertyName = "CboRoom";

        private ObservableCollection<Room> _CboRoom = null;

        /// <summary>
        /// Sets and gets the CboRoom property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<Room> CboRoom
        {
            get
            {
                return _CboRoom;
            }

            set
            {
                if ( _CboRoom == value )
                {
                    return;
                }

                RaisePropertyChanging( CboRoomPropertyName );
                _CboRoom = value;
                RaisePropertyChanged( CboRoomPropertyName );
            }
        }
        /// <summary>
        /// The <see cref="RoomItem" /> property's name.
        /// </summary>
        public const string RoomItemPropertyName = "RoomItem";

        private Room _RoomItem = null;

        /// <summary>
        /// Sets and gets the RoomItem property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Room RoomItem
        {
            get
            {
                return _RoomItem;
            }

            set
            {
                if ( _RoomItem == value )
                {
                    return;
                }

                RaisePropertyChanging( RoomItemPropertyName );
                _RoomItem = value;
                RaisePropertyChanged( RoomItemPropertyName );
                loadStudent();
            }
        }

        /// <summary>
        /// The <see cref="StudentList" /> property's name.
        /// </summary>
        public const string StudentListPropertyName = "StudentList";

        private StudentCollection _StudentList = null;

        /// <summary>
        /// Sets and gets the StudentList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public StudentCollection StudentList
        {
            get
            {
                return _StudentList;
            }

            set
            {
                if ( _StudentList == value )
                {
                    return;
                }

                RaisePropertyChanging( StudentListPropertyName );
                _StudentList = value;
                RaisePropertyChanged( StudentListPropertyName );
            }
        }
        /// <summary>
        /// The <see cref="canEdit" /> property's name.
        /// </summary>
        public const string canEditPropertyName = "canEdit";

        private bool _canEdit = false;

        /// <summary>
        /// Sets and gets the canEdit property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool canEdit
        {
            get
            {
                return _canEdit;
            }

            set
            {
                if ( _canEdit == value )
                {
                    return;
                }

                RaisePropertyChanging( canEditPropertyName );
                _canEdit = value;
                RaisePropertyChanged( canEditPropertyName );
            }
        }
        /// <summary>
        /// The <see cref="canAdd" /> property's name.
        /// </summary>
        public const string canAddPropertyName = "canAdd";

        private bool _canAdd = false;

        /// <summary>
        /// Sets and gets the canAdd property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool canAdd
        {
            get
            {
                return _canAdd;
            }

            set
            {
                if ( _canAdd == value )
                {
                    return;
                }

                RaisePropertyChanging( canAddPropertyName );
                _canAdd = value;
                RaisePropertyChanged( canAddPropertyName );
            }
        }
        /// <summary>
        /// The <see cref="canDelete" /> property's name.
        /// </summary>
        public const string canDeletePropertyName = "canDelete";

        private bool _canDelete = false;

        /// <summary>
        /// Sets and gets the canDelete property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool canDelete
        {
            get
            {
                return _canDelete;
            }

            set
            {
                if ( _canDelete == value )
                {
                    return;
                }

                RaisePropertyChanging( canDeletePropertyName );
                _canDelete = value;
                RaisePropertyChanged( canDeletePropertyName );
            }
        }
        #endregion

        #region load combobox
        void LoadCboFaculty()
        {
            CboFaculty = FacultyCollections.Current;
            FacultyItem = CboFaculty.FirstOrDefault();
        }
        void loadCboProvince()
        {
            this.CboProvince = ProvinceCollection.Current;
            ProvinceItem = CboProvince.FirstOrDefault();
        }
        void loadCboGender()
        {
            this.CboGender = GenderCollection.Current;
            GenderItem = CboGender.FirstOrDefault();
        }
        void loadCboYear()
        {
            this.CboYear = YearCollection.Current;
            YearItem = CboYear.FirstOrDefault();
        }
        void loadCboBlock()
        {
            this.CboBlock = BlockCollection.Current;
            BlockItem = CboBlock.FirstOrDefault();
        }
        void loadCboFloor()
        {
            this.CboFloor = FloorCollection.getFloorByBlock( this.BlockItem );
            FloorItem = CboFloor.FirstOrDefault();
        }
        void loadDboRoom()
        {
            if ( this.FloorItem >= 0 )
            {
                this.CboRoom = RoomCollections.getRoomByBlockFloor( this.BlockItem, this.FloorItem );
                RoomItem = CboRoom.FirstOrDefault();
            }
        }
        #endregion

        #region command
        private RelayCommand _AddStudentCommand;

        /// <summary>
        /// Gets the AddStudentCommand.
        /// </summary>
        public RelayCommand AddStudentCommand
        {
            get
            {
                return _AddStudentCommand
                    ?? ( _AddStudentCommand = new RelayCommand(
                                          () =>
                                          {
                                              AddStudentMethod();
                                          } ) );
            }
        }

        private RelayCommand _EditStudentCommand;

        /// <summary>
        /// Gets the EditStudentCommand.
        /// </summary>
        public RelayCommand EditStudentCommand
        {
            get
            {
                return _EditStudentCommand
                    ?? ( _EditStudentCommand = new RelayCommand(
                                          () =>
                                          {
                                              EditStudentMethod();
                                          } ) );
            }
        }
        private RelayCommand _DeleteStudentCommand;

        /// <summary>
        /// Gets the DeleteStudentCommand.
        /// </summary>
        public RelayCommand DeleteStudentCommand
        {
            get
            {
                return _DeleteStudentCommand
                    ?? ( _DeleteStudentCommand = new RelayCommand(
                                          () =>
                                          {
                                              DeleteStudentMethod();
                                          } ) );
            }
        }
        #endregion

        #region method

        public void DeleteStudentMethod()
        {
            if ( this.CurrentStudent != null )
            {
                this.StudentList.RemoveStudent(CurrentStudent);
                this.CurrentStudent = this.StudentList.FirstOrDefault();
            }
        }
        public void EditStudentMethod()
        {
            if ( checkField() )
            {
                makeEditItem();
                this.StudentList.ModifyItem(this.CurrentStudent);
                loadStudent();
            }
            else
            {
                MessageBox.Show( "You need to provide sufficient information" );
            }
        }

        public void AddStudentMethod()
        {
            if (checkField())
            {
                if ( StudentRepository.GetRepository().CheckExist( this.StudentID ) )
                {
                    MessageBox.Show( "This account already exists, please edit the information." );
                }
                else
                {
                    Enrollment_DSS.Data.Entities.Student newStudent = new Enrollment_DSS.Data.Entities.Student();
                    newStudent = makeNewItem();
                    MessageBox.Show( newStudent.ToString() );
                    this.StudentList.addStudent( newStudent );
                    this.CurrentStudent = this.StudentList.FirstOrDefault();
                }
            }
            else
            {
                MessageBox.Show( "You need to provide sufficient information" );   
            }
        }

        public bool checkField()
        {
            if (
                this.Address == string.Empty ||
                this.FirstName == string.Empty ||
                this.LastName == string.Empty ||
                this.StudentID == string.Empty ||
                this.GenderItem == string.Empty ||
                this.Ethnicity == string.Empty ||
                this.Address == string.Empty ||
                this.Religion == string.Empty ||
                this.Phone == string.Empty ||
                this.ClassID == string.Empty ||
                this.IdentityID == string.Empty ||
                this.ProvinceItem == string.Empty )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Enrollment_DSS.Data.Entities.Student makeNewItem()
        {
            Enrollment_DSS.Data.Entities.Student newStudent = new Enrollment_DSS.Data.Entities.Student();
            if ( this.CurrentStudent != null )
            {
                newStudent.Address = this.Address;
                newStudent.BirthDay = this.BirthDay;
                newStudent.FacultyID = this.FacultyItem.FacultyID;
                newStudent.IntoSchoolYear = this.YearItem;
                newStudent.FirstName = this.FirstName;
                newStudent.LastName = this.LastName;
                newStudent.StudentID = this.StudentID;
                newStudent.Sex = this.CboGender.IndexOf( this.GenderItem ).ToString();
                newStudent.Ethnic = this.Ethnicity;
                newStudent.BirthDay = this.BirthDay;
                newStudent.Address = this.Address;
                newStudent.Religion = this.Religion;
                newStudent.Phone = this.Phone;
                newStudent.ClassID = this.ClassID;
                newStudent.IdentityNo = this.IdentityID;
                newStudent.ValidityDate = this.ValidityDate;
                newStudent.Province = this.ProvinceItem;
                newStudent.RoomID = this.RoomItem.RoomID;
            }
            return newStudent;
        }
        public void makeEditItem()
        {
            if ( this.CurrentStudent != null )
            {
                CurrentStudent.Address = this.Address;
                CurrentStudent.BirthDay = this.BirthDay;
                CurrentStudent.FacultyID = this.FacultyItem.FacultyID;
                CurrentStudent.IntoSchoolYear = this.YearItem;
                CurrentStudent.FirstName = this.FirstName;
                CurrentStudent.LastName = this.LastName;
                CurrentStudent.StudentID = this.StudentID;
                CurrentStudent.Sex = this.CboGender.IndexOf( this.GenderItem ).ToString();
                CurrentStudent.Ethnic = this.Ethnicity;
                CurrentStudent.BirthDay = this.BirthDay;
                CurrentStudent.Address = this.Address;
                CurrentStudent.Religion = this.Religion;
                CurrentStudent.Phone = this.Phone;
                CurrentStudent.ClassID = this.ClassID;
                CurrentStudent.IdentityNo = this.IdentityID;
                CurrentStudent.ValidityDate = this.ValidityDate;
                CurrentStudent.Province = this.ProvinceItem;
                CurrentStudent.RoomID = this.RoomItem.RoomID;
            }
        }
        #endregion

        private void loadStudent()
        {
            if ( this.RoomItem != null )
            {
                this.StudentList = new StudentCollection( this.RoomItem.RoomID );
            }
        }

        void GridViewItemToControls()
        {
            if ( this.CurrentStudent != null )
            {
                this.Address = CurrentStudent.Address;
                this.BirthDay = CurrentStudent.BirthDay.Value;
                this.FacultyItem = this.CboFaculty[int.Parse(CurrentStudent.FacultyID)];
                this.YearItem =this.CboYear[this.CboYear.IndexOf(CurrentStudent.IntoSchoolYear)];
                this.FirstName = CurrentStudent.FirstName;
                this.LastName = CurrentStudent.LastName;
                this.StudentID = CurrentStudent.StudentID;
                this.GenderItem = this.CboGender[int.Parse(CurrentStudent.Sex)];
                this.Ethnicity = CurrentStudent.Ethnic;
                this.BirthDay = CurrentStudent.BirthDay.Value;
                this.Address = CurrentStudent.Address;
                this.Religion = CurrentStudent.Religion;
                this.Phone = CurrentStudent.Phone;
                this.ClassID = CurrentStudent.ClassID;
                this.IdentityID = CurrentStudent.IdentityNo;
                this.ValidityDate = CurrentStudent.ValidityDate;
                this.ProvinceItem = CurrentStudent.Province;
            }
        }
    }
}