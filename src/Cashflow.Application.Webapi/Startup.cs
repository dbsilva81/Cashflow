using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Cashflow.Infra.Implementations.DataContext;
using Cashflow.Crosscutting.Constants;
using Cashflow.Domain.Contracts.UnitOfWork;
using Cashflow.Infra.Implementations;
using Cashflow.Infra.Implementations.Repositories;
using Cashflow.Domain.Contracts.Repositories;
using Cashflow.Services.Implementations;
using Cashflow.Services.Contracts;

namespace Cashflow.Application.Webapi
{
    public class Startup
    {
        private readonly Version _version = Assembly.GetEntryAssembly().GetName().Version;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression();
            services.AddControllers(x => x.Filters.Add(new CustomExceptionFilter()));

            services.AddDbContext<CashflowDataContext>(opt => opt.UseInMemoryDatabase(ApplicationConstants.CASHFLOW_DATABASE_NAME));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = $"{_version.Major}.{_version.Minor}.{_version.Build}",
                    Title = "Cashflow API"
                });
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IFinancialTransactionRepository, FinancialTransactionRepository>();
            services.AddScoped<IFinancialTransactionService, FinancialTransactionService>(); 

        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCustomResponseMiddleware();
            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cashflow Api");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
