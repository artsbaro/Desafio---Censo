using Censo.Application.Interfaces;
using Censo.Application.Mappers.Pessoas;
using Censo.Application.Services;
using Censo.Domain.Interfaces.Repositories;
using Censo.Domain.Services;
using Censo.Domain.Services.Interfaces;
using Censo.Infra.Data.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Censo.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IHostingEnvironment>(new HostingEnvironment());

            // Mappers
            services.AddSingleton<IPessoaDtoMapper, PessoaDtoMapper>();
            services.AddSingleton<IPessoaMapper, PessoaMapper>();

            //DomainServices            
            services.AddScoped<IPessoaDomainService, PessoaDomainService>();
            services.AddScoped<IEscolaridadeDomainService, EscolariadeDomainService>();
            services.AddScoped<IGeneroDomainService, GeneroDomainService>();
            services.AddScoped<IEtniaDomainService, EtniaDomainService>();

            //AppServices
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<IEscolaridadeService, EscolaridadeService>();
            services.AddScoped<IGeneroService, GeneroService>();
            services.AddScoped<IEtniaService, EtniaService>();

            // Infra - Data
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IGeneroRepository, GeneroRepository>();
            services.AddScoped<IEtniaRepository, EtniaRepository>();
            services.AddScoped<IEscolaridadeRepository, EscolaridadeRepository>();
        }
    }
}