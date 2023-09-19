using front.DTOs;
using front.Constant;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front.Pages.Quizz
{
    public class Quiz : PageModel
    {
        public QuizzDTO quiz { get; set; } = new ();
        private readonly ILogger<Quiz> _logger;

        public Quiz(ILogger<Quiz> logger)
        {
            _logger = logger;
        }

        public async Task OnGet(int id)
        {
            var http = new HttpClient();
            var request = await http.GetAsync($"{Api.QUIZ_URL}/{id}");
            quiz = await Json.SerializeAsync<QuizzDTO>(request);
        }
    }
}