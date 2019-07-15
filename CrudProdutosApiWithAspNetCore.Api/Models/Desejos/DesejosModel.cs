using CrudProdutosApiWithAspNetCore.Dominio.Entidades;

namespace CrudProdutosApiWithAspNetCore.Api.Models.Desejos
{
    public class DesejosModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int ProdutoId { get; set; }
        public string ProdutoName { get; set; }
        public int UsuarioId { get; set; }
        public string UsuarioName { get; set; }
    }

    public static class DesejosGetExtension
    {
        public static Desejo ToProduto(this Desejo p)
        {
            return new Desejo
            {
                Id = p.Id,              
                Descricao = p.Descricao,
                UsuarioId = p.UsuarioId,
                ProdutoId = p.ProdutoId,                
                IsAtivo = p.IsAtivo
            };
        }
    }


}
