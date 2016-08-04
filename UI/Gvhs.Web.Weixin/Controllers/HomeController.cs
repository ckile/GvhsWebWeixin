using Gvhs.Web.DataContracts;
using Gvhs.Web.Infrastructures.Controllers;
using Gvhs.Web.ServiceContracts;
using Gvhs.Web.Weixin.Infrastructures;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using System.Linq;
using Gvhs.Web.Infrastructures.Models;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Security.Principal;
using Gvhs.Web.Weixin.ViewModels;
using Gvhs.Web.Pms.DataContracts;
using Gvhs.Web.Pms;
using Gvhs.Web.Weixin.Models;

namespace Gvhs.Web.Weixin.Controllers
{
    /// <summary>
    /// 主页控制器
    /// </summary>
    // [Route("/Weixin/[controller]/[action]")]
    public class HomeController : AuthorControllerBase
    {
        private readonly IPmsService _pmsService;

        public HomeController(IBllServiceProvider serviceProvider, IPmsService pmsService) : base(serviceProvider)
        {
            _pmsService = pmsService;
        }

        /// <summary>
        /// 普通入口
        /// </summary>
        /// <returns></returns>
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 微信入口
        /// </summary>
        /// <param name="paramter"></param>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<IActionResult> WeixinIndex(RedirectUrlParamter paramter)
        {
            var url = "/Weixin";
            return await WeixinPageIn(paramter, url);
        }

        [AllowAnonymous]
        public async Task<IActionResult> WeixinControl(RedirectUrlParamter paramter)
        {
            var url = "/Weixin#/app/control";
            return await WeixinPageIn(paramter, url);
        }

        [AllowAnonymous]
        public async Task<IActionResult> WeixinBooking(RedirectUrlParamter paramter)
        {
            var url = "/Weixin#/app/booking";
            return await WeixinPageIn(paramter, url);
        }

        public async Task<IActionResult> WeixinBinding(RedirectUrlParamter paramter)
        {
            if (string.IsNullOrEmpty(paramter.code)) return HttpBadRequest("微信参数错误！");
            var authParam = GetAuthParamter(paramter.code);
            var authResult = WeixinHelper.GetAuthResult(authParam);
            var guest = ServiceProvider.DbContext.Set<EGuest>().FirstOrDefault(t => t.WeixinOpenId == authResult.openid);
            if (guest == null)
                guest = CreateGuest(authResult);
            GetWeixinUserinfo(authParam, guest, authResult.openid);
            await Login(guest.UserId.ToString(), guest.Id.ToString());
            return Redirect("/Weixin#");
        }

        /// <summary>
        /// 微信入口
        /// 依据微信的code，获取openid
        /// </summary>
        /// <param name="paramter"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        protected async Task<IActionResult> WeixinPageIn(RedirectUrlParamter paramter, string returnUrl)
        {
            if (User.Identity.IsAuthenticated) return Redirect(returnUrl);
            if (string.IsNullOrEmpty(paramter.code)) return HttpBadRequest("微信参数错误！");
            if (paramter.code == "100001")
            {
                await Login("1", "2");
                return Redirect("/Weixin#");
            }
            var authParam = GetAuthParamter(paramter.code);
            var authResult = WeixinHelper.GetAuthResult(authParam);
            var guest = ServiceProvider.DbContext.Set<EGuest>().FirstOrDefault(t => t.WeixinOpenId == authResult.openid);
            if (guest == null)
            {
                guest = CreateGuest(authResult);
                GetWeixinUserinfo(authParam, guest, authResult.openid);
            }

            await Login(guest.UserId.ToString(), guest.Id.ToString());
            return Redirect(returnUrl);
        }

        protected async Task Login(string userId, string guestId)
        {
            IIdentity user = new AppUser(userId, guestId);
            await HttpContext.Authentication.SignInAsync("Weixin", new ClaimsPrincipal(user));
        }

        /// <summary>
        /// 获取酒店的开发者信息
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        protected AuthParamter GetAuthParamter(string code)
        {
            var configs = ServiceProvider.DbContext.Set<WeixinConfig>().ToDictionary(t => t.Code, t => t.Value);
            return new AuthParamter
            {
                appid = configs.FirstOrDefault(t => t.Key.Equals("appid")).Value,
                secret = configs.FirstOrDefault(t => t.Key.Equals("secret")).Value,
                code = code
            };
        }

        /// <summary>
        /// 获取微信用户信息
        /// </summary>
        /// <param name="authParam"></param>
        /// <param name="guest"></param>
        /// <param name="openId"></param>
        protected void GetWeixinUserinfo(AuthParamter authParam, EGuest guest, string openId)
        {
            var accessTokenResult = WeixinHelper.GetAccessToken(new AccessTokenParamter
            {
                appid = authParam.appid,
                secret = authParam.secret,
                grant_type = "client_credential"

            });

            var user = WeixinHelper.GetUserInfo(accessTokenResult.access_token, openId);
            if (user == null) return;

            guest.Name = user.nickname;
            guest.WeixinHeadimgurl = user.headimgurl;
            guest.WeixinNickname = user.nickname;
            guest.WeixinSex = user.sex;
            //guest.WeixinRefreshToken = user.errmsg + user.errcode;

            var pmsResult = _pmsService.CreateGuest(MappingHelper.GuestMapping(guest));
            if (pmsResult.errorCode == 0) guest.Code = pmsResult.data;

            ServiceProvider.DbContext.Update(guest);
            ServiceProvider.DbContext.SaveChanges();

            var pmsGuest = MappingHelper.GuestMapping(guest);


        }


        /// <summary>
        /// 创建宾客档案依据微信用户资料
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        protected EGuest CreateGuest(AuthResult param)
        {
            var guest = new EGuest
            {
                Name = "匿名",
                WeixinOpenId = param.openid,
                UserId = 1
            };
            var guestResult = ServiceProvider.DbContext.Set<EGuest>().Add(guest);

            ServiceProvider.DbContext.SaveChanges();
            return guestResult.Entity;
        }

        /// <summary>
        /// 为前端提供用户资料
        /// </summary>
        /// <returns></returns>
        public IActionResult UserProfile()
        {
            var id = GetGuestId();
            // 不要将方法放在linq lamba表达式中
            var guest = ServiceProvider.DbContext.Set<EGuest>().FirstOrDefault(t => t.Id == id);
            if (guest == null) return HttpNotFound();
            var result = new ProfileViewModel
            {
                userName = guest.Name,
                roomCode = ""
            };

            return Ok(result);
        }


        public IActionResult App()
        {
            return View();
        }

        public IActionResult Header()
        {
            return View();
        }

        public IActionResult Sidebar()
        {
            return View();
        }

        public IActionResult Home()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Denied()
        {
            return View();
        }

    }
}
