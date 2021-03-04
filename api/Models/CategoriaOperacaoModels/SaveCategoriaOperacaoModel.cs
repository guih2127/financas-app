using System.ComponentModel.DataAnnotations;

namespace api.Models.CategoriaOperacaoModels
{
    public class SaveCategoriaOperacaoModel : BaseModel
    {
        [Required]
        [MaxLength(30)]
        public string Nome { get; set; }
    }
}