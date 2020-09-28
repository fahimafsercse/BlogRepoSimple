using BL.Common;
using Helper;
using Interface.IService;
using Interface.IUnityOfWork;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility.ViewModels;
using System.Threading.Tasks;

namespace BL
{
    public class SocialBlogService : ISocilaBlogservice
    {
        private readonly IUnityOfWork unityOfWork;
        public SocialBlogService(IUnityOfWork unityOfWork)
        {
            this.unityOfWork = unityOfWork;
        }

        public async Task<ResponseModel> GetAllComment()
        {
            List<CommentDetail> comments = new List<CommentDetail>();
            List<CommentDetailViewModel> commentViewModels = new List<CommentDetailViewModel>();
            comments =await unityOfWork.genricCommentDetailRepo.GetAll();
            commentViewModels = ViewMapping.ConvertToView(comments);
            return HelperClass.Response(true
                           , GlobalDecleration._savedSuccesfully
                           , commentViewModels
                       );
        }
        public async Task<ResponseModel> GetAllPost()
        {
            try
            {
                List<PostDetail> postDetails = new List<PostDetail>();

                PostDetailViewModel postDetailViewModel = new PostDetailViewModel();
                List<PostDetailViewModel> postDetailViewModels = new List<PostDetailViewModel>();
                List<CommentDetail> comments = new List<CommentDetail>();



                postDetails = await unityOfWork.genricPostDetailRepo.GetAll();
                comments = await unityOfWork.genricCommentDetailRepo.GetAll();
                foreach (var postDetail in postDetails.OrderByDescending(x => x.Id))
                {
                    postDetailViewModel = new PostDetailViewModel();

                    postDetailViewModel = ViewMapping.ConvertToView(postDetail);
                    if (postDetailViewModel != null)
                    {
                        postDetailViewModel.commentDetailViewModels = ViewMapping.ConvertToView( comments.Where(x => x.PostDetail_Id == postDetailViewModel.id).ToList()); 
                    }
                }
                return HelperClass.Response(true
                           , GlobalDecleration._savedSuccesfully
                           , postDetailViewModel
                       );

            }
            catch (Exception ex)
            {
                Print("GetAllRequest", ex.Message);
                return HelperClass.Response(false
                        , GlobalDecleration._internalServerError
                        , null
                );
            }
        }

        public async Task<ResponseModel> GetCommentsByPost(long id)
        {
            List<PostDetail> postDetails = new List<PostDetail>();
            List<CommentDetail> comments = new List<CommentDetail>();
            List<CommentDetailViewModel> commentViewModels = new List<CommentDetailViewModel>();
            comments = await unityOfWork.genricCommentDetailRepo.GetAll();
            comments = comments.Where(x => x.PostDetail_Id == id).ToList();
            return HelperClass.Response(true
                           , GlobalDecleration._savedSuccesfully
                           , comments
                       );
        }
        public async Task<ResponseModel> SubmitComment(CommentDetailViewModel commentView)
        {
            try {
                if (commentView != null)
                {
                    CommentDetail comment = new CommentDetail();
                    if (commentView.id == 0)
                    {
                        comment.PostDetail_Id = commentView.postDetail_Id;
                        comment.Comment = commentView.comment;
                        comment.LikeCount = commentView.likeCount;
                        comment.DislikeCount = commentView.dislikeCount;
                        //comment.Editor = commentView.editor;
                        comment.Editor = 1;
                        comment.Modified = DateTime.Now;
                        comment.Author = 1;
                        comment.Active = true;
                        unityOfWork.genricCommentDetailRepo.Insert(comment);
                    }
                    else
                    {
                        comment = await unityOfWork.genricCommentDetailRepo.Get(commentView.id);
                        if (comment != null)
                        {
                            comment.PostDetail_Id = commentView.postDetail_Id;
                            comment.Comment = commentView.comment;
                            comment.LikeCount = commentView.likeCount;
                            comment.DislikeCount = commentView.dislikeCount;
                            comment.Editor = commentView.editor;
                            comment.Author = commentView.author;
                            comment.Modified = DateTime.Now;
                            comment.Author = commentView.author;
                            comment.Active = commentView.active;
                            unityOfWork.genricCommentDetailRepo.Update(comment);
                        }

                    }
                    await unityOfWork.SaveAsync(); 
                }
                return HelperClass.Response(true
                              , GlobalDecleration._savedSuccesfully
                              , null
                          );
            }
            catch (Exception ex)
            {
                Print("SubmitComment", ex.Message);
                return HelperClass.Response(false
                        , GlobalDecleration._internalServerError
                        , null
                );

            }
            
        }
        public async Task<ResponseModel> SubmitPost(PostDetailViewModel postView)
        {
            try
            {
                if (postView != null)
                {
                    PostDetail postDetail = new PostDetail();
                    if (postView.id == 0)
                    {
                        postDetail.TotalComment = postView.totalComment;
                        postDetail.Post = postView.post;
                       
                        //comment.Editor = commentView.editor;
                        postDetail.Editor = 1;
                        postDetail.Modified = DateTime.Now;
                        postDetail.Author = 1;
                        postDetail.Active = true;
                        unityOfWork.genricPostDetailRepo.Insert(postDetail);
                    }
                    else
                    {
                        postDetail = await unityOfWork.genricPostDetailRepo.Get(postView.id);
                        if (postDetail != null)
                        {
                            postDetail.TotalComment = 0;
                            postDetail.Post = postView.post;
                            postDetail.Editor = postView.editor;
                            postDetail.Author = postView.author;
                            postDetail.Modified = DateTime.Now;
                            postDetail.Author = postView.author;
                            postDetail.Active = postView.active;
                            unityOfWork.genricPostDetailRepo.Update(postDetail);
                        }

                    }
                    await unityOfWork.SaveAsync();
                }
                return HelperClass.Response(true
                              , GlobalDecleration._savedSuccesfully
                              , null
                          );
            }
            catch (Exception ex)
            {
                Print("SubmitComment", ex.Message);
                return HelperClass.Response(false
                        , GlobalDecleration._internalServerError
                        , null
                );

            }

        }
        public Task<ResponseModel> SubmitPost(PostDetail post)
        {
            throw new NotImplementedException();
        }
        public async Task<ResponseModel> ToggleVote(CommentDetailViewModel commentView)
        {
            List<PostDetail> postDetails = new List<PostDetail>();
            CommentDetail comment = new CommentDetail();
            List<CommentDetail> comments = new List<CommentDetail>();
            List<CommentDetailViewModel> commentViewModels = new List<CommentDetailViewModel>();
            comments = await unityOfWork.genricCommentDetailRepo.GetAll();
            comment = comments.Where(x => x.PostDetail_Id == commentView.postDetail_Id).FirstOrDefault();
            if (commentView.isDisLike)
            {
                comment.DislikeCount += 1;
            }
            if (commentView.isLiked)
            {
                comment.LikeCount += 1;
            }
            return HelperClass.Response(true
                           , GlobalDecleration._savedSuccesfully
                           , comments
                       );
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
