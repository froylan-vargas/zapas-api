using Zapas.Data.Automapper.Profiles;
using Zapas.Data.Cache;
using Zapas.Data.Models;
using Zapas.Services.RaceService;
using Zapas.Services.RaceTypeService;
using Zapas.Services.ZapaService;
using Zapas.Services.PlaceService;
using Zapas.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Zapas.Services.Login;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Zapas.Data.DTO.Race.RaceOptions;

namespace Zapas
{
    public class StartServices
    {
        public void RegisterServices(WebApplicationBuilder builder)
        {
            //Add ASP.NET Core Identity support
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true;
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 8;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>();

            //Add Authentication services & middlewares
            builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options=>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                    ValidAudience = builder.Configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.
                        GetBytes(builder.Configuration["JwtSettings:SecurityKey"]))
                };
            });

            //Automapper
            builder.Services.AddAutoMapper(typeof(RaceProfile));
            builder.Services.AddAutoMapper(typeof(ZapaProfile));
            builder.Services.AddAutoMapper(typeof(RaceTypeProfile));
            builder.Services.AddAutoMapper(typeof(PlaceProfile));

            //Cache
            builder.Services.AddSingleton<IApplicationCache<IEnumerable<ZapaSelection>>,
                ApplicationCache<IEnumerable<ZapaSelection>>>();
            builder.Services.AddSingleton<IApplicationCache<IEnumerable<RaceTypeSelection>>,
                ApplicationCache<IEnumerable<RaceTypeSelection>>>();
            builder.Services.AddSingleton<IApplicationCache<IEnumerable<PlaceSelection>>,
                ApplicationCache<IEnumerable<PlaceSelection>>>();

            //Services
            builder.Services.AddScoped<IRaceService, RaceService>();
            builder.Services.AddScoped<IZapaService, ZapaService>();
            builder.Services.AddScoped<IRaceTypeService, RaceTypeService>();
            builder.Services.AddScoped<IPlaceService, PlaceService>();
            builder.Services.AddScoped<JwtService>();
        }
    }
}
