using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PainelIndoor.Application.Core.Entities
{
    public class Filiais : BaseEntity<Guid>
    {
        public Filiais() { }

        public string CodFilial { get; private set; }
        public int? FiliaiSgeId { get; private set; }
        public string CodEmpresa { get; private set; }
        public string NomeFilial { get; private set; }
        public string CnpjFilial { get; private set; }
        public string ChaveCentroCusto { get; private set; }
        public string Endereco { get; private set; }
        public bool IsVirtual { get; private set; }
        public bool IsEnabled { get; private set; }
    }
}
