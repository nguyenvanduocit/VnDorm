using GalaSoft.MvvmLight;

namespace VNDorm.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class StatusViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the StatusViewModel class.
        /// </summary>
        public StatusViewModel()
        {
            //this.statusText = "Ready...";
            this.statusText = Enrollment_DSS.Data.Entities.AccountModelData.UserName;
        }
        /// <summary>
        /// The <see cref="statusText" /> property's name.
        /// </summary>
        public const string statusTextPropertyName = "statusText";

        private string _statusText;

        /// <summary>
        /// Sets and gets the statusText property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string statusText
        {
            get
            {
                return _statusText;
            }

            set
            {
                if ( _statusText == value )
                {
                    return;
                }

                RaisePropertyChanging( statusTextPropertyName );
                _statusText = value;
                RaisePropertyChanged( statusTextPropertyName );
            }
        }
    }
}