using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enrollment_DSS.Data.Abstracts;
using Enrollment_DSS.Data.Entities;
using Enrollment_DSS.Data.Infrastructures;

namespace Enrollment_DSS.Data.Concretes
{
    public class LogRepository
    {

        public IQueryable<Log> Select()
        {
            return ( from m in EnrollmentDSSStatic.GetEntities().Logs
                     select m );
        }

        public IQueryable<Log> Select(string phanhe)
        {
            return ( from m in EnrollmentDSSStatic.GetEntities().Logs
                     where m.PhanHe.Contains(phanhe)
                     select m );
        }
        public static IQueryable<string> getAllModuleName()
        {
            return ( from o in EnrollmentDSSStatic.GetEntities().Logs orderby o.PhanHe select o.PhanHe ).Distinct();
        }
        public void GhiNhanThongTinThaoTac( string noidungThaoTac, int phanhe )
        {
            var kq = new Log();
            kq.UserName = new AccountRepository().GetAccountByUserName( AccountModelData.UserName ).UserName;
            kq.Time = DateTime.Now;
            kq.NoiDung = noidungThaoTac;

            switch ( phanhe )
            {
                case 1:
                    {
                        kq.PhanHe = "Quản lý sinh viên";
                        break;
                    }
                case 2:
                    {
                        kq.PhanHe = "Quản lý tài khoản";
                        break;
                    }
                case 3:
                    {
                        kq.PhanHe = "Quản lý phòng";
                        break;
                    }
                case 4:
                    {
                        kq.PhanHe = "Quản lý thiết bị";
                        break;
                    }
                case 5:
                    {
                        kq.PhanHe = "Quản lý nhân viên";
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            EnrollmentDSSStatic.GetEntities().AddToLogs( kq );
            EnrollmentDSSStatic.GetEntities().SaveChanges();
        }

        public void GhiNhanThongTinThaoTac( string noidungThaoTac, string phanhe )
        {
            var kq = new Log();
            kq.UserName = new AccountRepository().GetAccountByUserName( AccountModelData.UserName ).UserName;
            kq.Time = DateTime.Now;
            kq.NoiDung = noidungThaoTac;
            kq.PhanHe = phanhe;
            EnrollmentDSSStatic.GetEntities().AddToLogs( kq );
            EnrollmentDSSStatic.GetEntities().SaveChanges();
        }
    }
}
