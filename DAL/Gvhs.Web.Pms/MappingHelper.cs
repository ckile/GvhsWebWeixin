using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gvhs.Web.DataContracts;
using Gvhs.Web.Pms.DataContracts;

namespace Gvhs.Web.Pms
{
    /// <summary>
    /// 将微信实体 映射为 pms 实体
    /// </summary>
    public class MappingHelper
    {
        public static Guest GuestMapping(EGuest entity)
        {

            return new Guest
            {
                fullName = entity.Name,
                sex = entity.WeixinSex == "1" ? "男" : (entity.WeixinSex == "2" ? "女" : ""),
            };
        }
    }
}
