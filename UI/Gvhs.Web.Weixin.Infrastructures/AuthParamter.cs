namespace Gvhs.Web.Weixin.Infrastructures
{

    /// <summary>
    /// 微信通过AuthParamter获取用户信息
    /// https://api.weixin.qq.com/sns/oauth2/access_token?appid=APPID&secret=SECRET&code=CODE&grant_type=authorization_code
    /// </summary>

    public class AuthParamter
    {
        public string appid { get; set; }

        public string secret { get; set; }

        public string code { get; set; }

        public string grant_type { get; set; }
    }
}
