using Invoice.Application.UseCases.Invoices.Commands.CreateInvoice;
using Invoice.Application.UseCases.Invoices.Commands.DeleteInvoice;
using Invoice.Application.UseCases.Invoices.Queries.GetInvoice;
using Invoice.Application.UseCases.Invoices.Queries.GetInvoices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Application.Configuration
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateInvoiceUseCase, CreateInvoiceUseCase>();
            services.AddScoped<IDeleteInvoiceUseCase, DeleteInvoiceUseCase>();
            services.AddScoped<IGetInvoicesUseCase, GetInvoicesUseCase>();
            services.AddScoped<IGetInvoiceUseCase, GetInvoiceUseCase>();
            return services;
        }
    }
}
