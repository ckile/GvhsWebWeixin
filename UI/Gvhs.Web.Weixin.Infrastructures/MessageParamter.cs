using System.Xml.Serialization;

using System.Xml;
namespace Gvhs.Web.Weixin.Infrastructures
{
    [XmlRoot("xml")]
    public class MessageParamter
    {
        [XmlElement]
        public string ToUserName { get; set; }
        [XmlElement]
        public string FromUserName { get; set; }
        [XmlElement]
        public string CreateTime { get; set; }
        [XmlElement]
        public string MsgType { get; set; }
        [XmlElement]
        public string Content { get; set; }
        [XmlElement]
        public long MsgId { get; set; }
        [XmlElement]
        public string PicUrl { get; set; }
        [XmlElement]
        public string MediaId { get; set; }
        [XmlElement]
        public string Format { get; set; }
        [XmlElement]
        public string ThumbMediaId { get; set; }
        [XmlElement]
        public string Location_X { get; set; }
        [XmlElement]
        public string Location_Y { get; set; }
        [XmlElement]
        public string Scale { get; set; }
        [XmlElement]
        public string Label { get; set; }
        [XmlElement]
        public string Title { get; set; }
        [XmlElement]
        public string Url { get; set; }
        [XmlElement]
        public string Description { get; set; }

    }

    public static class MessageTypes
    {
        public const string text = "text";

        public const string image = "image";

        public const string voice = "voice";

        public const string video = "video";

        public const string shortvideo = "shortvideo";

        public const string location = "location";

        public const string link = "link";
    }

}
