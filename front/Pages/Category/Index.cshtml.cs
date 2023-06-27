using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using front.Constant;
using front.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front.Pages.Category
{
    public class IndexModel : PageModel
    {
        public List<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();

        public async Task<IActionResult> OnGetAsync()
        {
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetAsync(ApiConstants.CATEGORY_URL);
                response.EnsureSuccessStatusCode(); // Verifica se a resposta da API é bem-sucedida

                Categories = await ApiConstants.SerializeAsync<List<CategoryDTO>>(response);
                Console.WriteLine(Categories);
                return Page();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e);
                return Page();
            }
        }
    }
}
