using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Threading;
using System.ComponentModel;
using GalaSoft.MvvmLight.Threading;
using VNDorm.ViewModel;
namespace VNDorm
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static App()
        {
            DispatcherHelper.Initialize();
        }

        protected override void OnStartup( StartupEventArgs e )
        {
            base.OnStartup( e );
            SelectCulture( System.Configuration.ConfigurationManager.AppSettings["CurrentLanguage"] );
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler( CurrentDomain_UnhandledException );
        }

        private void setModel( Window window, Object model, bool isShow )
        {
            window.DataContext = model;
            if ( isShow )
                window.Show();
        }

        private void APP_DispatcherUnhandledException( object sender, DispatcherUnhandledExceptionEventArgs e )
        {
            string s = "Value cannot be null.\r\nParameter name: window";
            string s2 = "Collection Error";
            if ( e.Exception.Message == "The underlying provider failed on Open." )
            {
                MessageBox.Show( "Không thể kết nối tới máy chủ dữ liệu. Ứng dụng sẽ bị đóng lại", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error );
                e.Handled = true;
                App.Current.Shutdown();
            }
            else if ( null != e.Exception.InnerException && e.Exception.InnerException.ToString() == "A transport-level error has occurred when receiving results from the server. (provider: TCP Provider, error: 0 - The specified network name is no longer available.)" )
            {
                MessageBox.Show( "Mất kết nối tới máy chủ dữ liệu. Xin kiểm tra lại hệ thống mạng và khởi động lại ứng dụng", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error );
                e.Handled = true;
                //App.Current.Shutdown();
            }
            else if ( e.Exception.Message != s && e.Exception.Message != s2 )
            {
                MessageBox.Show( e.Exception.Message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error );
            }
            e.Handled = true;
        }
        private void CurrentDomain_UnhandledException( object sender, UnhandledExceptionEventArgs e )
        {
            Exception ex = e.ExceptionObject as Exception;
            MessageBox.Show( ex.Message, "Lỗi",
                     MessageBoxButton.OK, MessageBoxImage.Error );
        }
        public static void SelectCulture( string culture )
        {
            // List all our resources      
            List<ResourceDictionary> dictionaryList = new List<ResourceDictionary>();
            foreach ( ResourceDictionary dictionary in Application.Current.Resources.MergedDictionaries )
            {
                dictionaryList.Add( dictionary );
            }
            // We want our specific culture      
            string requestedCulture = string.Format( "Skins/Language/{0}.xaml", culture );
            ResourceDictionary resourceDictionary = dictionaryList.FirstOrDefault( d => d.Source.OriginalString == requestedCulture );
            if ( resourceDictionary == null )
            {
                // If not found, we select our default language        
                //        
                requestedCulture = "english.xaml";
                resourceDictionary = dictionaryList.FirstOrDefault( d => d.Source.OriginalString == requestedCulture );
            }

            // If we have the requested resource, remove it from the list and place at the end.\      
            // Then this language will be our string table to use.      
            if ( resourceDictionary != null )
            {
                Application.Current.Resources.MergedDictionaries.Remove( resourceDictionary );
                Application.Current.Resources.MergedDictionaries.Add( resourceDictionary );
            }
            // Inform the threads of the new culture      
            //Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture( culture );
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo( culture );
        }
    }
}
