using Invoice.Domain.Repositories;
using Invoice.Infrastructure.Persistence;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Invoice.Infrastructure.Configuration
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IDbConnection>(provider =>
            {
                var connection = new SqliteConnection("Data Source=invoice.db");
                connection.Open();
                return connection;
            });
            services.AddTransient<SqliteDbInitializer>();
            services.AddScoped<IInvoiceRepo, SqliteInvoiceRepo>();
            return services;                
        }
    }
}
