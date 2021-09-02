using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicos.Contratos;
using System;
using System.Threading.Tasks;
using System.Data;

namespace BuscaCep.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CepController : BaseController
    {
        private readonly IObterCepServico _obterCepServico;

        public CepController(IObterCepServico obterCep)
        {
            _obterCepServico = obterCep;
        }

        [HttpGet("{cep}")]
        public async Task<IActionResult> ObterInformacoesCep(string cep)
        {
            try
            {
                await _obterCepServico.ObterCep(cep);

                return Ok();
            }
            catch (ArgumentException excecao)
            {
                return BadRequest(excecao.Message);
            }
            catch (InvalidOperationException)
            {
                return NoContent();
            }
            catch (Exception excecao)
            {
                return StatusCode((int)StatusCodes.Status500InternalServerError, excecao.Message);
            }            
        }
    }
}
