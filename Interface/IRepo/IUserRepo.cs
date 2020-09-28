using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.IRepo
{
    public interface IUserRepo
    {
        Task<UserInformation> GetUserDetailByUserIdAsync(long userId);
        Task<UserInformation> GetUserDetailByAccount(string accountName);
        UserInformation GetUserByAccount(string accountName);
        Task<List<UserInformation>> SearchUser(string query);
    }
}
