using Microsoft.EntityFrameworkCore;
using SebHomeworkTask.Infrastructure;
using SebHomeworkTask.Infrastructure.Data;
using SebHomeworkTask.Infrastructure.Services;

namespace SebHomeworkTask;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        //Infrastructure
        builder.Services.AddScoped<IPollutionSourceService, PollutionSourceService>();
        builder.Services.AddHttpClient<IPollutionSourceService, PollutionSourceService>();
        builder.Services.AddScoped<IPollutionSourceRepository, PollutionSourceRepository>();
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        
        // Db context
        builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("InMemoryDatabase"));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}