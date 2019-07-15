using System;

namespace CrudProdutosApiWithAspNetCore.Dominio.Entidades
{
    public abstract class EntidadeBase
    {
        public Guid HashId { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime DataAlteracao { get; private set; }
        public bool IsAtivo { get; set; }

        public EntidadeBase()
        {
            HashId = Guid.NewGuid();
            DataCadastro = DateTime.Now;
            DataAlteracao = DateTime.Now;
            IsAtivo = true;
        }
    }
}
