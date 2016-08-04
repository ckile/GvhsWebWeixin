using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gvhs.Web.DataContracts;
using Gvhs.Web.Infrastructures.Controllers;
using Gvhs.Web.Pms.DataContracts;
using Gvhs.Web.ServiceContracts;
using Gvhs.Web.Weixin.ViewModels;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Gvhs.Web.Weixin.Controllers
{
    [Route("Weixin/Booking/[action]")]
    public class BookingController : AuthorControllerBase
    {
        private readonly IPmsService _pmsService;
        public BookingController(IBllServiceProvider serviceProvider, IPmsService pmsService) : base(serviceProvider)
        {
            _pmsService = pmsService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RoomTypes([FromBody] BookingParamter param)
        {
            var query = ServiceProvider.DbContext.Set<ERoomType>();
            var result = query.ToList();
            if (result == null || result.Count == 0)
                return HttpNotFound(OperatorResult.Create(ErrorCodes.NotFound));

            var roomtypes = _pmsService.GetRoomTypes(param.arrival, param.departure, "RR");

            if (roomtypes != null)
            {
                foreach (var item in result)
                {
                    Mapping(item, roomtypes);
                }
            }

            return Ok(result);
        }


        private void Mapping(ERoomType ert, List<RoomType> rts)
        {
            foreach (var rt in rts)
            {
                if (rt.roomTypeCode.Equals(ert.LocalCode))
                {
                    ert.Availables = rt.available.Value;
                }
            }
        }
        //验证码
        [HttpGet]
        public IActionResult GetVerifyCode()
        {
            return Ok(new { VerifyCode = "123456" });
        }
    }
}
