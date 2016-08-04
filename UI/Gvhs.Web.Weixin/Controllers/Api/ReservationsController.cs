using Gvhs.Web.DataContracts;
using Gvhs.Web.Infrastructures.Controllers;
using Gvhs.Web.Pms.DataContracts;
using Gvhs.Web.ServiceContracts;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Gvhs.Web.Weixin.Controllers.Api
{
    [Route("Weixin/api/[controller]")]
    public class ReservationsController : AuthorControllerBase
    {
        private readonly IPmsService _pmsService;

        public ReservationsController(IBllServiceProvider serviceProvider, IPmsService pmsService) : base(serviceProvider)
        {
            _pmsService = pmsService;
        }

        [HttpPost]
        public IActionResult Post([FromBody] EReservation entity)
        {
            var context = ServiceProvider.DbContext;
            context.Set<EReservation>().Add(entity);
            context.SaveChanges();

            var result = _pmsService.CreateReservation(Mapping(entity));
            
            return Ok(new EOperatorResult() { Data = result.data});
        }

        private Reservation Mapping(EReservation erv)
        {
            return new Reservation
            {
                accounts = new List<Account>
                {
                    new Account {
                        accountStatus = erv.Status.ToString(),
                        //accountCode = "1598",
                        adult = erv.Adult,
                        numberOfRooms = 1,
                        arrival = erv.Arrival,
                        departure = erv.Departure,
                        guest = new Guest()
                        {
                            guestCode = erv.Guest.Id.ToString(),
                            title = "",
                            fullName = erv.Guest.WeixinNickname,
                            sex=erv.Guest.WeixinSex,
                            country="CN",
                            phone=erv.Guest.Mobile,
                            email="",
                            birthday=DateTime.Parse("1991-09-10")
                        },
                        roomType = new RoomType()
                        {
                            roomTypeCode = erv.RoomType.Code
                        },
                        rate = new Rate()
                        {
                            rateCode = "SK",
                            amount = erv.Rate
                        }
                    }
                }
            };
        }
    }
}
