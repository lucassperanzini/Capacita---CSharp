using Capacita.API.Data;
using Capacita.API.Dtos;
using Capacita.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Capacita.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly AppDbContext _context;

    public CoursesController(AppDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> GetCourses()
        => Ok(await _context.Courses.ToListAsync());

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCourse(int id)
    {
        var course = await _context.Courses.FindAsync(id);
        return course is null ? NotFound() : Ok(course);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCourse([FromBody] CourseDto dto)
    {
        var course = new Course
        {
            Titulo = dto.Titulo,
            Descricao = dto.Descricao,
            Nivel = dto.Nivel
        };

        _context.Courses.Add(course);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, course);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCourse(int id, [FromBody] CourseDto dto)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course is null) return NotFound();

        course.Titulo = dto.Titulo;
        course.Descricao = dto.Descricao;
        course.Nivel = dto.Nivel;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourse(int id)
    {
        var course = await _context.Courses.FindAsync(id);
        if (course is null) return NotFound();

        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
