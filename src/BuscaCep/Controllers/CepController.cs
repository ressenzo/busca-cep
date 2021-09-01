using BuscaCep.Servicos.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BuscaCep.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CepController : ControllerBase
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
            catch (Exception excecao)
            {
                return StatusCode((int)StatusCodes.Status500InternalServerError, excecao.Message);
            }            
        }
    }
}
