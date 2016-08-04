using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gvhs.Web.Weixin.Infrastructures
{
   public class EntryParamter
    {
        public string signature { get; set; }
        public string echostr { get; set; }
        public string timestamp { get; set; }
        public string nonce { get; set; }
    }
}
