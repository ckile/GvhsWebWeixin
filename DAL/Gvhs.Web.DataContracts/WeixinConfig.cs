using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gvhs.Web.DataContracts
{
    public class WeixinConfig : IEntity
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Code { get; set; }

        [StringLength(50)]
        public string Description { get; set; }


        public string Value { get; set; }

    }
}
