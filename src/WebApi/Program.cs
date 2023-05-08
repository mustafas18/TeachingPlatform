using Core.Entities;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.Cookies;
using Infrastructure.Identity;
using Core;
using Microsoft.Extensions.FileProviders;
using Org.BouncyCastle.Ocsp;

namespace WebApi
{
    public class Program
    {

        public static async Task Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            ConfigurationManager Configuration = builder.Configuration;


            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.SameSite = SameSiteMode.Lax;
    });
            builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            })
                       .AddEntityFrameworkStores<AppDbContext>()
                       .AddDefaultTokenProviders();


            // Add services to the container.
            builder.Services.AddMyServices();
            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("myCorsPolicy", policy =>
                {
                    policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                });
            });


            builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            builder.Services.AddMemoryCache();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Teaching Platform API",
                    Version = "v1",
                    Description = "پلتفرم آموزش آنلاین",
                });
                // To Enable authorization using Swagger (JWT)  
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });
#if DEBUG
            builder.Services.AddDbContext<AppDbContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));
#else
            builder.Services.AddDbContext<AppDbContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("ReleaseConnectionString")));
#endif


            builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = AppConstants.validIssuer,
                    ValidAudience = AppConstants.validAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppConstants.securityKey))
                };
            });
            builder.Services.AddResponseCaching();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddControllers();


            var app = builder.Build();

            // UseCors must be called before UseResponseCaching
            app.UseCors("myCorsPolicy");

            app.UseResponseCaching();

            using (var scope = app.Services.CreateScope())
            {
                var scopedProvider = scope.ServiceProvider;
                    var userManager = scopedProvider.GetRequiredService<UserManager<AppUser>>();
                    var roleManager = scopedProvider.GetRequiredService<RoleManager<IdentityRole>>();
                    var identityContext = scopedProvider.GetRequiredService<AppDbContext>();
                    await AppDbContextSeed.SeedAsync(identityContext, userManager, roleManager);
            }

            //if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "Docker")
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

            // Enable displaying browser links.
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}