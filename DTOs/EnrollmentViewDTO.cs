namespace Capacita.API.Dtos;

public class EnrollmentViewDto
{
    public int Id { get; set; }
    public string NomeUsuario { get; set; } = string.Empty;
    public string NomeCurso { get; set; } = string.Empty;
    public int Progresso { get; set; }
    public DateTime DataMatricula { get; set; }
}
