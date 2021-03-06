using System.Collections.Generic;

namespace api.Domain.Entities
{
    public class OperacaoMensalEntity
    {
        public IEnumerable<OperacaoEntity> operacoes { get; set; }
        public double Total { get; set; }
    }
}