using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Gvhs.Web.Weixin.Infrastructures;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using Gvhs.Web.Weixin.Models;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Gvhs.Web.Weixin.Controllers
{
    /// <summary>
    /// 微信回复控制器
    /// 处理微信的所有消息通道
    /// </summary>
    [Route("Weixin/api/Entry")]
    public class WeixinEntryController : Controller
    {
        /// <summary>
        /// 接口测试
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(EntryParamter param)
        {
            var strList = new List<string> { "GVS", param.timestamp, param.nonce };
            strList.Sort();
            if (WeixinHelper.Sha1Encrypt(string.Join("", strList)).Equals(param.signature))
                return Ok(param.echostr);
            return HttpBadRequest();
        }

        /// <summary>
        /// 消息处理
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post()
        {
            var stream = Request.Body;
            if (!stream.CanRead) return HttpBadRequest("Not to Read");
            var reader = new StreamReader(stream);
            var xmlReader = XmlReader.Create(reader);
            var xmlSerializer = new XmlSerializer(typeof(MessageParamter));
            if (!xmlSerializer.CanDeserialize(xmlReader)) return HttpBadRequest("Not to Deserialize");
            var param = xmlSerializer.Deserialize(xmlReader) as MessageParamter;
            var result = ProcessMessage(param);
            return Ok(result);
        }


        private string ProcessMessage(MessageParamter msgParam)
        {
            var result = ResponseTemplates.Text;
            result = string.Format(result, msgParam.FromUserName, msgParam.ToUserName,ProcessMessageHelper.GetCreateTime(), msgParam.Content);
            return result;
        }

    }
}
