using System.Net.Http;
using System.Threading.Tasks;
using front.Constant;
using front.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front.Pages.Products;

public class Create : PageModel
{
    private HttpClient _httpClient = new();

    public List<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();
    
    public async Task<IActionResult> OnPostAsync(string ProductsName)
    {

        var dto = new ProductDTO(){
            Name = Request.Form["ProductsName"],
            Description = Request.Form["ProductDescription"],
            Category = int.Parse(Request.Form["category"]!),
            Price = float.Parse(Request.Form["ProductPrice"]!)
        };
        var content = ApiConstants.Desarialize(dto);
        var response = await _httpClient.PostAsync(ApiConstants.PRODUCT_URL,content);
        if(response.IsSuccessStatusCode){
            // return Page();
        }
        return RedirectToPage("Index");
    }

    public async Task<IActionResult> OnGetAsync(){
        var response = await _httpClient.GetAsync(ApiConstants.CATEGORY_URL);
        Categories = await ApiConstants.SerializeAsync<List<CategoryDTO>>(response);
        return Page();
    }
}
