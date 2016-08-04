using System;

namespace Gvhs.Web.Weixin.Models
{
    public class ProcessMessageHelper
    {

        public static string GetCreateTime()
        {
            var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            var secs = (int)(DateTime.Now - startTime).TotalSeconds;
            return secs.ToString();
        }

    }
}
