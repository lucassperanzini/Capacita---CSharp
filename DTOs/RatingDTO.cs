using System.ComponentModel.DataAnnotations;

namespace Capacita.API.DTOs
{
    public class RatingDTO
    {
        public int UserId { get;  set; }
        [Required] public string Nome { get; set; }
        [Required] public string Email { get; set; }
        [Required] public int Nota { get;  set; }
        [Required]public string Comentario { get; set; }
    }
}
