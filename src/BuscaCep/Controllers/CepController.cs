using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicos.Contratos;
using System;
using System.Threading.Tasks;
using System.Data;
using Dominio.Entidades;
using BuscaCep.Models;

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
        [ProducesResponseType(typeof(Cep), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoErroModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
