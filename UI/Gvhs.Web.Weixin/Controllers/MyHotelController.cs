using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Gvhs.Web.Pms.DataContracts;
using Gvhs.Web.ServiceContracts;
using Gvhs.Web.Infrastructures.Controllers;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Gvhs.Web.Weixin.Controllers
{
    public class MyHotelController : AuthorControllerBase
    {
        private readonly IPmsService _pmsService;
        public MyHotelController(IBllServiceProvider serviceProvider, IPmsService pmsService) : base(serviceProvider)
        {
            _pmsService = pmsService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyReservation()
        {
            return View();
        }

        public IActionResult Cancel()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Billing()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetReservationByGuest([FromBody] string guestCode)
        {
            //return Ok(new { resvnum = "123456", name = "刘亦菲", arrive = DateTime.Now.ToString("MM-dd ddd"), dpt = DateTime.Now.ToString("MM-dd ddd"), rmnum = "1402", rate = "995.00" });
            var result = _pmsService.GetReservationByGuest(guestCode);
            if (result == null) return null;
            return Ok(result);
        }

        [HttpPost]
        public IActionResult GetResvByResvNum([FromBody] string resvNum)
        {
            var result = _pmsService.GetResvByResvNum(resvNum);
            if (result == null) return null;
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CancelReservation([FromBody] string resvNum)
        {
            var result = _pmsService.CancelReservation(resvNum);          
            return Ok(new OperatorResult() { data = result.data});
        }
    }
}
