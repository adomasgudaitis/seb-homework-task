using Microsoft.EntityFrameworkCore;
using SebHomeworkTask.API.Middleware;
using SebHomeworkTask.Application.Services;
using SebHomeworkTask.Infrastructure.Data;
using SebHomeworkTask.Infrastructure.Services;

namespace SebHomeworkTask;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddScoped<IPollutionSourceClient, PollutionSourceClient>();
        builder.Services.AddHttpClient<IPollutionSourceClient, PollutionSourceClient>();
        builder.Services.AddScoped<IPollutionSourceRepository, PollutionSourceRepository>();
        builder.Services.AddScoped<IPollutionSourceProcessingService, PollutionSourceProcessingService>();
        builder.Services.AddHostedService<PollutionSourceBackgroundService>();
        builder.Services.AddControllers();

        // Db context
        builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("InMemoryDatabase"));
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.UseBadRequestLoggingMiddleware();
        app.UseGlobalExceptionHandlerMiddleware();

        app.MapControllers();

        app.Run();
    }
}