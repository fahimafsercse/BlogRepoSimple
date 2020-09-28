using Interface.IRepo;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface.IUnityOfWork
{
    public interface IUnityOfWork
    {
        IGenericRepo<CommentDetail> genricCommentDetailRepo { get; }
        IGenericRepo<PostDetail> genricPostDetailRepo { get; }
        IGenericRepo<UserInformation> userInformationGenericRepo { get; }
        IUserRepo userRepository { get; }
        IAdminUserRepo adminUserRepository { get; }
        Task<int> SaveAsync();
        int Save();
    }
}
