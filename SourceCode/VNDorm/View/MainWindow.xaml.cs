using System.Windows;
using VNDorm.ViewModel;
using MahApps.Metro.Controls;
using System;

namespace VNDorm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        /// 
        public bool IsClose = false;
        public MainWindow()
        {
            InitializeComponent();
            Closing += ( s, e ) => ViewModelLocator.Cleanup();
            Closed += WindowClosed;
        }
        public void WindowClosed( object sender, EventArgs e )
        {
            App.Current.Shutdown();
            IsClose = true;
        }

        private void ComboBoxItem_Selected_1( object sender, RoutedEventArgs e )
        {

        }
    }
}