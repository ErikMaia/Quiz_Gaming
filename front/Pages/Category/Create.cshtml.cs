using System.Net.Http;
using System.Threading.Tasks;
using front.Constant;
using front.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front.Pages.Category
{
    public class Create : PageModel
    {
        private HttpClient _httpClient = new();
        
        public async Task<IActionResult> OnPostAsync(string CategoryName)
        {
            var dto = new CategoryDTO{CategoryName=CategoryName};
            var content = ApiConstants.Desarialize(dto);
            var response = await _httpClient.PostAsync(ApiConstants.CATEGORY_URL,content);
            if(response.IsSuccessStatusCode){
                // return Page();
            }
            return RedirectToPage("Index");
        }

        public IActionResult OnGet(){
            return Page();
        }
    }
}