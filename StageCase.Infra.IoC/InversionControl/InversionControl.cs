using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StageCase.Application.Contracts;
using StageCase.Application.Services;
using StageCase.Domain.Contracts;
using StageCase.Infra.Data;
using StageCase.Infra.Data.Repositories;

namespace StageCase.Infra.IoC.InversionControl
{
    public static class InversionControl
    {
        public static void AddInfraestructure(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<Context>(
                context => context.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );

            serviceCollection.AddScoped<IProcessService, ProcessService>();
            serviceCollection.AddScoped<IProcessTypeService, ProcessTypeService>();

            serviceCollection.AddScoped<IGeneralRepository, GeneralRepository>();
            serviceCollection.AddScoped<IProcessRepository, ProcessRepository>();
            serviceCollection.AddScoped<IProcessTypeRepository, ProcessTypeRepository>();
        }
    }
}
