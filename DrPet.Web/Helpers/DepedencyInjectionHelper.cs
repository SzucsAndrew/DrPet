using DrPet.Bll.Services;
using DrPet.Data;
using DrPet.Data.Entities;
using DrPet.Data.SeedData;
using DrPet.Web.Services;
using DrPet.Web.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DrPet.Web.Helpers
{
    public static class DepedencyInjectionHelper
    {
        public static void AddServices(this IServiceCollection service, IConfigurationRoot configuration)
        {
            AddDataServices(service);
            AddBLLServices(service);
            AddWebServices(service, configuration);
        }

        private static void AddDataServices(IServiceCollection service)
        {
            service.AddScoped<IRoleSeedService, RoleSeedService>();
            service.AddScoped<IUserSeedService, UserSeedService>();
        }

        private static void AddBLLServices(IServiceCollection service)
        {
            service.AddScoped<DrPetService>();
            service.AddScoped<OrderingHourService>();
            service.AddScoped<DoctorService>();
            service.AddScoped<AnimalService>();
            service.AddScoped<SpeciesService>();
            service.AddScoped<KindService>();
            service.AddScoped<TreatmentService>();
            service.AddScoped<OwnerService>();
            service.AddScoped<TreatmentEntryService>();
            service.AddScoped<MedicineRecipeService>();
            service.AddScoped<FileService>();
        }

        private static void AddWebServices(IServiceCollection service, IConfigurationRoot configuration)
        {
            service.Configure<MailSettings>(configuration.GetSection("MailSettings"));
            service.AddTransient<IEmailSender, EmailSender>();
            service.AddAutoMapper(typeof(Program).Assembly);
        }

        public static void AddDatabase(this IServiceCollection service, IConfigurationRoot configuration)
        {
            service.AddDbContext<DrPetDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DrPetDB"));
            });
        }

        public static void AddAuth(this IServiceCollection service, IConfigurationRoot configuration)
        {
            AddLocalAuth(service);
            AddExternalAuth(service, configuration);
            AddPolicies(service);
            AddPermissionOnPages(service);
            AddCookie(service);
        }

        private static void AddLocalAuth(IServiceCollection service)
        {
            service.AddIdentity<ApplicationUser, IdentityRole<int>>()
                .AddEntityFrameworkStores<DrPetDbContext>()
                .AddDefaultTokenProviders();

            service.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                //  options.Password.RequireLowercase = true;
                //  options.Password.RequireNonAlphanumeric = true;
                //     options.Password.RequireUppercase = true;
                //     options.Password.RequiredLength = 6;
                //     options.Password.RequiredUniqueChars = 1;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                //  options.Lockout.AllowedForNewUsers = true;

                //   options.User.AllowedUserNameCharacters =
                //      "abcdefgijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
                options.SignIn.RequireConfirmedAccount = true;

            });
        }

        private static void AddExternalAuth(IServiceCollection service, IConfigurationRoot configuration)
        {
            service.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = configuration["Authentication:Google:ClientId"];
                    options.ClientSecret = configuration["Authentication:Google:ClientSecret"];
                });
        }

        private static void AddPolicies(IServiceCollection service)
        {
            service.AddAuthorization(options =>
            {
                options.AddPolicy(PolicyHelper.Admin, policy => policy.RequireClaim(ClaimTypes.Role, RoleHelper.Administrators));
                options.AddPolicy(PolicyHelper.RequiredAdministratorRole, policy => policy.RequireRole(RoleHelper.Administrators));
                options.AddPolicy(PolicyHelper.Doctor, policy => policy.RequireClaim(ClaimTypes.Role, RoleHelper.Doctors));
                options.AddPolicy(PolicyHelper.RequiredDoctorRole, policy => policy.RequireRole(RoleHelper.Doctors, RoleHelper.Administrators));
                options.AddPolicy(PolicyHelper.Assistant, policy => policy.RequireClaim(ClaimTypes.Role, RoleHelper.Assistants));
                options.AddPolicy(PolicyHelper.RequiredAssistantRole, policy => policy.RequireRole(RoleHelper.Assistants, RoleHelper.Administrators));
            });
        }

        private static void AddPermissionOnPages(IServiceCollection service)
        {
            service.AddRazorPages(options =>
            {
                options.Conventions.AuthorizeFolder("/Admin", PolicyHelper.RequiredAdministratorRole);
                options.Conventions.AuthorizeFolder("/Assistant", PolicyHelper.RequiredAssistantRole);
            });
        }

        private static void AddCookie(IServiceCollection service)
        {
            service.ConfigureApplicationCookie(options =>
             {
                 options.Cookie.HttpOnly = true;
                 options.Cookie.IsEssential = true;
                 //options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                 options.LoginPath = "/Identity/Account/Login";
                 options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                 options.SlidingExpiration = true;
             });
        }
    }
}
