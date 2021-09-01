using Servicos.Servicos;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Testes.Servicos
{
    public class ObterCepServicoTeste
    {
        [Theory]
        [InlineData("1234567A")]
        [InlineData("123456789")]
        [InlineData("12345 67")]
        [InlineData("")]
        [InlineData(null)]
        public async Task ValidarCep_CepInvalido_ArgumentException(string cep)
        {
            // Arrange
            var obterCepServico = Servico;

            // Assert
            await Assert.ThrowsAsync<ArgumentException>(
                // Act
                async() => await obterCepServico.ObterCep(cep)
            );
        }

        private ObterCepServico Servico
        {
            get
            {
                return new ObterCepServico();
            }
        }
    }
}
