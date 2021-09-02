using RestSharp;
using System.Threading.Tasks;

namespace Infraestrutura.Repositorios
{
    public abstract class RestBaseRepositorio
    {
        private readonly string _url;

        public RestBaseRepositorio(string urlBase)
        {
            _url = urlBase;
        }

        protected async Task<T> GetAsync<T>(string recurso)
        {
            var cliente = new RestClient(_url);
            var requisicao = new RestRequest(recurso);

            var resposta = await cliente.GetAsync<T>(requisicao);

            return resposta;
        }
    }
}
