using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gvhs.Web.Weixin.Infrastructures
{
    /// <summary>
    /// 微信回掉页面参数结果
    /// 如果用户同意授权，页面将跳转至 redirect_uri/?code=CODE&state=STATE。若用户禁止授权，则重定向后不会带上code参数，仅会带上state参数redirect_uri?state=STATE
    /// </summary>
    public class RedirectUrlParamter
    {
        /// <summary>
        /// code说明 ： code作为换取access_token的票据，每次用户授权带上的code将不一样，code只能使用一次，5分钟未被使用自动过期。 
        /// </summary>
        public string code { get; set; }

        public string state { get; set; }
    }
}
