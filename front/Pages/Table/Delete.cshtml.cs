using System.Net.Http;
using System.Threading.Tasks;
using front.Constant;
using front.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace front.Pages.Table
{
    public class Delete : PageModel
    {
        public TableDTO Table = new TableDTO();

        private HttpClient _httpClient = new HttpClient();

        public IActionResult OnGetAsync(int? id)
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id){
            var response = await _httpClient.DeleteAsync(ApiConstants.TABLE_URL + id);
            if (response.IsSuccessStatusCode)
            {
                // Depois criar criar uma mensagem de sucesso, ou redirecionar para os Index
            }
            return RedirectToPage("Index");
        }

    }
}