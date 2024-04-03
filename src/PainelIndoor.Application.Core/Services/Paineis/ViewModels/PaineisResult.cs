using PainelIndoor.Application.Core.Enums;
using PainelIndoor.Application.Core.Services.Conteudos.ViewModels;
using PainelIndoor.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PainelIndoor.Application.Core.Services.Paineis.ViewModels
{
    public class PaineisResult
    {
        public PaineisResult(Application.Entities.Paineis item)
        {
            Id = item.Id;
            TipoConteudo = item.TipoConteudo;
            CodEmpresa = item.CodEmpresa;
            CodFilial = item.CodFilial;
            Filial = item.Filial?.NomeFilial;
            ChaveCentroCusto = item.ChaveCentroCusto;
            Descricao = item.Descricao;
            Logo = (item.CodFilial.Substring(0, 4) == "02MT") ? "https://sesimt.ind.br/assets/images/logo-sesi.png" :
                    "https://www.senaimt.ind.br/assets/images/logo-senai.png";
            PoliticaQualidade = "";// PoliticaQualidade(m.CodEmpresa),
            IsEnabled = item.IsEnabled;
            _TipoConteudo = EnumTipoConteudo.Descricao(item.TipoConteudo);
            Ativo = (item.IsEnabled) ? "SIM" : "NÃO";
            Conteudos = item.Conteudo?.Select(c => new ConteudosResult(c));
        }

        public Guid Id { get; }
        public string CodEmpresa { get; }
        public string CodFilial { get; }
        public string Filial { get; }
        public string ChaveCentroCusto { get; }
        public string Descricao { get; }
        public string Logo { get; }
        public string PoliticaQualidade { get; }
        public TipoConteudo TipoConteudo { get; }
        public string _TipoConteudo { get; }
        public bool IsEnabled { get; }
        public string Ativo { get; }
        public IEnumerable<ConteudosResult> Conteudos { get; }

        public ConteudosRequest Alterar { get; set; }

        public ConteudosRequest Adicionar { get; set; }

       // public ProducaoTotalEducacaoLer ProducaoTotal { get; set; }

        //public IEnumerable<ProducaoEducacaoPorModalidadeLer> ProducaoPorModalidade { get; set; }
    }
}
