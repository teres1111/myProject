using Microsoft.EntityFrameworkCore;
using Entity.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Services.Repository.IRepositories;
using Services.Repository.service;
using Entity.Model;

namespace ProjectAccounting.Extention
{
    public class ConfigExtention
    {

        private IConfiguration _configuration;

        public ConfigExtention(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
                 //.AddJsonOptions(options =>
                 //{
                 //  options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
                 //});

            services.AddEndpointsApiExplorer();

            //Настройка базы данных
            services.AddDbContext<EntityConnect>(dbContextOptions =>
                dbContextOptions.UseNpgsql(_configuration.GetConnectionString("LocalConnection")));



            //Регистрация репозитория
            services.AddScoped<IRepostoryAddMetod,TransactionRepository >();

            // Настройка версий API
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            // Добавление ApiExplorer для Swagger поддержки версионирования
            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV"; // Формат версии для отображения в Swagger
                options.SubstituteApiVersionInUrl = true; // Автоматически подставляет версию в URL
            });

            // Настройка Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FirstApi", Version = "v1" });
                c.SwaggerDoc("v2", new OpenApiInfo { Title = "SecondApi", Version = "v2" });
                c.DocInclusionPredicate((version, description) =>
                {
                    if (!description.TryGetMethodInfo(out var method)) return false;

                    var apiVersions = method.DeclaringType
                        .GetCustomAttributes(typeof(ApiVersionAttribute), true)
                        .OfType<ApiVersionAttribute>()
                        .SelectMany(x => x.Versions);

                    return apiVersions.Any(v => $"v{v.MajorVersion}" == version);
                });
            });



        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment evt)
        {
            if (evt.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FirstApi");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "SecondApi");
                c.RoutePrefix = "swagger"; // Или пустая строка для корневого URL
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
