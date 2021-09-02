using System.Collections.Generic;

namespace Dominio.Entidades
{
    public abstract class BaseEntidade
    {
        public bool Valido
        {
            get
            {
                return string.IsNullOrWhiteSpace(Mensagem);
            }
        }
        public string Mensagem { get; set; } = null;

        protected void AdicionarMensagem(string mensagem)
        {
            Mensagem = mensagem;
        }
    }
}
