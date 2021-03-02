namespace api.Domain.Entities
{
    public class OperacaoEntity : BaseEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public TipoOperacaoEnum TipoOperacao { get; set; }
        
        public int CategoriaOperacaoId { get; set; }
        public CategoriaOperacaoEntity CategoriaOperacao { get; set; }
    }
}