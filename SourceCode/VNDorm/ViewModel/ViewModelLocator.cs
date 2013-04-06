/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:VNDorm.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using VNDorm.Model;
using VNDorm.ViewModel;
using VNDorm.ViewModel.Student;
using VNDorm.ViewModel.Account;
namespace VNDorm.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider( () => SimpleIoc.Default );

            if ( ViewModelBase.IsInDesignModeStatic )
            {
                //SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
            }
            else
            {
                //SimpleIoc.Default.Register<IDataService, DataService>();
                //SimpleIoc.Default.Register<MainViewModel>();
            }
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<StudentMainViewModel>();
            SimpleIoc.Default.Register<AccountMainViewModel>();
            SimpleIoc.Default.Register<StatusViewModel>();
            SimpleIoc.Default.Register<LogViewModel>();
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes." )]
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        #region Student managerment
        public StudentMainViewModel StudentMain
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StudentMainViewModel>();
            }
        }
        #endregion

        #region Account managerment
        public AccountMainViewModel AccountMain
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AccountMainViewModel>();
            }
        }
        #endregion

        #region status
        /// <summary>
        /// Gets the StatusVM property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes." )]
        public StatusViewModel StatusVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<StatusViewModel>();
            }
        }

        #endregion
        #region Log
        /// <summary>
        /// Gets the StatusVM property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage( "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes." )]
        public LogViewModel LogVM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LogViewModel>();
            }
        }

        #endregion
        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }
    }
}