using Interface.IRepo;
using Model;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepoAsync : IUserRepo
    {
        private readonly BS23DBContext context;
        public UserRepoAsync(BS23DBContext context)
        {
            this.context = context;
        }

        public async Task<UserInformation> GetUserDetailByAccount(string accountName)
        {
            try
            {
                return await context.UserInformations.AsNoTracking().Where(x => x.AccountName.Equals(accountName) && x.Active == true).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                Print("GetUserDetailByAccount", ex.Message);
                return null;
            }
        }
        public UserInformation GetUserByAccount(string accountName)
        {
            try
            {
                return context.UserInformations.AsNoTracking().Where(x => x.AccountName.Equals(accountName) && x.Active == true).FirstOrDefault();
            }
            catch (Exception ex)
            {

                Print("GetUserDetailByAccount", ex.Message);
                return null;
            }
        }
        public async Task<UserInformation> GetUserDetailByUserIdAsync(long userId)
        {
            try
            {
                return await context.UserInformations.AsNoTracking().Where(x => x.AccountName.Equals(userId) && x.Active == true).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                Print("GetUserDetailByUserIdAsync", ex.Message);
                return null;
            }

        }

        public async Task<List<UserInformation>> SearchUser(string query)
        {
            try
            {
                using (var transaction = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
                {
                    var results = await context.UserInformations.AsNoTracking().Where(x => x.AccountName.Contains(query) || x.DisplayName.Contains(query) || x.Email.Contains(query) || x.Department.Contains(query)).ToListAsync();
                    if (results != null)
                    {
                        if (results.Count > 15)
                        {
                            results = results.Take(15).ToList();
                        }
                    }
                    else if (results == null)
                    {

                    }


                    return results;
                }

            }
            catch (Exception ex)
            {
                Print("SearchUser", ex.Message);
                return null;
            }
        }

        #region Error
        private static void Print(string method
             , string msg)
        {
            ErrorLogs.PrintError("UserRepoAsync"
                , method
                , msg);

        }

        #endregion
    }
}
