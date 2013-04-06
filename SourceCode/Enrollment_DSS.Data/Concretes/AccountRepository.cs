using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enrollment_DSS.Data.Abstracts;
using Enrollment_DSS.Data.Entities;
using Enrollment_DSS.Data.Infrastructures;

namespace Enrollment_DSS.Data.Concretes
{
    public class AccountRepository : SqlPrototype<Account>
    {

        #region filed
        private static AccountRepository accountRepository;
        private LogRepository log = new LogRepository();
        #endregion
        public static AccountRepository getAccountRepository()
        {
            if ( accountRepository == null )
                accountRepository = new AccountRepository();
            return accountRepository;
        }
        #region SqlPrototype<Account> Members
        public IQueryable<Account> Select()
        {
            var result = from m in EnrollmentDSSStatic.GetEntities().Accounts
                         select m;
            return result;
        }
        public void Save( Account entity )
        {
            throw new NotImplementedException();
        }

        public void Delete( Account entity )
        {
            EnrollmentDSSStatic.GetEntities().AttachTo( EnrollmentDSSStatic.GetEntities().CreateObjectSet<Account>().EntitySet.Name, entity );
            EnrollmentDSSStatic.GetEntities().ObjectStateManager.GetObjectStateEntry( entity ).SetModified();
            EnrollmentDSSStatic.GetEntities().Accounts.DeleteObject( entity );
            EnrollmentDSSStatic.GetEntities().SaveChanges();
            log.GhiNhanThongTinThaoTac( "Delete account " + entity.UserName, 2 );
        }
        #endregion

        public static AccountRepository GetAccountRepository()
        {
            if ( accountRepository == null )
                accountRepository = new AccountRepository();
            return accountRepository;
            ;
        }

        public Account GetAccountByUserNamePass( string _userName, string _pass )
        {
            return ( from m in EnrollmentDSSStatic.GetEntities().Accounts
                     where m.UserName.Equals( _userName ) && m.Password.Equals( _pass )
                     select m ).FirstOrDefault();
        }

        public Account GetAccountByUserName( string _userName )
        {
            return ( from m in EnrollmentDSSStatic.GetEntities().Accounts
                     where m.UserName.Equals( _userName )
                     select m ).FirstOrDefault();
        }

        public IQueryable<Account> GetAccountByRoleID( int id )
        {
            return ( from m in EnrollmentDSSStatic.GetEntities().Accounts
                     where m.RoleID == id
                     select m );
        }

        public bool CheckExist( string UserName )
        {
            var result = ( from m in EnrollmentDSSStatic.GetEntities().Accounts
                           where m.UserName.Equals( UserName )
                           select m ).Count();
            if ( result > 0 )
                return true;
            return false;
        }

        public int UpdateAccount(string username, string password ,int roleID)
        {
            var kq = ( from m in EnrollmentDSSStatic.GetEntities().Accounts
                       where m.UserName.Equals( username )
                       select m ).FirstOrDefault();
            if ( kq != null )
            {
                kq.Password = password;
                kq.RoleID = roleID;
                EnrollmentDSSStatic.GetEntities().SaveChanges();
                log.GhiNhanThongTinThaoTac( "Update account " + kq.UserName, 2 );
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public Account AddAccount( string UserName, string pass, int roleID)
        {
                var kq = new Account();
                kq.UserName = UserName;
                kq.Password = pass;
                kq.RoleID = roleID;
                EnrollmentDSSStatic.GetEntities().AddToAccounts( kq );
                EnrollmentDSSStatic.GetEntities().SaveChanges();
                EnrollmentDSSStatic.GetEntities().Detach( kq );
                log.GhiNhanThongTinThaoTac( "Add account " + kq.UserName, 2 );
                return kq;
        }
    }
}
