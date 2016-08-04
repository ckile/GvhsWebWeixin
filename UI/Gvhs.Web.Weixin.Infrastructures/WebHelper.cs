using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Gvhs.Web.Weixin.Infrastructures
{
    public class WebHelper
    {
        public static TResult GetApi<TResult>(string url)
        {
            var resultTask = GetApiAsync<TResult>(url);
            resultTask.Wait();
            return resultTask.Result;
        }

        public async static Task<TResult> GetApiAsync<TResult>(string url)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                // 请求头标
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token");  // 身份验证
                var res = await client.GetAsync(url);

                if (!res.IsSuccessStatusCode) return default(TResult);
                var result = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResult>(result);
            }
        }

        public static TResult PostApi<TResult, TObject>(string url, TObject obj)
        {
            var resultTask = PostApiAsync<TResult, TObject>(url, obj);
            resultTask.Wait();
            return resultTask.Result;
        }

        public async static Task<TResult> PostApiAsync<TResult, TObject>(string url, TObject obj)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                var objString = JsonConvert.SerializeObject(obj);
                var content = new StringContent(objString);
                content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");
                var res = await client.PostAsync(url, content);
                if (!res.IsSuccessStatusCode) return default(TResult);
                var result = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResult>(result);
            }
        }


    }
}
