using DrPet.Data;
using DrPet.Data.SeedData;
using Microsoft.EntityFrameworkCore;
using DrPet.Web.Helpers;

namespace DrPet.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var services = builder.Services;
            var configuration = builder.Configuration;

            services.AddDatabase(configuration);
            services.AddServices(configuration);
            services.AddAuth(configuration);
            services.AddControllers();

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DrPetDbContext>();
                var migrations = dbContext.Database.GetMigrations().ToHashSet();
                if (dbContext.Database.GetAppliedMigrations().Any(a => !migrations.Contains(a)))
                {
                    throw new Exception("Removed migration!");
                }
                dbContext.Database.Migrate();

                var roleSeeder = scope.ServiceProvider.GetRequiredService<IRoleSeedService>();
                await roleSeeder.SeedRoleAsync();

                var userSeeder = scope.ServiceProvider.GetRequiredService<IUserSeedService>();
                await userSeeder.SeedUserAsync();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}