using System.ComponentModel.DataAnnotations;

namespace api.Models.OperacaoModels
{
    public class SaveOperacaoModel : BaseModel
    {
        [Required]
        [MaxLength(30)]
        public string Nome { get; set; }

        [MaxLength(150)]
        public string Descricao { get; set; }

        [Required]
        public TipoOperacaoEnum TipoOperacao { get; set; }

        [Required]
        public int CategoriaOperacaoId { get; set; }

        [Required]
        public double Valor { get; set; }
    }
}