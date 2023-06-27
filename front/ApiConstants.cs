using System.Text;
using Newtonsoft.Json;

namespace front.Constant
{
    public class ApiConstants
    {
        public const string BASE_URL = "http://api:5182/";
        public const string TABLE_URL = BASE_URL + "table/";
        public const string CATEGORY_URL = BASE_URL + "category/";
        public const string PRODUCT_URL = BASE_URL + "product/";
        public const string WAITER_URL = BASE_URL + "waiter/";

        static public async Task<T> SerializeAsync<T>(HttpResponseMessage? response) {
            var jsonResponse = await response!.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(jsonResponse)!;
        }
        static public StringContent Desarialize<T>(T dto){
            var json = JsonConvert.SerializeObject(dto);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}