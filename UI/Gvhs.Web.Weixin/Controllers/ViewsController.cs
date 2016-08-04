using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
 
namespace Gvhs.Web.Weixin.Controllers
{
    public class ViewsController : Controller
    {
        // GET: /<controller>/
        public IActionResult About()
        {
            return View();
        }
    }
}
