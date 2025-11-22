using Capacita.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Capacita.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Course> Courses => Set<Course>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();
    public DbSet<CourseRating> Ratings => Set<CourseRating>();
}
