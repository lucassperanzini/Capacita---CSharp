using Capacita.API.Data;
using Capacita.API.Dtos;
using Capacita.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Capacita.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class EnrollmentsController : ControllerBase
{
    private readonly AppDbContext _context;

    public EnrollmentsController(AppDbContext context) => _context = context;

    [HttpPost]
    public async Task<IActionResult> Enroll([FromBody] EnrollmentDto dto)
    {
        if (!await _context.Users.AnyAsync(u => u.Id == dto.UserId) ||
            !await _context.Courses.AnyAsync(c => c.Id == dto.CourseId))
            return BadRequest("Usuário ou curso não existe.");

        var enrollment = new Enrollment
        {
            UserId = dto.UserId,
            CourseId = dto.CourseId,
            Progresso = 0
        };

        _context.Enrollments.Add(enrollment);
        await _context.SaveChangesAsync();

        return Ok(enrollment);
    }

    [HttpPut("{id}/progresso")]
    public async Task<IActionResult> UpdateProgress(int id, [FromQuery] int progresso)
    {
        var enrollment = await _context.Enrollments.FindAsync(id);
        if (enrollment is null) return NotFound();

        enrollment.Progresso = progresso;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEnrollments()
    {
        var enrollments = await _context.Enrollments
            .Include(e => e.User)
            .Include(e => e.Course)
            .Select(e => new EnrollmentViewDto
            {
                Id = e.Id,
                NomeUsuario = e.User.Nome,
                NomeCurso = e.Course.Titulo,
                Progresso = e.Progresso,
                DataMatricula = e.DataMatricula
            })
            .ToListAsync();

        return Ok(enrollments);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEnrollment(int id)
    {
        var enrollment = await _context.Enrollments.FindAsync(id);
        if (enrollment == null)
            return NotFound();

        _context.Enrollments.Remove(enrollment);
        await _context.SaveChangesAsync();
        return NoContent();
    }



}
