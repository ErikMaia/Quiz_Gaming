using System.Net.Http;
using System.Threading.Tasks;
using front.Constant;
using front.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front.Pages.Category
{
    public class Details : PageModel
    {
        public CategoryDTO Category = new();
        private HttpClient httpClient = new();
        public async Task<IActionResult> OnGetAsync(int id)
        {
            try{
                var response = await httpClient.GetAsync(ApiConstants.CATEGORY_URL+id);
                Category = await ApiConstants.SerializeAsync<CategoryDTO>(response);
                return Page();

            }
            catch (HttpRequestException){
                return NotFound();
            }
        }
    }
}