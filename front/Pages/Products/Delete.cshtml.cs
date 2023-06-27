using front.Constant;
using front.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front.Pages.Products
{
    public class Delete : PageModel
    {
        // public ProductDTO Product = new ProductDTO();
        public int id;

        private HttpClient _httpClient = new HttpClient();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            this.id = id;
            var response = await _httpClient.GetAsync($"{ApiConstants.PRODUCT_URL}{id}" );
            
            if (response.IsSuccessStatusCode)
            {
                // Product = await ApiConstants.SerializeAsync<ProductDTO>(response);
                return Page();
            }
            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var response = await _httpClient.DeleteAsync(ApiConstants.PRODUCT_URL + id);
            if (response.IsSuccessStatusCode)
            {
                // Depois criar criar uma mensagem de sucesso, ou redirecionar para os Index
            }
            return RedirectToPage("Index");            
        }
    }
}