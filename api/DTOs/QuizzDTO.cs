using System.ComponentModel.DataAnnotations;

namespace api.DTOs;
public class QuizzDTO
{

    public int QuizzId { get; set; }
    public string? QuizzTitle { get; set; }

    public int Correct { get; set; }

    public string? Questions { get; set; }

    public string? FirstOption { get; set; }

    public string? SecondOption { get; set; }

    public string? ThirdOption { get; set; }
}
