using System;
using System.Net.Http;
using System.Threading.Tasks;
using front.Constant;
using front.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace front.Pages.Table
{
    public class Details : PageModel
    {
        public TableDTO table = new();


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            using var httpClient = new HttpClient();
            
            var response = await httpClient.GetAsync(ApiConstants.TABLE_URL+id);
            
            if(response.IsSuccessStatusCode)
            {
                table = await ApiConstants.SerializeAsync<TableDTO>(response);
            }
            else
            {
                Console.WriteLine("Request failed");
            }
            return Page();
        }
    }
}