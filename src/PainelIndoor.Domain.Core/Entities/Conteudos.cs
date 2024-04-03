using PainelIndoor.Domain.Core.Entities;
using PainelIndoor.Domain.Core.Enums;
using System;

namespace PainelIndoor.Domain.Entities
{
    public class Conteudos : BaseEntity<Guid>
    {
        public Guid MonitorId                       { get; set; }

        public string Descricao                     { get; set; }

        public string Caminho                       { get; set; }

        public string FilePath                      { get; set; }

        public int TempoExibicao                    { get; set; }

        public TipoConteudo TipoConteudo            { get; set; }

        public bool IsEnabled                       { get; set; }

        public bool AutoPlay                        { get; set; }

        public bool Mudo                            { get; set; }

        public bool Looping                         { get; set; }
    }
}
