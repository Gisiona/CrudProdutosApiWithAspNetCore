namespace CrudProdutosApiWithAspNetCore.Dominio.Entidades
{
    public class Produto:EntidadeBase
    {           
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        
        public void Update(int id, string nome, string descricao, decimal preco, int categoriaId)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            CategoriaId = categoriaId;
            Descricao = descricao;
        }
    }
}
