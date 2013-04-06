namespace VNDorm.Model.Account
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public static class AccountModel
    {
        public static string UserName { get; set; }
        public static string Password { get; set; }
        public static int RoleID { get; set; }
    }
}