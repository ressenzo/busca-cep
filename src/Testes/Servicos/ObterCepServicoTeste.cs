using Dominio.Entidades;
using Dominio.Repositorios;
using Moq;
using Servicos.Servicos;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Testes.Servicos
{
    public class ObterCepServicoTeste
    {
        private readonly Mock<ICepRepositorio> _cepRepositorio;

        public ObterCepServicoTeste()
        {
            _cepRepositorio = new Mock<ICepRepositorio>();
        }

        [Theory]
        [InlineData("1234567A")]
        [InlineData("123456789")]
        [InlineData("12345 67")]
        [InlineData("1234567")]
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

        [Fact]
        public async Task ObterCep_CepEncontrado_EntidadePreenchida()
        {
            // Arrange
            _cepRepositorio.Setup(x => x.ObterCep(It.IsAny<string>()))
                .ReturnsAsync(new Cep("12345678"));
            var obterCepServico = Servico;

            //Act
            var cep = await obterCepServico.ObterCep("12345678");

            // Assert
            Assert.NotNull(cep.Numero);
            Assert.True(cep.Valido);
        }

        [Fact]
        public async Task ObterCep_CepNaoEncontrado_InvalidException()
        {
            // Arrange
            var obterCepServico = Servico;
            _cepRepositorio.Setup(x => x.ObterCep(It.IsAny<string>()))
                .ReturnsAsync(new Cep(null));

            // Assert
            await Assert.ThrowsAsync<InvalidOperationException>(
                // Act
                async () => await obterCepServico.ObterCep("12345678")
            );
        }

        private ObterCepServico Servico
        {
            get
            {
                return new ObterCepServico(_cepRepositorio.Object);
            }
        }
    }
}
