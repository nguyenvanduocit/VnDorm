using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using VNDorm.Collections;
using Enrollment_DSS.Data.Entities;
using System.Windows;
using System.Linq;

namespace VNDorm.ViewModel.Account
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class AccountListViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the AccountListViewModel class.
        /// </summary>
        public AccountListViewModel()
        {
            loadRoleCombo();
        }
        #region property
        /// <summary>
        /// The <see cref="ListAccount" /> property's name.
        /// </summary>
        public const string ListAccountPropertyName = "ListAccount";

        private AccountCollection _ListAccount;

        /// <summary>
        /// Sets and gets the ListAccount property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public AccountCollection ListAccount
        {
            get
            {
                return _ListAccount;
            }

            set
            {
                if ( _ListAccount == value )
                {
                    return;
                }

                RaisePropertyChanging( ListAccountPropertyName );
                _ListAccount = value;
                RaisePropertyChanged( ListAccountPropertyName );
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
        #endregion
        
        #region command

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

        #region method

        public void FindAccount()
        {
            if ( CurrentRole != null )
            {
                this.ListAccount = new AccountCollection(CurrentRole.RoleID);
            }
        }
        public void loadRoleCombo()
        {
            this.RoleList = RoleCollection.Current;
            this.CurrentRole = this.RoleList.FirstOrDefault();
        }
        #endregion
    }
}