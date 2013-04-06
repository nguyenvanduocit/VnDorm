using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using VNDorm.Collections;
using Enrollment_DSS.Data.Entities;
using Enrollment_DSS.Data.Concretes;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using System.Collections.ObjectModel;
using System.Linq;

namespace VNDorm.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class LogViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the LogViewModel class.
        /// </summary>
        public LogViewModel()
        {
            loadCboModuleName();
        }
        /// <summary>
        /// The <see cref="ModuleNameItem" /> property's name.
        /// </summary>
        public const string ModuleNameItemPropertyName = "ModuleNameItem";

        private string _ModuleNameItem = string.Empty;

        /// <summary>
        /// Sets and gets the ModuleNameItem property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string ModuleNameItem
        {
            get
            {
                return _ModuleNameItem;
            }

            set
            {
                if ( _ModuleNameItem == value )
                {
                    return;
                }

                RaisePropertyChanging( ModuleNameItemPropertyName );
                _ModuleNameItem = value;
                RaisePropertyChanged( ModuleNameItemPropertyName );
            }
        }
        /// <summary>
        /// The <see cref="LogList" /> property's name.
        /// </summary>
        public const string LogListPropertyName = "LogList";

        private LogCollection _LogList = null;

        /// <summary>
        /// Sets and gets the LogList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public LogCollection LogList
        {
            get
            {
                return _LogList;
            }

            set
            {
                if ( _LogList == value )
                {
                    return;
                }

                RaisePropertyChanging( LogListPropertyName );
                _LogList = value;
                RaisePropertyChanged( LogListPropertyName );
            }
        }
        /// <summary>
        /// The <see cref="ModuleNameList" /> property's name.
        /// </summary>
        public const string ModuleNameListPropertyName = "ModuleNameList";

        private ObservableCollection<string> _ModuleNameList = null;

        /// <summary>
        /// Sets and gets the ModuleNameList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<string> ModuleNameList
        {
            get
            {
                return _ModuleNameList;
            }

            set
            {
                if ( _ModuleNameList == value )
                {
                    return;
                }

                RaisePropertyChanging( ModuleNameListPropertyName );
                _ModuleNameList = value;
                RaisePropertyChanged( ModuleNameListPropertyName );
            }
        }
        private RelayCommand _LoadLogCommand;

        /// <summary>
        /// Gets the LoadLogCommand.
        /// </summary>
        public RelayCommand LoadLogCommand
        {
            get
            {
                return _LoadLogCommand
                    ?? ( _LoadLogCommand = new RelayCommand(
                                          () =>
                                          {
                                              loadLogMethod();
                                          } ) );
            }
        }
        public void loadLogMethod()
        {
            if ( this.ModuleNameItem != string.Empty )
            {
                this.LogList = new LogCollection( this.ModuleNameItem );
            }
        }
        public void loadCboModuleName()
        {
            this.ModuleNameList = ModuleCollection.getAllModuleName();
        }
    }
}