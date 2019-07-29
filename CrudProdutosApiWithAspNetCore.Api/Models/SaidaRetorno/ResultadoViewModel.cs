namespace CrudProdutosApiWithAspNetCore.Api.Models.SaidaRetorno
{
    public class ResultadoViewModel
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public object Data { get; set; }
        public int StatusCode { get; set; }
    }
}
