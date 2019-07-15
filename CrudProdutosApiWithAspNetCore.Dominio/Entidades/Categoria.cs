using System.Collections.Generic;

namespace CrudProdutosApiWithAspNetCore.Dominio.Entidades
{
    public class Categoria: EntidadeBase
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        

        public ICollection<Produto> Produtos { get; set; }
        
        public void Update(int _id, string _nome, string _descricao)
        {
            Id = _id;
            Nome = _nome;
            Descricao = _descricao;
            
        }
    }
}
