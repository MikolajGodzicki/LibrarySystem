
using LibraryAPI.Entities;
using LibraryAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<LibraryDbContext>();

            builder.Services.AddTransient<IBooksService, BooksService>();
            builder.Services.AddTransient<IUsersService, UsersService>();

            builder.Services.AddScoped<LibrarySeeder>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var _librarySeeder = scope.ServiceProvider.GetRequiredService<LibrarySeeder>();
                _librarySeeder.SeedDbValues();
            }

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
