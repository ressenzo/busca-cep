using Dominio.Entidades;
using Xunit;

namespace Testes.Entidades
{
    public class CepTeste
    {
        [Theory]
        [InlineData("1234567A")]
        [InlineData("123456789")]
        [InlineData("12345 67")]
        [InlineData("1234567")]
        [InlineData("")]
        [InlineData(null)]
        public void ValidarCep_NumeroCepInvalido_EntidadeInvalida(string numeroCep)
        {
            // Arrange
            var cep = new Cep(numeroCep);

            // Assert
            Assert.False(cep.Valido);
        }

        [Theory]
        [InlineData("12345678")]
        [InlineData("12345-678")]
        [InlineData(" 12345-678 ")]
        public void ValidarCep_NumeroCepValido_EntidadeValida(string numeroCep)
        {
            // Arrange
            var cep = new Cep(numeroCep);

            // Assert
            Assert.True(cep.Valido);
        }
    }
}
