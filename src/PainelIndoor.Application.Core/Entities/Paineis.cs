using PainelIndoor.Application.Core.Entities;
using PainelIndoor.Application.Core.Enums;
using System.Collections.Generic;

namespace PainelIndoor.Application.Entities
{
    public class Paineis : BaseEntity<Guid>
    {
        public Paineis()
        {    
        }

        public string CodEmpresa { get; private set; }

        public string CodFilial { get; private set; }

        public string ChaveCentroCusto { get; private set; }

        public string Descricao { get; private set; }

        public TipoConteudo TipoConteudo { get; private set; }

        public bool IsEnabled { get; private set; }

        public virtual Filiais Filial               { get; set; }

        public ICollection<Conteudos> Conteudo { get; private set; }
    }
}
