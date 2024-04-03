using PainelIndoor.Domain.Core.Entities;
using PainelIndoor.Domain.Core.Enums;
using System.Collections.Generic;

namespace PainelIndoor.Domain.Entities
{
    public class Monitores : BaseEntity<Guid>
    {
        public string CodEmpresa                    { get; set; }

        public string CodFilial                     { get; set; }

        public string ChaveCentroCusto              { get; set; }

        public string Descricao                     { get; set; }

        public TipoConteudo TipoConteudo            { get; set; }

        public bool IsEnabled                       { get; set; }

        //public virtual Filiais Filial               { get; set; }

        public ICollection<Conteudos> Conteudo      { get; set; }
    }
}
