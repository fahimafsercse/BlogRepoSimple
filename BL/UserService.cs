using BL.Common;
using Helper;
using Interface.IService;
using Interface.IUnityOfWork;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using Utility.ViewModels;

namespace BL
{
    public class UserService : IUserService
    {
        private readonly IUnityOfWork unityOfWork;
        public UserService(IUnityOfWork unityOfWork)
        {
            this.unityOfWork = unityOfWork;
        }

        public async Task<ResponseModel> GetAllUser()
        {
            try
            {
                var userInformations = await unityOfWork.userInformationGenericRepo.GetAll();
                List<UserInformationViewModel> userInformationViews = userInformations.ConvertToViews();
                return HelperClass.Response(true
                     , GlobalDecleration._savedSuccesfully
                     , userInformationViews
                 );

            }
            catch (Exception ex)
            {
                Print("GetAllUser", ex.Message);
                return HelperClass.Response(false
                          , GlobalDecleration._internalServerError
                          , null
                      );
            }
        }

        public async Task<ResponseModel> GetUserDetailByAccount(string accountName)
        {
            try
            {
                var userInformation = await unityOfWork.userRepository.GetUserDetailByAccount(accountName);
                UserInformationViewModel userInformationView = userInformation.ConvertToView();
                return HelperClass.Response(true
                    , GlobalDecleration._savedSuccesfully
                    , userInformationView
                );
            }
            catch (Exception ex)
            {
                Print("GetUserDetailByAccount", ex.Message);
                return HelperClass.Response(false
                          , GlobalDecleration._internalServerError
                          , null
                      );
            }
        }

        public UserInformationViewModel EnsureUser(string accountName, string displayName, string email, string department, string designation)
        {
            try
            {
                UserInformation userInformation = unityOfWork.userRepository.GetUserByAccount(accountName);
                if (userInformation == null)
                {
                    userInformation = new UserInformation();
                    userInformation.AccountName = accountName;
                    userInformation.DisplayName = displayName;
                    userInformation.Email = email;
                    userInformation.Department = department;
                    userInformation.Designation = designation;
                    userInformation.Active = true;
                    userInformation.Created = DateTime.Now;
                    userInformation.Modified = DateTime.Now;
                    unityOfWork.userInformationGenericRepo.Insert(userInformation);
                }
                else if (userInformation.DisplayName != displayName || userInformation.Email != email || userInformation.Department != department || userInformation.Designation != designation)
                {
                    userInformation.DisplayName = displayName;
                    userInformation.Email = email;
                    userInformation.Designation = designation;
                    userInformation.Department = department;

                    unityOfWork.userInformationGenericRepo.Update(userInformation);
                }
                unityOfWork.Save();
                return userInformation.ConvertToView();

            }
            catch (Exception ex)
            {
                Print("EnsureUser", ex.Message + "Inner Exception -->" + Convert.ToString(ex.InnerException));
                return null;
            }
        }
        public async Task<UserInformationViewModel> GetCurrentUser()
        {


            try
            {
                //var currUser = "np" + "\\" + "fahim";
               var currUser = "np" + "\\" +  WebConfigurationManager.AppSettings.Get("currentUser");
                // var currUser = (string)HttpContext.Current.Session["CurrentAccount"];
                //var userInformation = await unityOfWork.userRepository.GetUserDetailByAccount(currUser.ToString());
                var userInformation = await unityOfWork.userRepository.GetUserDetailByAccount(currUser.ToString());
                UserInformationViewModel userInformationView;
                if (userInformation != null)
                {
                    userInformationView = userInformation.ConvertToView();
                    //return HelperClass.Response(true
                    //, GlobalDecleration._savedSuccesfully
                    //, userInformationView
                    //);
                    return userInformationView;
                }
                else
                    return null;

            }
            catch (Exception ex)
            {
                Print("GetCurrentUser", ex.Message);
                //return HelperClass.Response(false
                //          , GlobalDecleration._internalServerError
                //          , null
                //      );
                return null;
            }
        }
        public UserInformation GetCurrentUserModel()
        {
            var currUser = (string)HttpContext.Current.Session["CurrentAccount"];
            //var currUser = "rijwan@techoneglobal.com";
            try
            {
                UserInformation userInformation = unityOfWork.userRepository.GetUserDetailByAccount(currUser.ToString()).Result;
                return userInformation;
            }
            catch (Exception ex)
            {
                Print("GetCurrentUser", ex.Message);
                return null;
            }
        }
        public async Task<List<UserInformationViewModel>> SearchUsers(string query)
        {
            try
            {
                var users = await unityOfWork.userRepository.SearchUser(query);
                if (users != null)
                    return users.ConvertToViews();
                else
                    return null;
            }
            catch (Exception ex)
            {
                Print("SearchUsers", ex.Message + "   Inner Exception -->" + Convert.ToString(ex.InnerException));
                throw;
            }
        }


        public AdminUserViewModel CheckAdminUser(string accountName)
        {
            try
            {
                var user = unityOfWork.userRepository.GetUserByAccount(accountName);
                var adminUser = unityOfWork.adminUserRepository.GetAdminUserByUserId(user.Id).ConvertToView();
                return adminUser;
            }
            catch (Exception ex)
            {
                Print("CheckAdminUser", ex.Message + "  Innerexception-->" + Convert.ToString(ex.InnerException));
                return null;
            }
        }

        #region Error

        private static void Print(string method
             , string msg)
        {
            ErrorLogs.PrintError("UserServices"
                , method
                , msg);
        }



        #endregion
    }
}
