using System.Text;
using api.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace front.Pages.Register
{
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;

        public Index(ILogger<Index> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var http = new HttpClient();
            var student = new StudentDTO()
            {
                Email = Request.Form["email"],
                FirstName = Request.Form["firstName"],
                LastName = Request.Form["lastName"],
                Password = Request.Form["password"],
            };
            var response = await http.PostAsJsonAsync(Api.STUDENT + "/login", student);
            return RedirectToPage("/Login/Index");
        }
    }
}