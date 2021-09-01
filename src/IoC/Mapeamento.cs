using Microsoft.Extensions.DependencyInjection;
using Servicos.Contratos;
using Servicos.Servicos;

namespace IoC
{
    public static class Mapeamento
    {
        public static void Mapear(IServiceCollection services)
        {
            services.AddScoped<IObterCepServico, ObterCepServico>();
        }
    }
}
