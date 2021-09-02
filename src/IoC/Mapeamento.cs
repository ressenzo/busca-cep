using Dominio.Repositorios;
using Infraestrutura.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using Servicos.Contratos;
using Servicos.Servicos;

namespace IoC
{
    public static class Mapeamento
    {
        public static void Mapear(IServiceCollection services)
        {
            MapearServicos(services);
            MapearRepositorios(services);
        }

        private static void MapearServicos(IServiceCollection services)
        {
            services.AddScoped<IObterCepServico, ObterCepServico>();
        }

        private static void MapearRepositorios(IServiceCollection services)
        {
            services.AddScoped<ICepRepositorio, CepRepositorio>();
        }
    }
}
