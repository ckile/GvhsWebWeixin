using System;

namespace Gvhs.Web.Weixin.Infrastructures
{
    public class AccessTokenResult
    {
        public AccessTokenResult()
        {
            createTime = DateTime.Now;
        }

        public string access_token { get; set; }

        public int expires_in { get; set; }

        public DateTime createTime { get; private set; }
    }
}
