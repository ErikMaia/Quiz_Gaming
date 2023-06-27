using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using front.Constant;
using front.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front.Pages.Products
{
    public class Index : PageModel
    {
        public List<ProductDTO> Product { get; set; } = new List<ProductDTO>();
        
        public async Task<IActionResult> OnGetAsync()
        {
            try{
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(ApiConstants.PRODUCT_URL);
                Product = await ApiConstants.SerializeAsync<List<ProductDTO>>(response);
                return Page();
            }
            catch (HttpRequestException){
                return NotFound();
            }
        }
    }
}