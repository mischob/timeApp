using FastEndpoints;
using FastEndpoints.Swagger;

namespace TimeTracker.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services
            .AddFastEndpoints()
            .SwaggerDocument(o =>
            {
                o.DocumentSettings = s =>
                {
                    s.Title = "TimeTracker API";
                    s.Version = "v1";
                };
                o.ShortSchemaNames = true;
                o.RemoveEmptyRequestSchema = true;
            });

        // Add authentication and authorization
        builder.Services.AddAuthentication();
        builder.Services.AddAuthorization();

        // Add CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowBlazorClient", policy =>
            {
                policy.WithOrigins("http://localhost:5001")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwaggerGen();
        }

        app.UseHttpsRedirection();
        app.UseCors("AllowBlazorClient");

        // Add authentication and authorization middleware
        app.UseAuthentication();
        app.UseAuthorization();

        app.UseFastEndpoints();

        app.Run();
    }
}