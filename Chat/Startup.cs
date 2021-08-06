using Chat.Middlewares;
using Chat.Models;
using Chat.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat {
    public class Startup {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration) {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            string connection = _configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connection));

            IConfigurationSection tokenSection = _configuration.GetSection("JWTToken");
            string cookieName = tokenSection.GetValue<string>("CookieName");
            services.AddSingleton<CookieModel>(OptionsBuilderConfigurationExtensions => new CookieModel(cookieName));

            string secret = tokenSection.GetValue<string>("Secret");
            services.AddScoped<AuthOptions>(options => new AuthOptions(secret));
            AuthOptions authOptions = new AuthOptions(secret);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.RequireHttpsMetadata = false; // set to true when deploy
                    options.TokenValidationParameters = new TokenValidationParameters {
                        // укзывает, будет ли валидироваться издатель при валидации токена
                        ValidateIssuer = true,
                        // строка, представляющая издателя
                        ValidIssuer = authOptions.ISSUER,

                        // будет ли валидироваться потребитель токена
                        ValidateAudience = true,
                        // установка потребителя токена
                        ValidAudience = authOptions.AUDIENCE,
                        // будет ли валидироваться время существования
                        ValidateLifetime = true,

                        // установка ключа безопасности
                        IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
                        // валидация ключа безопасности
                        ValidateIssuerSigningKey = true,
                    };
                });

            string passwordSalt = _configuration.GetValue<string>("PasswordSalt");
            services.AddScoped<DatabaseManager>(options => new DatabaseManager(
                options.GetService<ApplicationContext>(), options.GetService<AuthOptions>(), passwordSalt));

            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddControllersWithViews();
            //services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseJWTCookiesMiddleware();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
