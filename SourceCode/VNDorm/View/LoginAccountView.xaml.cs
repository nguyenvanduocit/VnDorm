using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VNDorm.Services.Child;
using Microsoft.Practices.Unity;
using VNDorm.Infrastructures;
using System.ComponentModel;

namespace VNDorm.View
{
    /// <summary>
    /// Interaction logic for LoginAccountView.xaml
    /// </summary>
    public partial class LoginAccountView : Window, ILoginAccountChild
    {
        private readonly IUnityContainer _container;
        public LoginAccountView()
        {
            _container = UnityContainerResolver.Container;
            InitializeComponent();
        }

        #region ILoginAccountChild Members
        public void SetOwner( object window )
        {
            throw new NotImplementedException();
        }

        public void SetModel( object model )
        {
            DataContext = model;
        }

        #endregion
    }
}
