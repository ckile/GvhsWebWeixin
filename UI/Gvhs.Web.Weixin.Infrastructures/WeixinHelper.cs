using System.Security.Cryptography;
using System.Text;

namespace Gvhs.Web.Weixin.Infrastructures
{
    public class WeixinHelper
    {

        public static AuthResult GetAuthResult(AuthParamter paramter)
        {
            var url = "https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code";
            url = string.Format(url, paramter.appid, paramter.secret, paramter.code);
            return WebHelper.GetApi<AuthResult>(url);
        }

        /// <summary>
        /// 获取微信的Access_Token
        /// 两小时内有效
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        public static AccessTokenResult GetAccessToken(AccessTokenParamter param)
        {
            var url = "https://api.weixin.qq.com/cgi-bin/token?grant_type={0}&appid={1}&secret={2}";
            url = string.Format(url, param.grant_type, param.appid, param.secret);
            return WebHelper.GetApi<AccessTokenResult>(url);
        }

        /// <summary>
        /// 创建菜单
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="menu"></param>
        /// <returns></returns>
        public static OperResult CreateMenu(string accessToken, WeixinMenu menu)
        {
            var url = "https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}";
            url = string.Format(url, accessToken);
            return WebHelper.PostApi<OperResult, WeixinMenu>(url, menu);
        }

        /// <summary>
        /// 通过access_token获取微信用户资料
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openId"></param>
        /// <returns></returns>
        public static UserinfoResult GetUserInfo(string accessToken, string openId)
        {
            var url = "https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang=zh_CN ";
            url = string.Format(url, accessToken, openId);
            return WebHelper.GetApi<UserinfoResult>(url);
        }


        public static string Sha1Encrypt(string target)
        {
            var bytes = Encoding.Default.GetBytes(target);
            var hashA1Gorithm = new SHA1CryptoServiceProvider();
            bytes = hashA1Gorithm.ComputeHash(bytes);
            var strBuilder = new StringBuilder();
            foreach (var bit in bytes)
            {
                strBuilder.AppendFormat("{0:x2}", bit);
            }
            return strBuilder.ToString();
        }



    }
}
