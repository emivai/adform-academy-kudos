using Adform.Academy.Core.Contracts.Repositories;
using Adform.Academy.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Adform.Academy.Infrastructure.Extensions
{
    public static class RepositoryExtensions
    {
        public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("postgres");

            services.AddTransient((sp) => new NpgsqlConnection(connectionString));

            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
