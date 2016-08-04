using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Gvhs.Web.Pms.DataContracts;
using Newtonsoft.Json;
using System.Net;
using System;

namespace Gvhs.Web.Pms
{
    /// <summary>
    /// 具有获取Cookie功能的Web帮助器
    /// </summary>
    public class WebCookieHelper
    {
        /// <summary>
        /// 获取Cookie
        /// </summary>
        /// <param name="url">获取Cookie的地址</param>
        /// <returns>Cookie 或 null</returns>
        public static Cookie GetCookie(string url)
        {
            var uri = new Uri(url);
            var handler = new HttpClientHandler();
            using (var client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var resResult = client.GetAsync(uri);
                resResult.Wait();
                var res = resResult.Result;
                var operatorResultTask = res.Content.ReadAsStringAsync();
                operatorResultTask.Wait();
                var operatorResult = JsonConvert.DeserializeObject<OperatorResult>(operatorResultTask.Result);
                if (operatorResult.errorCode == 0)
                {
                    var cookies = handler.CookieContainer.GetCookies(uri);
                    if (cookies != null && cookies.Count > 0)
                        return cookies[0];
                }
                return null;
            }
        }

        public static TResult GetApi<TResult>(string url, Cookie cookie = null)
        {
            var resultTask = GetApiAsync<TResult>(url, cookie);
            resultTask.Wait();
            return resultTask.Result;
        }

        public async static Task<TResult> GetApiAsync<TResult>(string url, Cookie cookie = null)
        {
            var uri = new Uri(url);
            var handler = new HttpClientHandler();
            if (cookie != null)
                handler.CookieContainer.Add(cookie);
            using (var client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                // 请求头标
                // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token");  // 身份验证
                var res = await client.GetAsync(uri);
                var str = await res.Content.ReadAsStringAsync();
                Console.WriteLine(str);
                if (!res.IsSuccessStatusCode) return default(TResult);
                var result = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResult>(result);
            }
        }

        public static TResult PostApi<TResult, TObject>(string url, TObject obj, Cookie cookie = null)
        {
            var resultTask = PostApiAsync<TResult, TObject>(url, obj, cookie);
            resultTask.Wait();
            return resultTask.Result;
        }

        public async static Task<TResult> PostApiAsync<TResult, TObject>(string url, TObject obj, Cookie cookie = null)
        {
            var uri = new Uri(url);
            var handler = new HttpClientHandler();
            if (cookie != null)
                handler.CookieContainer.Add(cookie);
            using (var client = new HttpClient(handler))
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var objString = JsonConvert.SerializeObject(obj);
                var content = new StringContent(objString);
                content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var res = await client.PostAsync(uri, content);
                if (!res.IsSuccessStatusCode) return default(TResult);
                var result = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResult>(result);
            }
        }
    }
}
