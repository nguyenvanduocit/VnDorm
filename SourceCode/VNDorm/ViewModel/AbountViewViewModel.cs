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

namespace VNDorm.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class AbountViewViewModel : ViewModelBase
    {
        private IAboutChild _tempChild;
        private readonly IUnityContainer _container;
        public AbountViewViewModel( IAboutChild _accountChild )
        {
            _container = UnityContainerResolver.Container;
            _tempChild = _accountChild;
        }
    }
}