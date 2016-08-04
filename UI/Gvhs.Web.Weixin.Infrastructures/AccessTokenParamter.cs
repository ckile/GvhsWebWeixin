using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gvhs.Web.Weixin.Infrastructures
{
   public class AccessTokenParamter
    {
        public string grant_type { get; set; }

        public string appid { get; set; }

        public string secret { get; set; }
    }
}
