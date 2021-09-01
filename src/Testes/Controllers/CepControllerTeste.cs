using BuscaCep.Controllers;
using BuscaCep.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Testes.Controllers
{
    public class CepControllerTeste
    {
        private readonly Mock<IObterCepServico> _obterCepServico;

        public CepControllerTeste()
        {
            _obterCepServico = new Mock<IObterCepServico>();
        }

        [Fact]
        public async Task BadRequest()
        {
            // Arrange
            var cepController = Controller;
            _obterCepServico.Setup(x => x.ObterCep(It.IsAny<string>()))
                .Throws(new ArgumentException());

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

        private CepController Controller
        {
            get
            {
                return new CepController(_obterCepServico.Object);
            }
        }
    }
}
