
using Microsoft.EntityFrameworkCore;
using Repository;
using Services.Usuario;
using System.Text.Json.Serialization;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                            .AddJsonOptions(c =>
                            {
                                c.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<UsuarioService>();

            builder.Services.AddDbContext<SpotifyContext>(config =>
            {
                config.UseSqlServer(builder.Configuration.GetConnectionString("SpotifyConnection"));
            });

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
}