using System.Net.Http;
using System.Threading.Tasks;
using front.Constant;
using front.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front.Pages.Products
{
    public class Details : PageModel
    {
        public ProductDTO Products = new();
        public CategoryDTO Category = new();
        
        private HttpClient httpClient = new();
        public async Task<IActionResult> OnGetAsync(int id)
        {
            try{
                var response = await httpClient.GetAsync(ApiConstants.PRODUCT_URL+id);
                Products = await ApiConstants.SerializeAsync<ProductDTO>(response);
                response = await httpClient.GetAsync(ApiConstants.CATEGORY_URL + Products.ProductId);
                Category = await ApiConstants.SerializeAsync<CategoryDTO>(response);
                return Page();

            }
            catch (HttpRequestException){
                return NotFound();
            }
        }
    }
}