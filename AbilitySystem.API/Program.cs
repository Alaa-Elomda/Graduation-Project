
using AbilitySystem.API.Controllers.Helpers;
using AbilitySystem.BL;
using AbilitySystem.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;


namespace AbilitySystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            #region default
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #endregion

            #region Context

            var connectionString = builder.Configuration.GetConnectionString("AbilityDb");

            #region AbilityContext
            builder.Services.AddDbContext<AbilityContext>(options =>
                options.UseSqlServer(connectionString));
            #endregion

            #endregion

            #region Identity Manager

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                // options.Password.RequiredUniqueChars = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 4;
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<AbilityContext>();
                 // .AddDefaultTokenProviders();

            #endregion


            #region Services
            builder.Services.AddScoped<IHelper, Helper>();
            builder.Services.AddScoped<ICategoriesRepo, CategoriesRepo>();
            builder.Services.AddScoped<ICategoriesManager, CategoriesManager>();

            builder.Services.AddScoped<IProductsRepo, ProductsRepo>();
            builder.Services.AddScoped<IProductsManager, ProductsManager>();

            builder.Services.AddScoped<IUsersRepo, UsersRepo>();
            builder.Services.AddScoped<IUsersManager, UsersManager>();

            builder.Services.AddScoped<IAdminsRepo, AdminsRepo>();
            builder.Services.AddScoped<IAdminsManager, AdminsManager>();

            builder.Services.AddScoped<IOrdersRepo, OrdersRepo>();
            builder.Services.AddScoped<IOrdersManager, OrdersManager>();

            builder.Services.AddScoped<ICategoriesRepo, CategoriesRepo>();
            builder.Services.AddScoped<ICategoriesManager, CategoriesManager>();

            builder.Services.AddScoped<IProductsRepo, ProductsRepo>();
            builder.Services.AddScoped<IProductsManager, ProductsManager>();

            builder.Services.AddScoped<ICartsRepo, CartsRepo>();
            builder.Services.AddScoped<ICartsManager, CartsManager>();

            //builder.Services.AddScoped<IWishlistRepo, WishlistRepo>();
            //builder.Services.AddScoped<IWishlistManager, WishlistManager>();
            #endregion




            #region Authentication

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "UserSchema";
                options.DefaultChallengeScheme = "UserSchema";
            })
                .AddJwtBearer("UserSchema", options =>
                {
                    var secretKeyString = builder.Configuration.GetValue<string>("SecretKey") ?? "";
                    var secretKyInBytes = Encoding.ASCII.GetBytes(secretKeyString);
                    var securityKey = new SymmetricSecurityKey(secretKyInBytes);

                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        IssuerSigningKey = securityKey,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

            #endregion

            #region Authorization

            builder.Services.AddAuthorization(options =>
            {
                //options.AddPolicy("AllowAdminOnly",
                //    builder => builder.RequireClaim(ClaimTypes.Role, "Admin"));

                //options.AddPolicy("AllowUsers",
                //    builder => builder.RequireClaim(ClaimTypes.Role, "User", "Admin"));

                options.AddPolicy("AdminOnly", policy =>
            policy.RequireRole("Admin"));

                options.AddPolicy("UserOnly", policy =>
                    policy.RequireRole("User"));
            });

            #endregion

            var app = builder.Build();

            #region MiddleWares

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(builder.Environment.ContentRootPath + "/Images"),
                RequestPath = "/Images"
            });

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
            #endregion
        }
    }
}