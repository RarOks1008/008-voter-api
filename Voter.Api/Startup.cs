using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Voter.Api.Core;
using Voter.Application;
using Voter.Application.Commands;
using Voter.Application.Email;
using Voter.Application.Queries;
using Voter.EfDataAccess;
using Voter.Implementation.Commands;
using Voter.Implementation.Email;
using Voter.Implementation.Logging;
using Voter.Implementation.Queries;
using Voter.Implementation.Validators;

namespace Voter.Api
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
            var appSettings = new AppSettings();

            Configuration.Bind(appSettings);

            services.AddUseCases();
            services.AddTransient<VoterContext>();

            services.AddHttpContextAccessor();
            services.AddApplicationActor();
            services.AddTransient<IUseCaseLogger, DatabaseUseCaseLogger>();
            services.AddJwt(appSettings);
            services.AddTransient<IEmailSender, SmtpEmailSender>( x => new SmtpEmailSender(appSettings.EmailFrom, appSettings.EmailPassword));

            services.AddControllers();
            services.AddAutoMapper(typeof(EfGetStatesQuery).Assembly);

            services.AddSwager();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(x =>
            {
                x.AllowAnyOrigin();
                x.AllowAnyMethod();
                x.AllowAnyHeader();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger");
            });

            app.UseRouting();

            app.UseMiddleware<GlobalExceptionHandler>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
