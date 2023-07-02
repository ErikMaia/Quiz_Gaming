using System.Text;
using Newtonsoft.Json;

namespace front.Constant;
public class Json
{
    static public async Task<T> SerializeAsync<T>(HttpResponseMessage? response)
    {
        var jsonResponse = await response!.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(jsonResponse)!;
    }
    static public StringContent Deserialize<T>(T dto)
    {
        var json = JsonConvert.SerializeObject(dto);
        return new StringContent(json, Encoding.UTF8, "application/json");
    }
}
