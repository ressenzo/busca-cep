using AutoMapper;
using Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Servicos.Contratos;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Testes.Controllers
{
    public class CepControllerTeste
    {
        private readonly Mock<IObterCepServico> _obterCepServico;
        private readonly Mock<IMapper> _mapper;

        public CepControllerTeste()
        {
            _obterCepServico = new Mock<IObterCepServico>();
            _mapper = new Mock<IMapper>();
        }

        [Fact]
        public async Task BadRequest()
        {
            // Arrange
            var cepController = Controller;
            _obterCepServico.Setup(x => x.ObterCep(It.IsAny<string>()))
                .Throws(new ArgumentException("Erro de requisição."));

            // Act
            var resultado = await cepController.ObterInformacoesCep(It.IsAny<string>());

            // Assert
            Assert.IsType<BadRequestObjectResult>(resultado);
        }

        [Fact]
        public async Task InternalServerError()
        {
            // Arrange
            var cepController = Controller;
            _obterCepServico.Setup(x => x.ObterCep(It.IsAny<string>()))
                .Throws(new Exception());

            // Act
            var resultado = await cepController.ObterInformacoesCep(It.IsAny<string>());

            // Assert
            Assert.IsType<ObjectResult>(resultado);
        }

        [Fact]
        public async Task NoContent()
        {
            // Arrange
            var cepController = Controller;
            _obterCepServico.Setup(x => x.ObterCep(It.IsAny<string>()))
                .Throws(new InvalidOperationException());

            // Act
            var resultado = await cepController.ObterInformacoesCep(It.IsAny<string>());

            // Assert
            Assert.IsType<NoContentResult>(resultado);
        }

        private CepController Controller
        {
            get
            {
                return new CepController(
                    _obterCepServico.Object,
                    _mapper.Object
                    );
            }
        }
    }
}
