using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNDorm.Services.Child
{
    public interface IAboutChild
    {
        bool? ShowDialog();
        void SetOwner( object window );
        bool? DialogResult { get; set; }
        void SetModel( object model );
        void Close();
    }
}
