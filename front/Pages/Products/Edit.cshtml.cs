using System.Net.Http;
using System.Threading.Tasks;
using front.Constant;
using front.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace front.Pages.Products
{
    public class Edit : PageModel
    {
        private HttpClient _httpClient = new();
        public ProductDTO Products = new();
        public List<CategoryDTO> Categories = new();
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var response = await _httpClient.GetAsync(ApiConstants.PRODUCT_URL + id);
            if (response.IsSuccessStatusCode)
            {
                Products = await ApiConstants.SerializeAsync<ProductDTO>(response);
                response = await _httpClient.GetAsync(ApiConstants.CATEGORY_URL);
                Categories = await ApiConstants.SerializeAsync<List<CategoryDTO>>(response);
                return Page();
            }
            return NotFound();

        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var dto = new ProductDTO()
            {
                ProductId = id,
                Name = Request.Form["ProductsName"],
                Description = Request.Form["ProductDescription"],
                Category = int.Parse(Request.Form["category"]!),
                Price = int.Parse(Request.Form["ProductPrice"]!)
            };
            var content = ApiConstants.Desarialize(dto);
            var response = await _httpClient.PutAsync(ApiConstants.PRODUCT_URL, content);


            return RedirectToPage("Index");

        }
    }
}