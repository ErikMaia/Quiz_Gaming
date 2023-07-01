using api.core.DTOs;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front.Pages.Quizz
{
    public class Index : PageModel
    {
        public QuizzDTO Quiz { get; set; } = new();
        private readonly ILogger<Index> _logger;

        public Index(ILogger<Index> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public void OnPost() {

         }
    }
}