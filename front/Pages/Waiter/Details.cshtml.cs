using System.Net.Http;
using System.Threading.Tasks;
using front.Constant;
using front.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front.Pages.Waiter
{
    public class Details : PageModel
    {
        public WaiterDTO Waiter = new();
        
        private HttpClient httpClient = new();
        public async Task<IActionResult> OnGetAsync(int id)
        {
            try{
                var response = await httpClient.GetAsync(ApiConstants.WAITER_URL+id);
                Waiter = await ApiConstants.SerializeAsync<WaiterDTO>(response);
                return Page();

            }
            catch (HttpRequestException){
                return NotFound();
            }
        }
    }
}