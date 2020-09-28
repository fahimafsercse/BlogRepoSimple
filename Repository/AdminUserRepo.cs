using Interface.IRepo;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AdminUserRepo : IAdminUserRepo
    {
        private readonly BS23DBContext context;
        public AdminUserRepo(BS23DBContext context)
        {
            this.context = context;
        }

        public AdminUser GetAdminUserByUserId(long userId)
        {
            try
            {
                var adminUser = context.AdminUsers.Where(x => x.UserId == userId && x.Active == true).FirstOrDefault();
                return adminUser;
            }
            catch (Exception ex)
            {
                // Print("GetAdminUserByUserId", ex.Message + " ---- Inner Exception" + Convert.ToString(ex.InnerException));
                return null;
            }
        }
        #region Error

        //private static void Print(string method
        //     , string msg)
        //{
        //    ErrorLogs.PrintError("AdminUserRepo"
        //        , method
        //        , msg);
        //}



        #endregion
    }
}
