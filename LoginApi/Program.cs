
using Microsoft.EntityFrameworkCore;
using LoginApi.Data;

namespace LoginApi
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


            builder.Services.AddDbContext<APIDbContext>(options => 
            options.UseSqlServer(builder.Configuration.GetConnectionString("FormConnectionString")));

            builder.Services.AddCors(options => options.AddPolicy("default", policy =>
            {
                policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
            }));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization(); 

            app.UseCors("default");

            app.MapControllers();

            app.Run();
        }
    }
}