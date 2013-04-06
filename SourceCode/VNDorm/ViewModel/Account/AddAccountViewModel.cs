using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using VNDorm.Collections;
using Enrollment_DSS.Data.Entities;
using Enrollment_DSS.Data.Concretes;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using System.Collections.ObjectModel;
using System.Linq;

namespace VNDorm.ViewModel.Account
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class AddAccountViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the AddAccountViewModel class.
        /// </summary>
        public AddAccountViewModel()
        {
            loadRoleCombo();
        }

        #region property

        /// <summary>
        /// The <see cref="Password" /> property's name.
        /// </summary>
        public const string PasswordPropertyName = "Password";

        private string _Password = string.Empty;

        /// <summary>
        /// Sets and gets the Password property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Password
        {
            get
            {
                return _Password;
            }

            set
            {
                if ( _Password == value )
                {
                    return;
                }

                RaisePropertyChanging( PasswordPropertyName );
                _Password = value;
                RaisePropertyChanged( PasswordPropertyName );
            }
        }

        /// <summary>
        /// The <see cref="UserName" /> property's name.
        /// </summary>
        public const string UserNamePropertyName = "UserName";

        private string _UserName = string.Empty;

        /// <summary>
        /// Sets and gets the UserName property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string UserName
        {
            get
            {
                return _UserName;
            }

            set
            {
                if ( _UserName == value )
                {
                    return;
                }

                RaisePropertyChanging( UserNamePropertyName );
                _UserName = value;
                RaisePropertyChanged( UserNamePropertyName );
                if ( CurrentAccount == null )
                {
                    this.canAddAccount = true;
                }
                else
                {
                    if ( this.UserName == this.CurrentAccount.UserName )
                    {
                        this.canEditAccount = true;
                        this.canDeleteAccount = true;
                        this.canAddAccount = false;
                    }
                    else
                    {
                        this.canAddAccount = true;
                        this.canEditAccount = false;
                        this.canDeleteAccount = false;
                    }
                }
            }
        }
        /// <summary>
        /// The <see cref="RoleList" /> property's name.
        /// </summary>
        public const string RoleListPropertyName = "RoleList";

        private RoleCollection _RoleList = null;

        /// <summary>
        /// Sets and gets the RoleList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public RoleCollection RoleList
        {
            get
            {
                return _RoleList;
            }

            set
            {
                if ( _RoleList == value )
                {
                    return;
                }

                RaisePropertyChanging( RoleListPropertyName );
                _RoleList = value;
                RaisePropertyChanged( RoleListPropertyName );
            }
        }

        /// <summary>
        /// The <see cref="CurrentRole" /> property's name.
        /// </summary>
        public const string CurrentRolePropertyName = "CurrentRole";

        private Role _CurrentRole = null;

        /// <summary>
        /// Sets and gets the CurrentRole property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Role CurrentRole
        {
            get
            {
                return _CurrentRole;
            }

            set
            {
                if ( _CurrentRole == value )
                {
                    return;
                }

                RaisePropertyChanging( CurrentRolePropertyName );
                _CurrentRole = value;
                RaisePropertyChanged( CurrentRolePropertyName );
            }
        }

        /// <summary>
        /// The <see cref="AcountList" /> property's name.
        /// </summary>
        public const string AcountListPropertyName = "AcountList";

        private AccountCollection _AccountList;

        /// <summary>
        /// Sets and gets the AcountList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public AccountCollection AcountList
        {
            get
            {
                return _AccountList;
            }

            set
            {
                if ( _AccountList == value )
                {
                    return;
                }

                RaisePropertyChanging( AcountListPropertyName );
                _AccountList = value;
                RaisePropertyChanged( AcountListPropertyName );
            }
        }

        /// <summary>
        /// The <see cref="CurrentAccount" /> property's name.
        /// </summary>
        public const string CurrentAccountPropertyName = "CurrentAccount";

        private Enrollment_DSS.Data.Entities.Account _CurrentAccount = null;

        /// <summary>
        /// Sets and gets the CurrentAccount property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public Enrollment_DSS.Data.Entities.Account CurrentAccount
        {
            get
            {
                return _CurrentAccount;
            }

            set
            {
                if ( _CurrentAccount == value )
                {
                    return;
                }

                RaisePropertyChanging( CurrentAccountPropertyName );
                _CurrentAccount = value;
                RaisePropertyChanged( CurrentAccountPropertyName );
                if ( _CurrentAccount != null )
                {
                    this.UserName = _CurrentAccount.UserName;
                    this.Password = _CurrentAccount.Password;
                    this.CurrentRole = _CurrentAccount.Role;
                    this.canEditAccount = true;
                    this.canDeleteAccount = true;


                    RaisePropertyChanged( UserNamePropertyName );
                    RaisePropertyChanged( PasswordPropertyName );
                    RaisePropertyChanged( CurrentRolePropertyName );
                }
                else
                {
                    this.canEditAccount = false;
                    this.canDeleteAccount = false;
                }
                RaisePropertyChanged( canEditAccountPropertyName );
                RaisePropertyChanged( canDeleteAccountPropertyName );
            }
        }
        #region enable value
        /// <summary>
        /// The <see cref="canEditAccount" /> property's name.
        /// </summary>
        public const string canEditAccountPropertyName = "canEditAccount";

        private bool _canEditAccount = false;

        /// <summary>
        /// Sets and gets the canEditAccount property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool canEditAccount
        {
            get
            {
                return _canEditAccount;
            }

            set
            {
                if ( _canEditAccount == value )
                {
                    return;
                }

                RaisePropertyChanging( canEditAccountPropertyName );
                _canEditAccount = value;
                RaisePropertyChanged( canEditAccountPropertyName );
            }
        }

        /// <summary>
        /// The <see cref="canDeleteAccount" /> property's name.
        /// </summary>
        public const string canDeleteAccountPropertyName = "canDeleteAccount";

        private bool _canDeleteAccount = false;

        /// <summary>
        /// Sets and gets the canDeleteAccount property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool canDeleteAccount
        {
            get
            {
                return _canDeleteAccount;
            }

            set
            {
                if ( _canDeleteAccount == value )
                {
                    return;
                }

                RaisePropertyChanging( canDeleteAccountPropertyName );
                _canDeleteAccount = value;
                RaisePropertyChanged( canDeleteAccountPropertyName );
            }
        }
        /// <summary>
        /// The <see cref="canAddAccount" /> property's name.
        /// </summary>
        public const string canAddAccountPropertyName = "canAddAccount";

        private bool _canAddAccount = false;

        /// <summary>
        /// Sets and gets the canAddAccount property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool canAddAccount
        {
            get
            {
                return _canAddAccount;
            }

            set
            {
                if ( _canAddAccount == value )
                {
                    return;
                }

                RaisePropertyChanging( canAddAccountPropertyName );
                _canAddAccount = value;
                RaisePropertyChanged( canAddAccountPropertyName );
            }
        }
        #endregion
        #endregion


        #region Repository
        AccountRepository accountRepos = new AccountRepository();
        #endregion

        #region command
        private RelayCommand _AddNewAccountCommand;

        /// <summary>
        /// Gets the AddNewAccountCommand.
        /// </summary>
        public RelayCommand AddNewAccountCommand
        {
            get
            {
                return _AddNewAccountCommand
                    ?? ( _AddNewAccountCommand = new RelayCommand(
                                          () =>
                                          {
                                              AddNewAccountMethod();
                                          } ) );
            }
        }

        private RelayCommand _DeleteAccountCommand;

        /// <summary>
        /// Gets the DeleteAccountCommand.
        /// </summary>
        public RelayCommand DeleteAccountCommand
        {
            get
            {
                return _DeleteAccountCommand
                    ?? ( _DeleteAccountCommand = new RelayCommand(
                                          () =>
                                          {
                                              DeleteAccountMethod();
                                          } ) );
            }
        }

        private RelayCommand _EditAccountCommand;

        /// <summary>
        /// Gets the EditAccountCommand.
        /// </summary>
        public RelayCommand EditAccountCommand
        {
            get
            {
                return _EditAccountCommand
                    ?? ( _EditAccountCommand = new RelayCommand(
                                          () =>
                                          {
                                              EditAccountMethod();
                                          } ) );
            }
        }

        private RelayCommand _FindAccountCommand;

        /// <summary>
        /// Gets the FindAccountCommand.
        /// </summary>
        public RelayCommand FindAccountCommand
        {
            get
            {
                return _FindAccountCommand
                    ?? ( _FindAccountCommand = new RelayCommand(
                                          () =>
                                          {
                                              FindAccount();
                                          } ) );
            }
        }
        #endregion

        #region Method

        public void FindAccount()
        {
            if ( CurrentRole != null )
            {
                this.AcountList = new AccountCollection( CurrentRole.RoleID );
            }
        }

        public void EditAccountMethod()
        {
            if ( CurrentAccount != null )
            {
                if ( this.UserName.Equals( "" ) || this.Password.Equals( "" ) || this.CurrentRole == null )
                {
                    MessageBox.Show( "Check your account data" );
                    return;
                }
                if ( accountRepos.UpdateAccount( this.UserName, this.Password,this.CurrentRole.RoleID ) == 0 )
                {
                    MessageBox.Show( "This username was not found" );
                }
                else
                { 
                }
            }
            else
            {
                MessageBox.Show( "You must choose one account" );
            }
        }

        public void DeleteAccountMethod()
        {
            if ( CurrentAccount != null )
            {
                if ( MessageBox.Show( "Do you want to delete this account ?", "Delete", MessageBoxButton.YesNo ) == MessageBoxResult.Yes )
                {
                    accountRepos.Delete( CurrentAccount );
                    this.AcountList.Remove( CurrentAccount );
                }
            }
            else
            {
                MessageBox.Show("You must choose one account");
            }
        }

        public void AddNewAccountMethod()
        {
            if ( this.UserName.Equals( "" ) || this.Password.Equals( "" ) || this.CurrentRole == null )
            {
                MessageBox.Show("Check your data");
                return;
            }
            else
                if ( accountRepos.CheckExist( this.UserName ) == false )
                {
                    accountRepos.AddAccount( this.UserName, this.Password, this.CurrentRole.RoleID );
                    Enrollment_DSS.Data.Entities.Account newAccount = new Enrollment_DSS.Data.Entities.Account();
                    newAccount.UserName = this.UserName;
                    newAccount.Password = this.Password;
                    newAccount.Role = this.CurrentRole;
                    newAccount.RoleID = this.CurrentRole.RoleID;
                    MessageBox.Show( newAccount.UserName + " : " + newAccount.Password + " : " + newAccount.RoleID );
                    FindAccount();
                }
                else 
                {
                    MessageBox.Show("This username was exits");
                }
        }
        public void loadRoleCombo()
        {
            this.RoleList = RoleCollection.Current;
            this.CurrentRole = this.RoleList.FirstOrDefault();
        }
        #endregion
        #region helper
        #endregion
    }
}