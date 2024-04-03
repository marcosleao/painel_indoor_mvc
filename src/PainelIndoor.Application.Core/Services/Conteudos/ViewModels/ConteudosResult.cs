using PainelIndoor.Application.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PainelIndoor.Application.Core.Services.Conteudos.ViewModels
{
    public class ConteudosResult
    {
        public ConteudosResult() { }

        public ConteudosResult(Application.Entities.Conteudos item)
        {
            MonitorId = item.MonitorId;
            Descricao = item.Descricao;
            TempoExibicao = item.TempoExibicao;
            Caminho = item.Caminho;
            TipoConteudo = item.TipoConteudo;
            IsEnabled = item.IsEnabled;
            _Mudo = (item.Mudo) ? "muted" : null;
            _AutoPlay = (item.AutoPlay) ? "autoplay" : null;
            _Looping = (item.Looping) ? "loop" : null;
        }

        public Guid Id { get; }

        public Guid MonitorId { get; }

        public string Descricao { get; }

        public string Caminho { get; }

        public int TempoExibicao { get; }

        public TipoConteudo TipoConteudo { get; }

        public string _TipoConteudo { get; }

        public bool IsEnabled { get; }

        public bool AutoPlay { get; }

        public string _AutoPlay { get; }

        public bool Mudo { get; }

        public string _Mudo { get; }

        public bool Looping { get; }

        public string _Looping { get; }

        public string Status { get; }

        public string Logo { get; }

        //public ProducaoTotalEducacaoLer ProducaoTotal { get; set; }

        public string OcultaVideoPlayer { get; }

        public string DesabilitaTempoExibicao { get; }

        public bool DesabilitaAlterar { get; }

        public bool DesabilitaVideoPlayar { get; }

        public bool DesabilitaUploadFile { get; }

        public string OcultaTempoExibicao { get; }

        public string OcultaCaminho { get; }

        public string OcultaUploadFile { get; }

        public string OcultaAtributosVideoLocal { get; }
    }
}
