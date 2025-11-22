
namespace Capacita.API.Models;

public class User
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

    public List<Enrollment> Enrollments { get; set; } = new();
    public List<CourseRating> Ratings { get; set; } = new();
}
