using Gvhs.Web.DataContracts;
using Gvhs.Web.Infrastructures.Controllers;
using Gvhs.Web.ServiceContracts;
using Microsoft.AspNet.Mvc;
using System.Linq;

namespace Gvhs.Web.Weixin.Controllers.Api
{
    [Route("Weixin/api/[controller]")]
    public class GuestsController : AuthorControllerBase
    {
        public GuestsController(IBllServiceProvider serviceProvider) : base(serviceProvider) { }

        [HttpGet]
        public IActionResult Get()
        {
            var id = GetGuestId();
            // 不要将方法放在linq lamba表达式中
            var result = ServiceProvider.DbContext.Set<EGuest>().FirstOrDefault(t => t.Id == id);
            if (result == null) return HttpNotFound();
            return Ok(result);
        }




    }
}
