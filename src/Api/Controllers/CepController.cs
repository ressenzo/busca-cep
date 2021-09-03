using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servicos.Contratos;
using System;
using System.Threading.Tasks;
using Dominio.Entidades;
using Api.Models;
using AutoMapper;

namespace Api.Controllers
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

        /// <summary>
        /// Obtém informações de CEP
        /// </summary>
        /// <param name="cep">CEP</param>
        /// <returns>O Objeto Cep contendo as informações do CEP passado</returns>
        /// <response code="200">Informações do CEP</response>
        /// <response code="204">CEP não encontrado</response>
        /// <response code="400">Requisição inválida</response>
        /// <response code="500">Ocorreu um problema interno</response>
        [HttpGet("{cep}")]
        [ProducesResponseType(typeof(RetornoCepModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(RetornoErroModel), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(RetornoErroModel), StatusCodes.Status500InternalServerError)]
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
