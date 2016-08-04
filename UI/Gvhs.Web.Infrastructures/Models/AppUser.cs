using System.Security.Principal;

namespace Gvhs.Web.Infrastructures.Models
{
    public class AppUser : IIdentity
    {
        public AppUser(string type, string name)
        {
            _authenticationType = type;
            _name = name;
        }

        /// <summary>
        /// 验证类型
        /// </summary>
        private string _authenticationType;
        public string AuthenticationType
        {
            get
            {
                return _authenticationType;
            }
        }
        /// <summary>
        /// 是否成功验证
        /// </summary>
        public bool IsAuthenticated
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
        }
    }
}
