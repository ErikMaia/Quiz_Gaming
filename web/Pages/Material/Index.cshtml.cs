using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs;
using front.Constant;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace front.Pages.Material
{
    public class Index : PageModel
    {
        public List<MaterialDTO> materials { get; set; } = new List<MaterialDTO>();
        private readonly ILogger<Index> _logger;

        public Index(ILogger<Index> logger)
        {
            _logger = logger;
        }


        public async Task<IActionResult> OnGet()
        {
            if (Request.Cookies["email"] == null)
            {
                return RedirectToPage("/Login/Index");
            }
            var http = new HttpClient();
            var request = await http.GetAsync(Api.MATERIAL_URL);
            materials = await Json.SerializeAsync<List<MaterialDTO>>(request);
            Console.WriteLine(materials.ToString());
            return Page();
        }

    }
}