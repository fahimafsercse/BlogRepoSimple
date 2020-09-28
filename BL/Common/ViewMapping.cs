using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.ViewModels;

namespace BL.Common
{
    public static class ViewMapping
    {
        #region UserInformation
        public static UserInformationViewModel ConvertToView(this UserInformation userInformation)
        {
            if (userInformation != null)
            {
                UserInformationViewModel userInformationViewModel = new UserInformationViewModel
                {
                    id = userInformation.Id,
                    accountName = userInformation.AccountName,
                    displayName = userInformation.DisplayName,
                    email = userInformation.Email,
                    designation = userInformation.Designation,
                    department = userInformation.Department,
                    active = userInformation.Active.Value

                };
                return userInformationViewModel;
            }
            else
                return null;


        }
        public static List<UserInformationViewModel> ConvertToViews(this List<UserInformation> users)
        {
            List<UserInformationViewModel> userInformationViewModels = new List<UserInformationViewModel>();
            List<UserInformationViewModel> tmpUserInformationViewModels = new List<UserInformationViewModel>();
            UserInformationViewModel userInformationViewModel1 = new UserInformationViewModel();
            foreach(UserInformation x in users)
            {
                userInformationViewModel1 = new UserInformationViewModel
                {
                    id = x.Id,
                    accountName = x.AccountName,
                    displayName = x.DisplayName,
                    email = x.Email,
                    designation = x.Designation,
                    department = x.Department,
                    active = x.Active.Value

                };
                tmpUserInformationViewModels.Add(userInformationViewModel1);
            }
            return tmpUserInformationViewModels;
        }
        #endregion
        #region AdminUser
        //public static AdminUserViewModel ConvertToView(AdminUser adminUser)
        //{
        //    if (adminUser != null)
        //    {
        //        AdminUserViewModel adminUserViewModel = new AdminUserViewModel
        //        {
        //            id = adminUser.Id,
        //            displayName = adminUser.DisplayName,
        //            email = adminUser.Email,
        //            accountName = adminUser.AccountName,
        //            userId = adminUser.UserId ,
        //            active = adminUser.Active,
        //            author = adminUser.Author,
        //            editor = adminUser.Editor,
        //            modified = adminUser.Modified,
        //            created = adminUser.Created,
        //        };
        //        return adminUserViewModel;
        //    }
        //    else
        //        return null;


        //}
        public static AdminUser ConvertToModel(this AdminUserViewModel adminUserViewModel)
        {
            if (adminUserViewModel != null)
            {
                AdminUser adminUser = new AdminUser
                {
                    Id = adminUserViewModel.id,
                    DisplayName = adminUserViewModel.displayName,
                    Email = adminUserViewModel.email,
                    AccountName = adminUserViewModel.accountName,
                    UserId = adminUserViewModel.userId,
                    Active = adminUserViewModel.active,
                    Author = adminUserViewModel.author,
                    Editor = adminUserViewModel.editor,
                    Modified = adminUserViewModel.modified,
                    Created = adminUserViewModel.created,
                };
                return adminUser;
            }
            else
                return null;

        }

        public static AdminUserViewModel ConvertToView(this AdminUser adminUser)
        {
            if (adminUser != null)
            {
                AdminUserViewModel adminUserViewModel = new AdminUserViewModel
                {
                    id = adminUser.Id,
                    displayName = adminUser.DisplayName,
                    email = adminUser.Email,
                    accountName = adminUser.AccountName,
                    userId = adminUser.UserId,
                    active = adminUser.Active,
                    author = adminUser.Author,
                    editor = adminUser.Editor,
                    modified = adminUser.Modified,
                    created = adminUser.Created,
                };
                return adminUserViewModel;
            }
            else
                return null;


        }
        #endregion

        #region PostDetail
        public static PostDetailViewModel ConvertToView(PostDetail post)
        {
            if (post != null)
            {
                PostDetailViewModel postDetailViewModel = new PostDetailViewModel
                {
                    id = post.Id,
                    post = post.Post,
                    active = post.Active,
                    totalComment = post.TotalComment,
                    created = post.Created,
                    modified = post.Modified,
                    author = post.Author,
                    editor = post.Editor,
                };
                return postDetailViewModel;
            }
            else
                return null;
        }
        public static PostDetail ConvertToModel(PostDetailViewModel postDetailViewModel)
        {
            if (postDetailViewModel != null)
            {
                PostDetail post = new PostDetail
                {
                    Id = postDetailViewModel.id,
                    TotalComment = postDetailViewModel.totalComment,
                    Post = postDetailViewModel.post,
                    Created = postDetailViewModel.created,
                    Modified = postDetailViewModel.modified,
                    Author = postDetailViewModel.author,
                    Editor = postDetailViewModel.editor,
                    Active = postDetailViewModel.active,
                    
                };
                return post;
            }
            else
                return null;


        }
        #endregion

        #region CommentDetail
        public static CommentDetailViewModel ConvertToView(CommentDetail comment)
        {
            if (comment != null)
            {
                CommentDetailViewModel postDetailViewModel = new CommentDetailViewModel
                {
                    id = comment.Id,
                    postDetail_Id = comment.PostDetail_Id,
                    comment = comment.Comment,
                    likeCount = comment.LikeCount,
                    dislikeCount = comment.DislikeCount,
                    modified = comment.Modified,
                    author = comment.Author,
                    editor = comment.Editor,
                    active = comment.Active
                };
                return postDetailViewModel;
            }
            else
                return null;
        }
        public static List<CommentDetailViewModel> ConvertToView(List<CommentDetail> comments)
        {
            if (comments != null)
            {
                List<CommentDetailViewModel> tmpComments = new List<CommentDetailViewModel>();
                foreach (var comment in comments)
                {
                    CommentDetailViewModel postDetailViewModel = new CommentDetailViewModel
                    {
                        id = comment.Id,
                        postDetail_Id = comment.PostDetail_Id,
                        comment = comment.Comment,
                        likeCount = comment.LikeCount,
                        dislikeCount = comment.DislikeCount,
                        modified = comment.Modified,
                        author = comment.Author,
                        editor = comment.Editor,
                        active = comment.Active
                    };
                    tmpComments.Add(postDetailViewModel);
                }
                
                return tmpComments;
            }
            else
                return null;
        }
        public static CommentDetail ConvertToModel(CommentDetailViewModel commentDetailView)
        {
            if (commentDetailView != null)
            {
                CommentDetail comment = new CommentDetail
                {
                    Id = commentDetailView.id,
                    PostDetail_Id = commentDetailView.postDetail_Id,
                    Comment = commentDetailView.comment,
                    Created = commentDetailView.created,
                    LikeCount = commentDetailView.likeCount,
                    DislikeCount = commentDetailView.dislikeCount,
                    Modified = commentDetailView.modified,
                    Author = commentDetailView.author,
                    Editor = commentDetailView.editor,
                    Active = commentDetailView.active,

                };
                return comment;
            }
            else
                return null;


        }
        #endregion
    }
}
