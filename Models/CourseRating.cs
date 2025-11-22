namespace Capacita.API.Models;

public class CourseRating
{
    public int Id { get; set; }
    public int CourseId { get; set; }
    public int UserId { get; set; }
    public int Nota { get; set; }
    public string Comentario { get; set; } = string.Empty;
    public DateTime DataAvaliacao { get; set; } = DateTime.UtcNow;

    public Course? Course { get; set; }
    public User? User { get; set; }
}
