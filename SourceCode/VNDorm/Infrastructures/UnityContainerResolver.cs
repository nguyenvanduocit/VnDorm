using Microsoft.Practices.Unity;
using VNDorm.Services;
//using VNDorm.Services.Parent;
using VNDorm.Services.Child;
using VNDorm.View;
using VNDorm.ViewModel;
using GalaSoft.MvvmLight;

namespace VNDorm.Infrastructures
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class UnityContainerResolver : ViewModelBase
    {
        private static IUnityContainer _container;

        public UnityContainerResolver()
        {
        }
        public static IUnityContainer Container
        {
            get
            {
                if ( _container == null )
                {
                    _container = new UnityContainer();
                    RegisterTypes();
                }
                return _container;
            }
        }
        static void RegisterTypes()
        {
            _container.RegisterType<ILoginAccountChild, LoginAccountView>();
            _container.RegisterType<IAboutChild, AbountView>();
        }
    }
}