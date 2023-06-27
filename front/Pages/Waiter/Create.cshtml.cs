using System.Net.Http;
using System.Threading.Tasks;
using front.Constant;
using front.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front.Pages.Waiter;

public class Create : PageModel
{
    private HttpClient _httpClient = new();
    
    public async Task<IActionResult> OnPostAsync(string WaiterName)
    {
        var dto = new WaiterDTO(){
            FistName = Request.Form["Name"],
            LastName = Request.Form["LastName"],
            Fone = int.Parse(Request.Form["Fone"]!),
            WaiterId = 0
        };
        var content = ApiConstants.Desarialize(dto);
        var response = await _httpClient.PostAsync(ApiConstants.WAITER_URL,content);
        if(response.IsSuccessStatusCode){
            //
        }
        return RedirectToPage("Index");
    }

    public IActionResult OnGet(){
        return Page();
    }
}
