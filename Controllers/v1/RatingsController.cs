using Capacita.API.Data;
using Capacita.API.Models;
using Capacita.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Capacita.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class RatingsController : ControllerBase
{
    private readonly AppDbContext _context;

    public RatingsController(AppDbContext context) => _context = context;

    [HttpPost("{courseId}")]
    public async Task<IActionResult> RateCourse(int courseId, [FromBody] RatingDTO dto)
    {
        if (!await _context.Courses.AnyAsync(c => c.Id == courseId) ||
            !await _context.Users.AnyAsync(u => u.Id == dto.UserId))
            return BadRequest("Curso ou usuário não existe.");

        var rating = new CourseRating
        {
            CourseId = courseId,
            UserId = dto.UserId,
            Nota = dto.Nota,
            Comentario = dto.Comentario
        };

        _context.Ratings.Add(rating);
        await _context.SaveChangesAsync();

        return Ok(rating);
    }

    [HttpGet("curso/{courseId}")]
    public async Task<IActionResult> GetRatingsForCourse(int courseId)
    {
        var ratings = await _context.Ratings
            .Where(r => r.CourseId == courseId)
            .ToListAsync();

        return Ok(ratings);

    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRating(int id)
    {
        var rating = await _context.Ratings.FindAsync(id);
        if (rating == null)
            return NotFound();

        _context.Ratings.Remove(rating);
        await _context.SaveChangesAsync();
        return NoContent();
    }

}
