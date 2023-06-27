using System.Net.Http;
using System.Threading.Tasks;
using front.Constant;
using front.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front.Pages.Waiter
{
    public class Delete : PageModel
    {
        public WaiterDTO Waiter = new WaiterDTO();
        public int id;

        private HttpClient _httpClient = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            this.id = id;
            var response = await _httpClient.GetAsync($"{ApiConstants.WAITER_URL}{id}" );
            
            if (response.IsSuccessStatusCode)
            {
                Waiter = await ApiConstants.SerializeAsync<WaiterDTO>(response);
                return Page();
            }
            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(ApiConstants.WAITER_URL + id);
            if (response.IsSuccessStatusCode)
            {
                // Depois criar criar uma mensagem de sucesso, ou redirecionar para os Index
            }
            return Page();
            
        }
    }
}