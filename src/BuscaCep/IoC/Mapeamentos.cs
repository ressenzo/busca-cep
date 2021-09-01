using BuscaCep.Servicos.Implementacoes;
using BuscaCep.Servicos.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BuscaCep.IoC
{
    public static class Mapeamentos
    {
        public static void Mapear(IServiceCollection services)
        {
            services.AddScoped<IObterCepServico, ObterCepServico>();
        }
    }
}
