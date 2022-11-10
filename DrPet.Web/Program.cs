using DrPet.Bll.Services;
using DrPet.Data;
using Microsoft.EntityFrameworkCore;

namespace DrPet.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<DrPetDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DrPetDB")));
            builder.Services.AddScoped<DrPetService>();
            builder.Services.AddScoped<OrderingHourService>();
            builder.Services.AddScoped<DoctorService>();
            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddControllers();

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DrPetDbContext>();
                var migrations = dbContext.Database.GetMigrations().ToHashSet();
                if (dbContext.Database.GetAppliedMigrations().Any(a => !migrations.Contains(a)))
                {
                    throw new Exception("Törölt migráció!");
                }
                dbContext.Database.Migrate();
            }
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.MapControllers();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}