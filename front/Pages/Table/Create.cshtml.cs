using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using front.Constant;
using front.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace front.Pages.Table
{
    public class Create : PageModel
    {
        public async Task<IActionResult> OnPostAsync(int TableId, bool isFree)
        {
            var httpClient = new HttpClient();
            var dto = new TableDTO{IsFree=isFree,TableId=TableId};
            var content = ApiConstants.Desarialize(dto);
            var response = await httpClient.PostAsync(ApiConstants.TABLE_URL,content);
            if(response.IsSuccessStatusCode){
            }
            return RedirectToPage("Index");
        }
        public IActionResult OnGet(){
            return Page();
        }
    }
}