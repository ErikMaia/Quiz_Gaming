using System.Net.Http;
using System.Threading.Tasks;
using front.Constant;
using front.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace front.Pages.Category
{
    public class Delete : PageModel
    {
        public CategoryDTO Category = new();
        public int id;

        private HttpClient _httpClient = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            this.id = id;
            var response = await _httpClient.GetAsync($"{ApiConstants.CATEGORY_URL}{id}" );
            
            if (response.IsSuccessStatusCode)
            {
                Category = await ApiConstants.SerializeAsync<CategoryDTO>(response);
                return Page();
            }
            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(ApiConstants.CATEGORY_URL + id);
            if (response.IsSuccessStatusCode)
            {
                // Depois criar criar uma mensagem de sucesso, ou redirecionar para os Index
            }
            return Page();
            
        }
    }
}