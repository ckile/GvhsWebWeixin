namespace Gvhs.Web.Weixin.Models
{
    public static class ResponseTemplates
    {
        /// <summary>
        /// 文本反馈格式{0}接收人{1}发送人{2}时间秒{3}内容
        /// </summary>
        public const string Text =
            "<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>{2}</CreateTime><MsgType><![CDATA[text]]></MsgType><Content><![CDATA[{3}]]></Content></xml>";

        /// <summary>
        /// 新闻行项目格式{0}标题{1}描述{2}图片{3}链接
        /// </summary>
        public const string ArticleItem =
            "<item><Title><![CDATA[{0}]]></Title><Description><![CDATA[{1}]]></Description><PicUrl><![CDATA[{2}]]></PicUrl><Url><![CDATA[{3}]]></Url></item>";
        /// <summary>
        /// 新闻列表反馈格式{0}接收人{1}发送人{2}时间秒{3}行数{4}内容
        /// </summary>
        public const string News =
            "<xml><ToUserName><![CDATA[{0}]]></ToUserName><FromUserName><![CDATA[{1}]]></FromUserName><CreateTime>{2}</CreateTime><MsgType><![CDATA[news]]></MsgType><ArticleCount>{3}</ArticleCount><Articles>{4}</Articles></xml>";

    }
}
