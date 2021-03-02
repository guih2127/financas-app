namespace api.Models
{
    public class OperacaoModel : BaseModel
    {
        public string Nome { get; set; }
        
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public TipoOperacaoEnum TipoOperacao { get; set; }
        public CategoriaOperacaoModel CategoriaOperacao { get; set; }
    }
}