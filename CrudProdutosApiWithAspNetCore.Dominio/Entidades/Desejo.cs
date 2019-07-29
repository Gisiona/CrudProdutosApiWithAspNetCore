using Flunt.Notifications;
using Flunt.Validations;

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

        //public void Validate()
        //{
        //    AddNotifications(
        //        new Contract()
        //        .IsNotNullOrEmpty(Descricao, "Descricao","O campo descrição não permite valor nulo.")
        //        .IsGreaterThan(ProdutoId, 1,"ProdutoId", "Produto do pedido inválido")
        //        .IsGreaterThan(ProdutoId, 1,"UsuarioId", "Usuário do pedido inválido")               
        //        );
        //}
      
    }
}
