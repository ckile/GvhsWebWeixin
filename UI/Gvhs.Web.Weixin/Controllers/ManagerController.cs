using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gvhs.Web.Infrastructures.Controllers;
using Gvhs.Web.ServiceContracts;
using Microsoft.AspNet.Mvc;
using Gvhs.Web.Pms.DataContracts;
using Gvhs.Web.Weixin.ViewModels;

namespace Gvhs.Web.Weixin.Controllers
{
    [Route("Weixin/[controller]/[action]")]
    public class ManagerController : AuthorControllerBase
    {
        private readonly IPmsService _pmsService;
        public ManagerController(IBllServiceProvider serviceProvider, IPmsService pmsService) : base(serviceProvider)
        {
            _pmsService = pmsService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RoomView()
        {
            return View();
        }

        public IActionResult RealtimeStatistic()
        {
            return View();
        }

        public IActionResult OperationAnalysis()
        {
            return View();
        }

        public IActionResult RoomViewChild()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetData()
        {
            var result = _pmsService.GetData();
            if (result == null) return null;
            return Ok(new { occRate = result.OccupancyRate, avgRate = result.AverageRoomRate, reve = result.ExpectedRevenue });
        }

        [HttpGet]
        public IActionResult GetRoomViews()
        {
            var result = _pmsService.GetRoomViews();
            if (result == null) return null;
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetRealtimeStatistic()
        {
            var result = _pmsService.GetRealtimeStatistic();
            if (result == null) return null;
            return Ok(new { totalRoom = result.TotalRoom, closeRoom = result.CloseRoom, repairRoom = result.RepairRoom, rentRoom = result.RentRoom, expectArrive = result.ExpectArrive, actualArrive = result.ActualArrive, expectDeparture = result.ExpectDeparture, actualDeparture = result.ActualDeparture, walkin = result.Walkin, team = result.Team, personal = result.Personal, free = result.Free, meeting = result.Meeting, longTerm = result.LongTerm });
        }

        [HttpPost]
        public IActionResult GetRoomViewByRmNum([FromBody] string rmNum)
        {
            var result = _pmsService.GetRoomViewByRmNum(rmNum);
            if (result == null) return null;
            return Ok(new { Name = result.Name, RmType = result.RmType, Rate = result.Rate});
        }
    }
}
