using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Practices.Unity;
using Enrollment_DSS.Data.Entities;
using VNDorm.Infrastructures;
using VNDorm.Services.Child;
using VNDorm.Model;
using System.Windows;
namespace VNDorm.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IUnityContainer _container;
        private ILoginAccountChild _accountChildWindow;
        private IAboutChild _aboutChildWindow;

        public MainViewModel()
        {
            if ( ViewModelBase.IsInDesignModeStatic )
            {
            }
            else
            {
                #region Create Child Window
                _container = UnityContainerResolver.Container;
                #endregion
                _accountChildWindow = _container.Resolve<ILoginAccountChild>();
                _accountChildWindow.SetModel( new LoginAccountViewModel( _accountChildWindow ) );
                _accountChildWindow.ShowDialog();
            }
            checkRole();
            loadCboLanguage();
        }

        private RelayCommand _showAboutCommand;

        /// <summary>
        /// Gets the showAboutCommand.
        /// </summary>
        public RelayCommand showAboutCommand
        {
            get
            {
                return _showAboutCommand
                    ?? ( _showAboutCommand = new RelayCommand(
                                          () =>
                                          {
                                              showAboutMethod();
                                          } ) );
            }
        }
        void showAboutMethod()
        {
            #region Create Child Window
            #endregion
            _aboutChildWindow = _container.Resolve<IAboutChild>();
            _aboutChildWindow.SetModel( new AbountViewViewModel( _aboutChildWindow ) );
            _aboutChildWindow.ShowDialog();
        }
        #region property
        #region role

        /// <summary>
        /// The <see cref="canStaff" /> property's name.
        /// </summary>
        public const string canStaffPropertyName = "canStaff";

        private bool _canStaff = false;

        /// <summary>
        /// Sets and gets the canStaff property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool canStaff
        {
            get
            {
                return _canStaff;
            }

            set
            {
                if ( _canStaff == value )
                {
                    return;
                }

                RaisePropertyChanging( canStaffPropertyName );
                _canStaff = value;
                RaisePropertyChanged( canStaffPropertyName );
            }
        }

        /// <summary>
        /// The <see cref="canEquipment" /> property's name.
        /// </summary>
        public const string canEquipmentPropertyName = "canEquipment";

        private bool _canEquipment = false;

        /// <summary>
        /// Sets and gets the canEquipment property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool canEquipment
        {
            get
            {
                return _canEquipment;
            }

            set
            {
                if ( _canEquipment == value )
                {
                    return;
                }

                RaisePropertyChanging( canEquipmentPropertyName );
                _canEquipment = value;
                RaisePropertyChanged( canEquipmentPropertyName );
            }
        }

        /// <summary>
        /// The <see cref="canAccount" /> property's name.
        /// </summary>
        public const string canAccountPropertyName = "canAccount";

        private bool _canAccount = false;

        /// <summary>
        /// Sets and gets the canAccount property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool canAccount
        {
            get
            {
                return _canAccount;
            }

            set
            {
                if ( _canAccount == value )
                {
                    return;
                }

                RaisePropertyChanging( canAccountPropertyName );
                _canAccount = value;
                RaisePropertyChanged( canAccountPropertyName );
            }
        }

        /// <summary>
        /// The <see cref="canRoom" /> property's name.
        /// </summary>
        public const string canRoomPropertyName = "canRoom";

        private bool _canRoom = false;

        /// <summary>
        /// Sets and gets the canRoom property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool canRoom
        {
            get
            {
                return _canRoom;
            }

            set
            {
                if ( _canRoom == value )
                {
                    return;
                }

                RaisePropertyChanging( canRoomPropertyName );
                _canRoom = value;
                RaisePropertyChanged( canRoomPropertyName );
            }
        }

        /// <summary>
        /// The <see cref="canStudent" /> property's name.
        /// </summary>
        public const string canStudentPropertyName = "canStudent";

        private bool _canStudent = false;

        /// <summary>
        /// Sets and gets the canStudent property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool canStudent
        {
            get
            {
                return _canStudent;
            }

            set
            {
                if ( _canStudent == value )
                {
                    return;
                }

                RaisePropertyChanging( canStudentPropertyName );
                _canStudent = value;
                RaisePropertyChanged( canStudentPropertyName );
            }
        }
        #endregion

        #endregion

        #region method
        public void checkRole()
        {
            int role = AccountModel.RoleID;
            switch ( role )
            { 
                case 1:
                    this.canStudent = true;
                    break;
                case 2:
                    this.canRoom = true;
                    break;
                case 3:
                    this.canEquipment = true;
                    break;
                case 4:
                    this.canStaff = true;
                    break;
                case 5:
                    this.canAccount = true;
                    this.canStudent = true;
                    this.canEquipment = true;
                    this.canRoom = true;
                    this.canStaff = true;
                    break;
            }
        }
        #endregion
        #region language
        /// <summary>
        /// The <see cref="LanguageItem" /> property's name.
        /// </summary>
        public const string LanguageItemPropertyName = "LanguageItem";

        private string _LanguageItem = string.Empty;

        /// <summary>
        /// Sets and gets the LanguageItem property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string LanguageItem
        {
            get
            {
                return _LanguageItem;
            }

            set
            {
                if ( _LanguageItem == value )
                {
                    return;
                }

                RaisePropertyChanging( LanguageItemPropertyName );
                _LanguageItem = value;
                RaisePropertyChanged( LanguageItemPropertyName );
                ChangeLanguage();
            }
        }
        public void ChangeLanguage()
        {
            if ( this.LanguageItem != string.Empty )
            {
                if ( System.Configuration.ConfigurationManager.AppSettings["CurrentLanguage"] != this.LanguageItem )
                {
                    System.Configuration.ConfigurationManager.AppSettings["CurrentLanguage"] = this.LanguageItem;
                    MessageBox.Show( "You must restart application." );
                }
            }
        }
        public void loadCboLanguage()
        {
            this.LanguageItem = System.Configuration.ConfigurationManager.AppSettings["CurrentLanguage"];
        }
        #endregion
        public override void Cleanup()
        {
            // Clean up if needed
            base.Cleanup();
        }
    }
}