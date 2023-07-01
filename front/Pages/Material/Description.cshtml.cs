using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace front.Pages.Material
{
    public class Description : PageModel
    {
        private readonly ILogger<Description> _logger;

        public Description(ILogger<Description> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}