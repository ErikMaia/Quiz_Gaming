using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace front.Pages.Login
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
                Password = Request.Form["password"],
            };

            var response = await http.PostAsJsonAsync(Api.STUDENT+"/login", student);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/");
            }

            return Page();

        }
    }
}