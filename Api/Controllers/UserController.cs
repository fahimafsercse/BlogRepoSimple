using Interface.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Api.Controllers
{
    [RoutePrefix("api/User")]
    [DisableCors]
    public class UserController : ApiController
    {
        private IUserService userService;
        //private IADService aDService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
            //this.aDService = aDService;
        }

        [HttpGet]
        [Route("GetAllUser")]
       // [JwtAuthentication]
        public async Task<IHttpActionResult> GetAllUser()
        {
            return Ok(await userService.GetAllUser());
        }

        [HttpGet]
        [Route("GetUserDetailByAccount")]
        public async Task<IHttpActionResult> GetUserDetailByAccount(string accountName)
        {
            return Ok(await userService.GetUserDetailByAccount(accountName));
        }
        [HttpGet]
        [Route("SearchUserByKey")]
        //[JwtAuthentication]
        public async Task<IHttpActionResult> SearchUserByKey(string key)
        {
            //return Ok(aDService.SearcADUsers(key));
            return Ok(await userService.SearchUsers(key));
        }

        [HttpGet]
        [Route("GetCurrentUser")]
        //[JwtAuthentication]
        public async Task<IHttpActionResult> GetCurrentUser()
        {
            return Ok(await userService.GetCurrentUser());
        }
    }
}
