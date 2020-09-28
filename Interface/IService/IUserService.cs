using Helper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.ViewModels;

namespace Interface.IService
{
    public interface IUserService
    {
        Task<ResponseModel> GetAllUser();
        Task<ResponseModel> GetUserDetailByAccount(string accountName);
        UserInformationViewModel EnsureUser(string accountName, string displayName, string email, string department, string designation);
        UserInformation GetCurrentUserModel();
        Task<UserInformationViewModel> GetCurrentUser();
        Task<List<UserInformationViewModel>> SearchUsers(string query);

        AdminUserViewModel CheckAdminUser(string accountName);
    }
}
