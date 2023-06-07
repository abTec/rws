using Application.Contracts;
using Application.CQRS.CommandHandlers;
using AutoMapper;
using DataAccess;
using DataAccess.Repositories;
using External.ThirdParty.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace TranslationManagement.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            RegisterServices(services);

            services.AddControllers()
                .AddNewtonsoftJson();

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "TranslationManagement.Api",
                    Version = "v1.1",
                    Description = "An ASP.NET Core Web API for managing Translation altered for RWS interview process purposes. For more info write to <a href=\"mailto:hello@abtec.cz\">hello@abtec.cz</a>"
                });
                opt.SchemaFilter<EnumSchemaFilter>();
            });

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite("Data Source=TranslationAppDatabase.db"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TranslationManagement.Api v1"));

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ITranslationJobRepository, TranslationJobRepository>();
            services.AddScoped<ITranslatorRepository, TranslatorRepository>();
            services.AddScoped<INotificationService, UnreliableNotificationService>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateTranslationJobHandler>());
            IMapper mapper = AutoMapperConfiguration.ConfigureMapping().CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}