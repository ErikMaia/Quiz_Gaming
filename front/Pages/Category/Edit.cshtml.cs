using System.Net.Http;
using System.Threading.Tasks;
using front.Constant;
using front.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front.Pages.Category
{
    public class Edit : PageModel
    {
        private HttpClient _httpClient = new();
        public CategoryDTO Category = new();
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var response = await _httpClient.GetAsync(ApiConstants.CATEGORY_URL+id);
            if(response.IsSuccessStatusCode){
                Category = await ApiConstants.SerializeAsync<CategoryDTO>(response);
            }
            return Page();

        }
    
        public async Task<IActionResult> OnPostAsync(int id)
        {
            CategoryDTO Category = new();
            Category.CategoryName = Request.Form["CategoryName"].ToString();
            Category.CategoryId = id;
            var content = ApiConstants.Desarialize(Category);
            var response = await _httpClient.PutAsync(ApiConstants.CATEGORY_URL, content);

            // Verifique o resultado da requisição
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("Sucesso");
            }
            else
            {
                return RedirectToPage("Erro");
            }
            //return Page();
        }
    }
}