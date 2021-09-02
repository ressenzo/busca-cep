using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicos.Contratos;
using System;
using System.Threading.Tasks;
using System.Data;
using Dominio.Entidades;
using BuscaCep.Models;
using AutoMapper;

namespace BuscaCep.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CepController : BaseController
    {
        private readonly IObterCepServico _obterCepServico;
        private readonly IMapper _mapper;

        public CepController(
            IObterCepServico obterCep,
            IMapper mapper
            )
        {
            _obterCepServico = obterCep;
            _mapper = mapper;
        }

        [HttpGet("{cep}")]
        [ProducesResponseType(typeof(RetornoCepModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoErroModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterInformacoesCep(string cep)
        {
            try
            {
                var cepRetornado = await _obterCepServico.ObterCep(cep);

                return Ok(_mapper.Map<Cep, RetornoCepModel>(cepRetornado));
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
                return StatusCode(StatusCodes.Status500InternalServerError, excecao.Message);
            }            
        }
    }
}
