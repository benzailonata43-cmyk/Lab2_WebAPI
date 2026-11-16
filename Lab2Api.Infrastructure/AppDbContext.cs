using Microsoft.EntityFrameworkCore;
using Lab2Api.Models;

namespace Lab2Api.Infrastructure;

public class AppDbContext : DbContext
{
public AppDbContext(DbContextOptions<AppDbContext> options)
: base(options)
{
}

public DbSet<Entity> Entities { get; set; } = null!;
}