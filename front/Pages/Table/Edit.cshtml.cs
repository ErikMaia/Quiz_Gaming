using System.Net.Http;
using System.Threading.Tasks;
using front.Constant;
using front.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace front.Pages.Table
{
    public class Edit : PageModel
    {
        private HttpClient _httpClient = new HttpClient();
        public TableDTO Tables = new TableDTO();
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var response = await _httpClient.GetAsync(ApiConstants.TABLE_URL+id);
            if(response.IsSuccessStatusCode){
                Tables = await ApiConstants.SerializeAsync<TableDTO>(response);
            }
            return Page();

        }
    
        public async Task<IActionResult> OnPostAsync(int id)
        {
            TableDTO table = new(){
                TableId = id,
                IsFree = bool.Parse(Request.Form["IsFree"].ToString())
            };
            var content = ApiConstants.Desarialize(table);
            var response = await _httpClient.PutAsync(ApiConstants.TABLE_URL,content);
            return Page();
        }
    }
}