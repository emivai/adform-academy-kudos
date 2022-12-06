using Adform.Academy.Core.Contracts.Services;
using Adform.Academy.Kudos.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Adform.Academy.Kudos.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeService, EmployeeService>();
        }
    }
}
