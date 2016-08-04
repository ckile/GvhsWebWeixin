using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Gvhs.Web.DataContracts
{
    public class EGuest : IEntity
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [Phone]
        public string Mobile { get; set; }

        /// <summary>
        /// 微信客户Id
        /// </summary>
        [JsonIgnore]
        [StringLength(50)]
        public string WeixinOpenId { get; set; }

        /// <summary>
        /// 微信凭证刷新代码
        /// </summary>
        [JsonIgnore]
        [StringLength(100)]
        public string WeixinRefreshToken { get; set; }

        /// <summary>
        /// 微信凭证时间
        /// </summary>
        [JsonIgnore]
        public DateTime WeixinAccessTokenTime { get; set; }

        /// <summary>
        /// 微信昵称
        /// </summary>
        [StringLength(50)]
        public string WeixinNickname { get; set; }

        /// <summary>
        /// 微信头像
        /// </summary>
        [StringLength(200)]
        public string WeixinHeadimgurl { get; set; }

        /// <summary>
        /// 微信性别 0 未知 1 男 2 女
        /// </summary>
        [StringLength(1)]
        public string WeixinSex { get; set; }

        [JsonIgnore]
        public int UserId { get; set; }

        [JsonIgnore]
        public User User { get; set; }

    }
}
