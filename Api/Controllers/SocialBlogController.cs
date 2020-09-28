using Interface.IService;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Utility.ViewModels;

namespace Api.Controllers
{
    [RoutePrefix("api/Blog")]
    [System.Web.Http.Cors.DisableCors]
    public class SocialBlogController : ApiController
    {
        private ISocilaBlogservice socilaBlogservice;
        public SocialBlogController(ISocilaBlogservice socilaBlogservice)
        {
            this.socilaBlogservice = socilaBlogservice;
        }

        [Route("SavePost")]
        [HttpPost]
        public async Task<IHttpActionResult> SavePost(PostDetailViewModel postDetailView)
        {
            return Ok(await socilaBlogservice.SubmitPost(postDetailView));
        }
        [Route("SaveComment")]
        [HttpPost]
        public async Task<IHttpActionResult> SaveComment(CommentDetailViewModel commentDetailView)
        {
            return Ok(await socilaBlogservice.SubmitComment(commentDetailView));
        }
        [Route("ToggleVote")]
        [HttpPost]
        public async Task<IHttpActionResult> ToggleVote(CommentDetailViewModel commentDetailView)
        {
            return Ok(await socilaBlogservice.ToggleVote(commentDetailView));
        }
        [Route("GetCommentsByPost")]
        [HttpPost]
        public async Task<IHttpActionResult> GetCommentsByPost(long Id)
        {
            return Ok(await socilaBlogservice.GetCommentsByPost(Id));
        }
        [Route("GetAllPost")]
        [HttpPost]
        public async Task<IHttpActionResult> GetAllPost()
        {
            return Ok(await socilaBlogservice.GetAllPost());
        }
        [Route("GetAllComment")]
        [HttpPost]
        public async Task<IHttpActionResult> GetAllComment()
        {
            return Ok(await socilaBlogservice.GetAllComment());
        }
    }
    
}
