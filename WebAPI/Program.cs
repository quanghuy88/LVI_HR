using Utility;
using Application.Authentication;
using Microsoft.Extensions.Configuration;
using Infrastructure.Data;
using Repository;
using Application.Authorization;
using Application.Services;
using Microsoft.AspNetCore.Diagnostics;
using WebAPI.BuilderExtensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.RegisterServiceInjection(builder.Services.AddSingleton, builder.Services.AddScoped, builder.Services.AddTransient);
            builder.Services.AddJWTTokenServices(builder.Configuration);
            builder.Services.AddPermissionPolicyAuthorization();
            builder.Services.AddExternalDbContexts(builder.Configuration);
            builder.Services.AddExternalDbRepositories();
            builder.Services.AddBusinessServices();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                                  });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            //app.UseAuthorization();
            //app.UseExceptionHandlerMiddleware();
            app.UseCors(MyAllowSpecificOrigins);

            app.Run();
        }
    }
}