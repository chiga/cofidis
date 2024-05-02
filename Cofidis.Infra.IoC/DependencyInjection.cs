using Cofidis.Application.Interfaces;
using Cofidis.Application.Services;
using Cofidis.Domain.Interfaces;
using Cofidis.Infra.Data.Context;
using Cofidis.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cofidis.Infra.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        services.AddScoped<ICreditLimitRepository, CreditLimitRepository>();
        services.AddScoped<IRiskService, RiskService>();
        services.AddScoped<ILoanService, LoanService>();

        return services;
    }
}