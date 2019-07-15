using CrudProdutosApiWithAspNetCore.Dominio.Entidades;

namespace CrudProdutosApiWithAspNetCore.Api.Models.Produtos
{
    public class ProdutosModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }
        public string CategoriaNome { get; set; }
    }


    public static class ProdutosGetExtension
    {
        public static ProdutosModel ToProdutoGet(this Produto p)
        {
            return new ProdutosModel
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco,
                Descricao = p.Descricao,
                CategoriaId = p.CategoriaId,
                CategoriaNome = p.Categoria?.Nome
            };
        }

        public static ProdutosModel ToProdutoEdit(this Produto p)
        {
            return new ProdutosModel
            {
                Id = p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao,
                Preco = p.Preco,
                CategoriaId = p.CategoriaId               
            };
        }


        public static ProdutosModel ToProdutoAdd(this Produto p)
        {
            return new ProdutosModel
            {
                Nome = p.Nome,
                Descricao = p.Descricao,
                Preco = p.Preco,
                CategoriaId = p.CategoriaId,
            };
        }


        public static Produto ToProduto(this Produto p)
        {
            return new Produto
            {
                Id = p.Id,
                Nome = p.Nome,
                Descricao = p.Descricao,
                Preco = p.Preco,
                CategoriaId = p.CategoriaId,
                IsAtivo = p.IsAtivo
            };
        }
    }
}
