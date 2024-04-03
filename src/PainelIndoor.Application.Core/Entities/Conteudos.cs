using PainelIndoor.Application.Core.Entities;
using PainelIndoor.Application.Core.Enums;
using System;

namespace PainelIndoor.Application.Entities
{
    public class Conteudos : BaseEntity<Guid>
    {
        public Conteudos()
        {     
        }

        public Guid MonitorId { get; private set; }

        public string Descricao { get; private set; }

        public string Caminho { get; private set; }

        public string FilePath { get; private set; }

        public int TempoExibicao { get; private set; }

        public TipoConteudo TipoConteudo { get; private set; }

        public bool IsEnabled { get; private set; }

        public bool AutoPlay { get; private set; }

        public bool Mudo { get; private set; }

        public bool Looping { get; private set; }
    }
}
