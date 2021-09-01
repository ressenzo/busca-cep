using System.Collections.Generic;

namespace BuscaCep.Models
{
    public class RetornoErroModel
    {
        public string Erro { get; }

        public RetornoErroModel(string erro)
        {
            Erro = erro;
        }
    }
}
