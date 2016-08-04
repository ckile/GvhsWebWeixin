using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gvhs.Web.Weixin.Infrastructures
{
    /// <summary>
    /// 微信Auth请求结果
    /// https://api.weixin.qq.com/sns/oauth2/refresh_token?appid=APPID&grant_type=refresh_token&refresh_token=REFRESH_TOKEN 
    /// </summary>
    public class AuthResult : OperResult
    {
        public string access_token { get; set; }

        public int expires_in { get; set; }

        public string openid { get; set; }

        public string refresh_token { get; set; }

        public string scope { get; set; }
    }
}
