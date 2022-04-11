using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using FluentValidation.AspNetCore;
using Teste.Api.Helper;
using Teste.Api.Services.Interface;
using Teste.Api.Services;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.OpenApi.Models;
using Teste.Api.Options;
using System.Collections.Generic;

namespace Teste.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomVersioning(this IServiceCollection services)
        {
            services
                .AddApiVersioning(opt =>
                {
                    opt.DefaultApiVersion = new ApiVersion(1, 0);
                    opt.ReportApiVersions = true;
                    opt.AssumeDefaultVersionWhenUnspecified = true;

                    opt.ApiVersionReader = ApiVersionReader.Combine(
                        new QueryStringApiVersionReader("api-version"),
                        new HeaderApiVersionReader("api-version"),
                        new UrlSegmentApiVersionReader());
                })
                .AddVersionedApiExplorer(opt =>
                {
                    opt.GroupNameFormat = "'v'VVV";
                    opt.SubstituteApiVersionInUrl = true;
                });

            return services;
        }
        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            services.AddOptions()
                .AddControllers(options =>
                {
                })
                .AddJsonOptions(c => c.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
                //.AddFluentValidation(opt =>
                //{
                //    opt.RegisterValidatorsFromAssemblies(AssemblyHelper.GetMyAssemblies());
                //    opt.ValidatorFactoryType = typeof(ScopedServiceProviderValidatorFactory);
                //});

            return services;
        }

        public static IServiceCollection AddCustomIoC(this IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
            return services;
        }

        public static IServiceCollection AddHttpClientFactory(this IServiceCollection services, IConfiguration configuration)
        {
            //var TesteApi = configuration.GetSection(TesteApi.Key).Get<TesteApiOptions>();
            services.AddHttpClient("HttpClientTesteApi", config =>
            {
                config.Timeout = TimeSpan.FromMinutes(15);
                //config.BaseAddress = new System.Uri(TesteApi.URL);
                //var autentication = Encoding.ASCII.GetBytes(TesteApi.Username + ":" + TesteApi.Password);
                //config.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(autentication));
            }).SetHandlerLifetime(TimeSpan.FromMinutes(15))
            .ConfigurePrimaryHttpMessageHandler(x =>
                new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                });

            return services;
        }
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services,
            IConfiguration configuration, Action<SwaggerGenOptions> customSetupAction = null)
        {
            services.Configure<Options.SwaggerOptions>(configuration.GetSection(Options.SwaggerOptions.Key));
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(options =>
            {
                //options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    Description =
                //        "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                //    Name = "Authorization",
                //    In = ParameterLocation.Header,
                //    Type = SecuritySchemeType.ApiKey,
                //    Scheme = "Bearer"
                //});

                options.OperationFilter<SwaggerDefaultValues>();

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });

                options.EnableAnnotations();
                customSetupAction?.Invoke(options);
            });

            return services;
        }
        
    }
}