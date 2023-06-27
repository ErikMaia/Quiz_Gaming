using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using front.Constant;
using front.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front.Pages.Table
{
    public class Index : PageModel
    {
        public List<TableDTO> Tables { get; set; }= new();

        public async Task<IActionResult> OnGetAsync()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(ApiConstants.TABLE_URL);
            // if(response.IsSuccessStatusCode)
            Tables = await ApiConstants.SerializeAsync<List<TableDTO>>(response);

            return Page();
        }
    }
}