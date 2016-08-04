using System;
using Gvhs.Web.ServiceContracts;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace Gvhs.Web.Infrastructures.Controllers
{
    [Authorize]
    public class AuthorControllerBase : Controller
    {
        /// <summary>
        /// BLL服务提供者
        /// 需使用具备服务功能的构造方法
        /// </summary>
        public IBllServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        /// 具备服务功能
        /// </summary>
        /// <param name="serviceProvider"></param>
        public AuthorControllerBase(IBllServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

         protected int GetGuestId()
        {
            var result = Convert.ToInt16(User.Identity.Name);
            return result;
        }

        protected int GetUserId()
        {
            return Convert.ToInt16(User.Identity.AuthenticationType);
        }

    }
}
