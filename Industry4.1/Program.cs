
using Industry4._1.Data;
using Industry4._1.Interfaces;
using Industry4._1.Services;
using Microsoft.EntityFrameworkCore;

namespace Industry4._1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 🔹 Register Services FIRST
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IMachineService, MachineService>();
            builder.Services.AddScoped<IUserService, AppUserService>();
            builder.Services.AddScoped<IShiftService, ShiftService>();



            var app = builder.Build();

            // 🔹 Middleware
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
