using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using VNDorm.Infrastructures;
using VNDorm.Services.Child;
using VNDorm.Collections;
using Enrollment_DSS.Data.Concretes;
using Microsoft.Practices.Unity;
using System.IO;
using System.Windows;
using System.Security.AccessControl;
using VNDorm.View;
using VNDorm.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;

namespace VNDorm.ViewModel
{

    public class LoginAccountViewModel : ViewModelBase
    {
        private ILoginAccountChild _tempChild;
        private readonly IUnityContainer _container;

        public LoginAccountViewModel(ILoginAccountChild _accountChild)
        {
            _container = UnityContainerResolver.Container;
            _tempChild = _accountChild;
            loadCboLanguage();
        }

        #region property
        /// <summary>
        /// The <see cref="UserName" /> property's name.
        /// </summary>
        public const string UserNamePropertyName = "UserName";

        private string _UserName;

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
            }
        }
        /// <summary>
        /// The <see cref="Password" /> property's name.
        /// </summary>
        public const string PasswordPropertyName = "Password";

        private string _Password;

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
        #endregion

        #region repos
        private AccountRepository accountRepos = new AccountRepository();
        private RoleRepository roleRepos = new RoleRepository();
        #endregion

        #region command
        private ICommand _LoginCommand;
        public ICommand LoginCommand
        {
            get { return _LoginCommand ?? ( _LoginCommand = new RelayCommand( () => LoginAccount() ) ); }
        }

        private ICommand _ExitCommand;
        public ICommand ExitCommand
        {
            get { return _ExitCommand ?? ( _ExitCommand = new RelayCommand( () => ExitWindow() ) ); }
        }
        #endregion

        #region method
        void ExitWindow()
        {
            //Application app = new Application();
            //app.ShutdownMode = 
            //MainWindowViewModel.Shutdown();
            App.Current.Shutdown();
            //vm.Shutdown();
        }
        void LoginAccount()
        {
            if ( UserName == "" || Password== "" )
            {
                MessageBox.Show( "Nhập đầy đủ tên đăng nhập và mật khẩu", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error );
                return;
            }
            AccountModel.UserName = UserName;
            AccountModel.Password = Password;            
            var account = accountRepos.GetAccountByUserNamePass( UserName, Password );
            if ( account != null )
            {
                Enrollment_DSS.Data.Entities.AccountModelData.UserName = UserName;
                Enrollment_DSS.Data.Entities.AccountModelData.RoleID = account.RoleID.Value;
                AccountModel.RoleID = account.RoleID.Value;
                _tempChild.Close();
            }
            else
            {
                MessageBox.Show( "Sai tên đăng nhập hoặc mật khẩu! Đăng nhập lại!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Asterisk );
            }
        }
        /// <summary>
        /// The <see cref="LanguageList" /> property's name.
        /// </summary>
        public const string LanguageListPropertyName = "LanguageList";

        private ObservableCollection<string> _LanguageList = null;

        /// <summary>
        /// Sets and gets the LanguageList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<string> LanguageList
        {
            get
            {
                return _LanguageList;
            }

            set
            {
                if ( _LanguageList == value )
                {
                    return;
                }

                RaisePropertyChanging( LanguageListPropertyName );
                _LanguageList = value;
                RaisePropertyChanged( LanguageListPropertyName );
            }
        }
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
                System.Configuration.Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration( System.Configuration.ConfigurationUserLevel.None );
                config.AppSettings.Settings["CurrentLanguage"].Value = this.LanguageItem;
                config.Save( System.Configuration.ConfigurationSaveMode.Modified );
                System.Configuration.ConfigurationManager.RefreshSection( "appSettings" );
            }
        }
        public void loadCboLanguage()
        {
            this.LanguageList = new ObservableCollection<string>();
            this.LanguageList.Add("english");
            this.LanguageList.Add( "vietnamese" );
            RaisePropertyChanging( LanguageItemPropertyName );
            this.LanguageItem = System.Configuration.ConfigurationManager.AppSettings["CurrentLanguage"];
        }
        #endregion
    }
}