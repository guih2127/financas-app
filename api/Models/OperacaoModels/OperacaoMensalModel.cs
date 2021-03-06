using System.Collections.Generic;

namespace api.Models.OperacaoModels
{
    public class OperacaoMensalModel
    {
        public IEnumerable<OperacaoModel> operacoes { get; set; }
        public double Total { get; set; }
    }
}