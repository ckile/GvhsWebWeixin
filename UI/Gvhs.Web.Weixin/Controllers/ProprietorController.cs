using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gvhs.Web.Infrastructures.Controllers;
using Gvhs.Web.ServiceContracts;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Gvhs.Web.Weixin.Controllers
{
    /// <summary>
    /// 业主控制器
    /// </summary>
    public class ProprietorController : AuthorControllerBase
    {

        public ProprietorController(IBllServiceProvider serviceProvider) : base(serviceProvider) { }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
