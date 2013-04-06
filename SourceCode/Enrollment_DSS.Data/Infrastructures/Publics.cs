using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;


namespace Enrollment_DSS.Data.Infrastructures
{
    public class Publics
    {
        public static string Connection
        {
            get
            {
                //return @"Data Source=221.132.37.64\sqlexpress;Initial Catalog=TDT_EduProject;Persist Security Info=True;User ID=sa;Password=@TDT2@123#@;MultipleActiveResultSets=True";
                return ConfigurationManager.ConnectionStrings["connectSQL"].ConnectionString;
            }
        }

    }
}
