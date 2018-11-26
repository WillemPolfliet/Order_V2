using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Order_V2.API.Controllers.Users.Mapper;
using Order_V2.API.Controllers.Users.Mapper.Interfaces;
using Order_V2.Data;
using Order_V2.Services.Users;
using Order_V2.Services.Users.Interfaces;
using Order_V2.Services.Users.Security;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Order_V2.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration;
        public readonly ILoggerFactory efLoggerFactory
          = new LoggerFactory(new[] { new ConsoleLoggerProvider((category, level) => category.Contains("Command") && level == LogLevel.Information, true) });


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info { Title = "Order_V2.Api", Version = "v1" }); });

            services.AddSingleton<ILoggerFactory>(efLoggerFactory);
            services.AddTransient<OrderDbContext>((sp) =>
            {
                var connectionString = sp.GetRequiredService<IConfiguration>().GetConnectionString("OrderDb");
                var loggerFactory = sp.GetRequiredService<ILoggerFactory>();

                return new OrderDbContext(connectionString, loggerFactory);
            });


            services.AddSingleton<IUserServices, UserServices>();
            services.AddSingleton<IAdministratorMapper, AdministratorMapper>();
            services.AddSingleton<ICustomerMapper, CustomerMapper>();
            services.AddSingleton<IAddressMapper, AddressMapper>();
            services.AddSingleton<ICityMapper, CityMapper>();
            services.AddSingleton<IUserMapper, UserMapper>();
            services.AddSingleton<IWorkplaceMapper, WorkplaceMapper>();
            services.AddSingleton<ILoginMapper, LoginMapper>();

            services.AddSingleton<Hasher>().AddSingleton<Salter>().AddSingleton<UserAuthenticationServices>();
            services.AddCors();
            var key = Encoding.ASCII.GetBytes(UserAuthenticationServices.SECRET_KEY);

            services
                .AddAuthorization(options => {
                    options.AddPolicy("AdminOnly", policy => policy.RequireClaim(ClaimTypes.Email, "admin@admin.com"));

                    // kan ik ook een claim leggen op de Discriminator ???
                })
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseCors(x => x
              .AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials());

            app.UseAuthentication();


            app.UseMvc();
            app.Run(async context =>
            {
                context.Response.Redirect("/swagger");
            });

        }
    }
}
