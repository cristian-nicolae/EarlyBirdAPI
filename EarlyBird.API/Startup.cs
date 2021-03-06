using AutoMapper;
using EarlyBird.API.Hubs;
using EarlyBird.API.Utils;
using EarlyBird.BusinessLogic.Services;
using EarlyBird.BusinessLogic.Services.Interfaces;
using EarlyBird.BusinessLogic.Utils;
using EarlyBird.DataAccess;
using EarlyBird.DataAccess.Repositories;
using EarlyBird.DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EarlyBird.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AuthorizationSettings>(Configuration.GetSection("AuthorizationSettings"));

            string dbEnvVar;
            if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
                dbEnvVar = File.ReadAllText("DoNotUploadToGit.txt");
            else
                dbEnvVar = Environment.GetEnvironmentVariable("DATABASE_URL");

            //parse database URL. Format is postgres://<username>:<password>@<host>/<dbname>
            var uri = new Uri(dbEnvVar);
            var username = uri.UserInfo.Split(':')[0];
            var password = uri.UserInfo.Split(':')[1];
            var host = uri.Host;
            var port = uri.Port;
            var database = uri.LocalPath.TrimStart('/');
            var connectionString =
                "Host=" + host +
                ";Port=" + port +
                ";Database=" + database +
                ";Username=" + username +
                ";Password=" + password +
                ";SSLMode=Require;" +
                "TrustServerCertificate=True;";
            services.AddDbContextPool<EarlyBirdContext>(options => options.UseNpgsql(connectionString));


            services.AddControllers();
            services.AddCors();
            services.AddAuthServices(Configuration);

            services.AddRepositories();
            services.AddServices();


            services.AddScoped(provider => new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile(provider.GetService<IUsersRepository>()));
            }).CreateMapper());

            services.AddSwagger();
            services.AddSignalR();
            services.AddSingleton<IUserIdProvider, UserIdProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EarlyBird.API v1"));

            app.UseCors(x => x.AllowAnyHeader()
                                .AllowAnyMethod()
                                .WithOrigins("http://localhost:3000", 
                                             "https://early-birds.firebaseapp.com", 
                                             "https://early-birds.web.app")
                                .AllowCredentials()); // This represents the policy.

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/chat");
            });
        }


    }

    #region Extensions
    public static class ServicesExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<IConversationsRepository, ConversationsRepository>();
            services.AddScoped<IMessagesRepository, MessagesRepository>();
            services.AddScoped<IOffersRepository, OffersRepository>();
            services.AddScoped<IReviewsRepository, ReviewsRepository>();
            services.AddScoped<IOfferCategoryRepository, OfferCategoryRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<ICategoriesService, CategoriesService>();
            services.AddScoped<IOffersService, OffersService>();
            services.AddScoped<IReviewsService, ReviewsService>();
            services.AddScoped<IConversationsService, ConversationsService>();
            services.AddScoped<IMessagesService, MessagesService>();
        }

        public static void AddAuthServices(this IServiceCollection services, IConfiguration configuration)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            string secret = configuration["AuthorizationSettings:Secret"];
            if (env != "Development")
                secret = Environment.GetEnvironmentVariable("AUTH_SECRET");

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = false,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["AuthorizationSettings:Issuer"],
                        ValidAudience = configuration["AuthorizationSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                        ClockSkew = TimeSpan.Zero
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query["access_token"];

                            // If the request is for our hub...
                            var path = context.HttpContext.Request.Path;
                            if (!string.IsNullOrEmpty(accessToken) &&
                                (path.StartsWithSegments("/chat")))
                            {
                                // Read the token out of the query string
                                context.Token = accessToken;
                            }
                            return Task.CompletedTask;
                        }
                    };
                });
            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.Admin, builder => builder.RequireClaim(Claims.Admin, "true"));
                options.AddPolicy(Policies.Worker, builder => builder.RequireClaim(Claims.Worker, "true"));
                options.AddPolicy(Policies.Publisher, builder => builder.RequireClaim(Claims.Publisher, "true"));
                options.AddPolicy(Policies.All, builder => builder.RequireClaim(Claims.All, "true"));
            });
        }

        public static void AddSwagger(this IServiceCollection services)
        {

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EarlyBird.API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Insert jwt",
                    Name = "Bearer",
                    BearerFormat = "JWT",
                    Scheme = "bearer",
                    Type = SecuritySchemeType.Http
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });
        }
    }
    #endregion
}
