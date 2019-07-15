using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrudProdutosApiWithAspNetCore.Dominio.Entidades
{
    public class Desejo: EntidadeBase
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

      
    }
}
