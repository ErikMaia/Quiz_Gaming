using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using front.Constant;
using front.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front.Pages.Waiter
{
    public class Index : PageModel
    {
        public List<WaiterDTO> Waiter { get; set; } = new();
        
        public async Task<IActionResult> OnGetAsync()
        {
            try{
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(ApiConstants.WAITER_URL);
                Waiter = await ApiConstants.SerializeAsync<List<WaiterDTO>>(response);
                return Page();
            }
            catch (HttpRequestException){
                return NotFound();
            }
        }
    }
}