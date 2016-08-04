using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gvhs.Web.DataContracts
{
    public class EOperatorResult
    {
        public bool Flag { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }
}
