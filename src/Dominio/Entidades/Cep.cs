using System.Linq;

namespace Dominio.Entidades
{
    public class Cep : BaseEntidade
    {
        public string Numero { get; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string Uf { get; set; }
        public string Ibge { get; set; }
        public string Gia { get; set; }
        public string Ddd { get; set; }
        public string Siafi { get; set; }

        public Cep(string numero)
        {
            numero = numero?.Trim().Replace("-", "");

            if (
                string.IsNullOrWhiteSpace(numero) ||
                numero.Any(x => !char.IsDigit(x)) ||
                numero.Length != 8
            )
            {
                AdicionarMensagem("CEP inválido. Deve conter apenas números, ter 8 caracteres e não pode ter espaço.");
            }
            else
            {
                Numero = numero;
            }
        }
    }
}
