using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Gvhs.Web.DataContracts
{
    /// <summary>
    /// 微信房型
    /// </summary>
    public class ERoomType : IEntity
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string Code { get; set; }

        [StringLength(100)]
        public string Description { get; set; }

        public string Remark { get; set; }

        public string ImgUrl { get; set; }

        public decimal Rate { get; set; }

        public int Availables { get; set; }
        
        /// <summary>
        /// 酒店实际房型
        /// </summary>
        [JsonIgnore]
        [StringLength(20)]
        public string LocalCode { get; set; }
        
        /// <summary>
        /// 禁用标志
        /// </summary>
        public bool Unavailable { get; set; }
    }
}
