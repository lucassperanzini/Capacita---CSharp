namespace Capacita.API.Models;

public class Course
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Nivel { get; set; } = "Básico";
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

    public List<Enrollment> Enrollments { get; set; } = new();
    public List<CourseRating> Ratings { get; set; } = new();
}
