using Api.DependencyInjection;
using BL;
using Interface.IRepo;
using Interface.IService;
using Interface.IUnityOfWork;
using Repository;
using Repository.UnityOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Unity;

namespace Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var container = new UnityContainer();
            container.RegisterType(typeof(ISocilaBlogservice), typeof(SocialBlogService));
            container.RegisterType(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            container.RegisterType<IUserRepo, UserRepoAsync>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IAdminUserRepo, AdminUserRepo>();
            container.RegisterType<IUnityOfWork, UnityOfWork>();
            config.DependencyResolver = new UnityResolver(container);

            var cors = new EnableCorsAttribute("*", "*", "*");

            config.EnableCors(cors);
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
