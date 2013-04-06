using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Enrollment_DSS.Data.Entities;
using VNDorm.Collections;

namespace VNDorm.ViewModel.Account
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class AccountMainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the AccountMainViewModel class.
        /// </summary>
        public AccountMainViewModel()
        {
            this.AccountListVM = new AccountListViewModel();
            this.AddAccountVM = new AddAccountViewModel();
            this.Content = this.AccountListVM;
            //Get curent role list
            this.RoleList = RoleCollection.Current;
        }

        # region field
        private RelayCommand saveListAccount;
        private RelayCommand refreshListAccount;
        # endregion

        #region property
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
        #endregion

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

        #region accountlistviewmodel
        /// <summary>
        /// The <see cref="AccountListVM" /> property's name.
        /// </summary>
        public const string AccountListVMPropertyName = "AccountListVM";

        private AccountListViewModel _AccountListVM;

        /// <summary>
        /// Sets and gets the AccountListVM property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public AccountListViewModel AccountListVM
        {
            get
            {
                return _AccountListVM;
            }

            set
            {
                if ( _AccountListVM == value )
                {
                    return;
                }

                RaisePropertyChanging( AccountListVMPropertyName );
                _AccountListVM = value;
                RaisePropertyChanged( AccountListVMPropertyName );
            }
        }

        public ICommand AccountListVMCommand
        {
            get
            {
                return new RelayCommand( () => changeContent( AccountListVMPropertyName ) );
            }
        }

        #endregion

        #region addAccount
        /// <summary>
        /// The <see cref="AddAccountVM" /> property's name.
        /// </summary>
        public const string AddAccountVMPropertyName = "AddAccountVM";

        private AddAccountViewModel _AddAccountVM = null;

        /// <summary>
        /// Sets and gets the AddAccountVM property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public AddAccountViewModel AddAccountVM
        {
            get
            {
                return _AddAccountVM;
            }

            set
            {
                if ( _AddAccountVM == value )
                {
                    return;
                }

                RaisePropertyChanging( AddAccountVMPropertyName );
                _AddAccountVM = value;
                RaisePropertyChanged( AddAccountVMPropertyName );
            }
        }

        public ICommand AddAccountVMCommand
        {
            get
            {
                return new RelayCommand( () => changeContent( AddAccountVMPropertyName ) );
            }
        }

        #endregion


        public void changeContent( string vm )
        {
            switch ( vm )
            {
                case AccountListVMPropertyName:
                    Content = AccountListVM;
                    break;
                case AddAccountVMPropertyName:
                    Content = AddAccountVM;
                    break;
            }
        }
    }
}