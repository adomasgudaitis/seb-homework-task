using Microsoft.EntityFrameworkCore;
using SebHomeworkTask.Core.Exceptions;
using SebHomeworkTask.Infrastructure.Data.Models;

namespace SebHomeworkTask.Infrastructure.Data;

public class PollutionSourceRepository : IPollutionSourceRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<PollutionSourceRepository> _logger;

    public PollutionSourceRepository(ApplicationDbContext context, ILogger<PollutionSourceRepository> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    public async Task<IEnumerable<PollutionSource>> GetAll()
    {
        _logger.LogInformation("Fetching pollution sources from the database.");

        return await _context.PollutionSources.ToListAsync();
    }

    public async Task AddRange(IEnumerable<PollutionSource> entities)
    {
        try
        {
            _logger.LogInformation("Saving pollution sources to the database.");
            await _context.PollutionSources.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, "Failed to save pollution sources to the database.");
            throw new DataStoringException("Failed to save pollution sources to the database.", e);
        }

    }
}