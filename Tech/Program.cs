using Microsoft.EntityFrameworkCore;
using Tech.Models;
using Tech.Repository;

namespace Tech
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
            builder.Services.AddScoped<IResultRepository, ResultRepository>();
            
            builder.Services.AddDbContext<TechContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Tech"));
            });

            // To session
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession(option => {
                option.IdleTimeout = TimeSpan.FromMinutes(20);
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
            


        }
    }
}
