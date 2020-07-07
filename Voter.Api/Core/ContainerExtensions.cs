using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voter.Application;
using Voter.Application.Commands;
using Voter.Application.Queries;
using Voter.EfDataAccess;
using Voter.Implementation.Commands;
using Voter.Implementation.Queries;
using Voter.Implementation.Validators;

namespace Voter.Api.Core
{
    public static class ContainerExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<ICreateStateCommand, EfCreateStateCommand>();
            services.AddTransient<IDeleteStateCommand, EfDeleteStateCommand>();
            services.AddTransient<ICreatePersonCommand, EfCreatePersonCommand>();
            services.AddTransient<ISendMailCommand, EfSendMailCommand>();
            services.AddTransient<IUploadFileCommand, EfUploadFileCommand>();
            services.AddTransient<IDeletePersonCommand, EfDeletePersonCommand>();
            services.AddTransient<ICreateRegionCommand, EfCreateRegionCommand>();
            services.AddTransient<IDeleteRegionCommand, EfDeleteRegionCommand>();
            services.AddTransient<ICreateOptionCommand, EfCreateOptionCommand>();
            services.AddTransient<IDeleteOptionCommand, EfDeleteOptionCommand>();
            services.AddTransient<IUpdatePersonCommand, EfUpdatePersonCommand>();
            services.AddTransient<IUpdateStateCommand, EfUpdateStateCommand>();
            services.AddTransient<IUpdateRegionCommand, EfUpdateRegionCommand>();
            services.AddTransient<IUpdateOptionCommand, EfUpdateOptionCommand>();
            services.AddTransient<IGrantRoleCommand, EfGrantRoleCommand>();
            services.AddTransient<IPersonVoteCommand, EfPersonVoteCommand>();
            services.AddTransient<ICreatePartyCommand, EfCreatePartyCommand>();
            services.AddTransient<IUpdatePartyCommand, EfUpdatePartyCommand>();

            services.AddTransient<IGetStatesQuery, EfGetStatesQuery>();
            services.AddTransient<IGetRegionsQuery, EfGetRegionsQuery>();
            services.AddTransient<IGetPersonsQuery, EfGetPersonsQuery>();
            services.AddTransient<IGetOptionsQuery, EfGetOptionsQuery>();
            services.AddTransient<IGetStateQuery, EfGetStateQuery>();
            services.AddTransient<IGetRegionQuery, EfGetRegionQuery>();
            services.AddTransient<IGetOptionQuery, EfGetOptionQuery>();
            services.AddTransient<IGetPersonQuery, EfGetPersonQuery>();
            services.AddTransient<IGetVotingResults, EfGetVotingResults>();
            services.AddTransient<IGetVotingResult, EfGetVotingResult>();
            services.AddTransient<IGetPersonVoteQuery, EfGetPersonVoteQuery>();
            services.AddTransient<IGetPartysQuery, EfGetPartysQuery>();
            services.AddTransient<IGetPartyQuery, EfGetPartyQuery>();

            services.AddTransient<UseCaseExecutor>();
            services.AddTransient<CreateStateValidator>();
            services.AddTransient<CreatePersonValidator>();
            services.AddTransient<CreateRegionValidator>();
            services.AddTransient<CreateOptionValidator>();
            services.AddTransient<CreatePartyValidator>();
            services.AddTransient<UpdatePersonValidator>();
            services.AddTransient<UpdateStateValidator>();
            services.AddTransient<UpdateRegionValidator>();
            services.AddTransient<UpdateOptionValidator>();
            services.AddTransient<UpdatePartyValidator>();
            services.AddTransient<GrantRoleValidator>();
            services.AddTransient<PersonVoteValidator>();
            services.AddTransient<SendMailValidator>();
        }

        public static void AddApplicationActor(this IServiceCollection services)
        {
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    return new UnauthorizedActor();
                }

                var actorString = user.FindFirst("ActorData").Value;
                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return actor;
            });
        }

        public static void AddJwt(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddTransient<JwtManager>(x =>
            {
                var context = x.GetService<VoterContext>();

                return new JwtManager(context, appSettings.JwtIssuer, appSettings.JwtSecretKey);
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = appSettings.JwtIssuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.JwtSecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public static void AddSwager(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Voter", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });
        }
    }
}
