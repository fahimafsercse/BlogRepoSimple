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
  
    public interface ISocilaBlogservice
    {
        //Blog
        Task<ResponseModel> SubmitPost(PostDetailViewModel post);
        Task<ResponseModel> SubmitComment(CommentDetailViewModel cmnt);
        Task<ResponseModel> GetCommentsByPost(long id);
        Task<ResponseModel> ToggleVote(CommentDetailViewModel cmnt);
        Task<ResponseModel> GetAllPost();
        Task<ResponseModel> GetAllComment();

    }
}
