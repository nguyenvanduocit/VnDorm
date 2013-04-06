using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enrollment_DSS.Data.Entities;
using Enrollment_DSS.Data.Concretes;

namespace VNDorm.Collections
{
    public class AccountCollection : ObservableCollection<Account>
    {
        public AccountCollection()
        {
            IEnumerable<Account> list = new AccountRepository().Select();
            foreach ( Account item in list )
            {
                this.Add(item);
            }
        }
        public AccountCollection( int roleID)
        {
            IEnumerable<Account> list = new AccountRepository().GetAccountByRoleID( roleID );
            foreach ( Account item in list )
            {
                this.Add( item );
            }
        }
    }
}
