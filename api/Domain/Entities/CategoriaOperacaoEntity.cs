using System.Collections.Generic;

namespace api.Domain.Entities
{
    public class CategoriaOperacaoEntity : BaseEntity
    {
        public string Nome { get; set; }
        public IEnumerable<OperacaoEntity> Operacoes;
    }
}