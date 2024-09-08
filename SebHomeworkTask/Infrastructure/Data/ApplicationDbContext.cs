using Microsoft.EntityFrameworkCore;
using SebHomeworkTask.Infrastructure.Data.Models;

namespace SebHomeworkTask.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<PollutionSource> PollutionSources { get; set; }
}