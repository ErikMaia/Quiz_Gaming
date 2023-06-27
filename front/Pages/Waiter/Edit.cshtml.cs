using System.Net.Http;
using System.Threading.Tasks;
using front.Constant;
using front.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front.Pages.Waiter
{
    public class Edit : PageModel
    {
        private HttpClient _httpClient = new();
        public WaiterDTO Waiter = new();
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var response = await _httpClient.GetAsync(ApiConstants.WAITER_URL+id);
            if(response.IsSuccessStatusCode){
                Waiter = await ApiConstants.SerializeAsync<WaiterDTO>(response);
            }
            return Page();

        }
    
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var dto = new WaiterDTO(){
                FistName = Request.Form["WaiterName"],
                LastName = Request.Form["LastName"],
                Fone = int.Parse(Request.Form["ProductPrice"]!)
            };
            var content = ApiConstants.Desarialize(dto);
            var response = await _httpClient.PutAsync(ApiConstants.WAITER_URL, content);

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