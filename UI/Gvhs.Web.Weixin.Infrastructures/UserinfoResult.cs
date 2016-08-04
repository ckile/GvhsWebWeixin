using System.Collections.Generic;

namespace Gvhs.Web.Weixin.Infrastructures
{
    /// <summary>
    /// 微信用户信息
    /// https://api.weixin.qq.com/sns/userinfo?access_token=ACCESS_TOKEN&openid=OPENID&lang=zh_CN 
    /// </summary>
    public class UserinfoResult : OperResult
    {
        public int? subscribe { get; set; }

        public string openid { get; set; }

        public string nickname { get; set; }

        public string sex { get; set; }

        public string language { get; set; }

        public string province { get; set; }

        public string city { get; set; }

        public string country { get; set; }

        public string headimgurl { get; set; }

        public string subscribe_time { get; set; }

        public string remark { get; set; }

        public List<string> privilege { get; set; }

        public string unionid { get; set; }

    }
}
