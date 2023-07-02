using api.core.DTOs;
using front.Constant;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace front.Pages.Quizz;
public class Index : PageModel
{
    public List<QuizzDTO> quiz { get; set; } = new List<QuizzDTO>();
    private readonly ILogger<Quiz> _logger;

    public Index(ILogger<Quiz> logger)
    {
        _logger = logger;
    }

    public async void OnGet()
    {
        var http = new HttpClient();
        var request = await http.GetAsync(Api.QUIZ_URL);
        quiz = await Json.SerializeAsync<List<QuizzDTO>>(request);
    }
}
