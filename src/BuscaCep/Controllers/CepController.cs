using BuscaCep.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BuscaCep.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CepController : ControllerBase
    {
        private readonly IObterCepServico _obterCep;

        public CepController(IObterCepServico obterCep)
        {
            _obterCep = obterCep;
        }

        [HttpGet("{cep}")]
        public async Task<IActionResult> ObterInformacoesCep(string cep)
        {
            if (
                string.IsNullOrWhiteSpace(cep) ||
                cep.Any(x => char.IsLetter(x) ||
                char.IsWhiteSpace(x)) ||
                cep.Length >= 9
            )
            {
                return BadRequest("CEP inválido. Deve conter apenas números, ter, no máximo, 8 caracteres e não pode ter espaço.");
            }

            return Ok();
        }
    }
}
