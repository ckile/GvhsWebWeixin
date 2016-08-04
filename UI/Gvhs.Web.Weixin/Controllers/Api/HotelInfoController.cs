using System;
using System.Linq;
using Gvhs.Web.DataContracts;
using Gvhs.Web.Infrastructures.Controllers;
using Gvhs.Web.ServiceContracts;
using Gvhs.Web.Weixin.ViewModels;
using Microsoft.AspNet.Mvc;

namespace Gvhs.Web.Weixin.Controllers.Api
{
    /// <summary>
    /// 获取酒店信息
    /// </summary>
    [Route("Weixin/api/[controller]")]
    public class HotelInfoController : AuthorControllerBase
    {
        public HotelInfoController(IBllServiceProvider serviceProvider): base(serviceProvider) { }

        [HttpGet]
        public IActionResult Get()
        {
           var configs = ServiceProvider.DbContext.Set<WeixinConfig>().ToDictionary(t =>t.Code, t=> t.Value);
            var result = new HotelInfoViewModel
            {
                //appId = configs.FirstOrDefault(t => t.Key.Equals("appid")).Value,
                //secrit = configs.FirstOrDefault(t => t.Key.Equals("secrit")).Value,
                hotelName = configs.FirstOrDefault(t => t.Key.Equals("hotelname")).Value,
                hotelDate = DateTime.Today
            };
            return Ok(result);
        }

    }
}
