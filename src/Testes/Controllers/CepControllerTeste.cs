using BuscaCep.Controllers;
using BuscaCep.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
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

        [Theory]
        [InlineData("1234567A")]
        [InlineData("123456789")]
        [InlineData("12345 67")]
        [InlineData("")]
        [InlineData(null)]
        public async Task ValidarCep_CepInvalido_BadRequest(string cep)
        {
            // Arrange
            var cepController = Controller;

            // Act
            var resultado = await cepController.ObterInformacoesCep(cep);

            // Assert
            Assert.IsType<BadRequestObjectResult>(resultado);
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
