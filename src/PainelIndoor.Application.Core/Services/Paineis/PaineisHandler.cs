using PainelIndoor.Application.Core.Interfaces;
using PainelIndoor.Application.Core.Services.Paineis.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PainelIndoor.Application.Core.Services.Paineis
{
    public class PaineisHandler : IPaineisService
    {
        private readonly IPaineisRepository _paineisRepository;
        public PaineisHandler(IPaineisRepository paineisRepository)
        {
            _paineisRepository = paineisRepository;
        }

        public async Task<PaineisInicio> ListarAsync(PaineisPrmtsPesquisa prmts, CancellationToken cancellationToken)
        {


            //prmts.CodEmpresa = (!habilitaMultiEmpresa || String.IsNullOrEmpty(par.CodEmpresa)) ? _baseOperations.CodEmpresa()
            //    : par.CodEmpresa;

            //prmts.CodCentroCusto = (!habilitaMultiUnidade) ? _baseOperations.CodCentroCusto()
            //    //se multiunidade e habilita limpar centro de custo e centro custo é nulo
            //    : (habilitaMultiUnidade && !habilitaLimparUnidade && !par.CodCentroCusto.HasValue) ? _baseOperations.CodCentroCusto()
            //    //centro custo recebido
            //    : par.CodCentroCusto;

            prmts.TotalItens = await _paineisRepository.ContarAsync(prmts, cancellationToken);
            prmts.ItensPorPagina = (prmts.SemPaginacao) ? prmts.TotalItens : prmts.ItensPorPagina ?? 10;
            prmts.PaginaAtual = (!prmts.PaginaAtual.HasValue || prmts.PaginaAtual == 0) ? 1 : prmts.PaginaAtual;

            var lista = await _paineisRepository
                .ObterDadosAsync(prmts, cancellationToken);

            var vm = new PaineisInicio()
            {
                Paineis = lista,

                ParametrosPesquisa = new PaineisPrmtsPesquisa()
                {
                    Id = prmts.Id,
                    TextoPesquisa = prmts.TextoPesquisa,
                    CodEmpresa = prmts.CodEmpresa,
                    CodCentroCusto = prmts.CodCentroCusto,
                    PaginaAtual = prmts.PaginaAtual.Value,
                    ItensPorPagina = prmts.ItensPorPagina,
                    TotalItens = prmts.TotalItens,
                    IsLoaded = true,
                    PaginasTotais = (prmts.ItensPorPagina > 0) ? int.Parse(Math.Ceiling(((decimal)prmts.TotalItens / prmts.ItensPorPagina.Value)).ToString()) : 0
                },

                //HabilitaAdicionar = permiteGravar,
                //HabilitaAlterar = permiteGravar,
                //HabilitaExcluir = permiteGravar,
                //HabilitaMultiEmpresa = habilitaMultiEmpresa,
                //HabilitaMultiUnidade = habilitaMultiUnidade,
                //HabilitaLimparUnidade = (habilitaLimparUnidade && habilitaMultiUnidade)
            };

            return vm;
        }

        public async Task<PaineisInicio> ModoExibicaoAsync(PaineisPrmtsPesquisa prmts, CancellationToken cancellationToken)
        {
            var paineis = await _paineisRepository.ObterDadosModoExibicaoAsync(prmts, cancellationToken);

            var vm = new PaineisInicio()
            {
                Paineis = paineis,
                ParametrosPesquisa = prmts
            };

            return vm;
        }

        public async Task<PaineisResult> ObterPainelPorIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var item = await _paineisRepository.GetByIdAsync(id, cancellationToken);

            var vm = new PaineisResult(item);

            return vm;
        }

        public Task<PaineisResponse> AdicionarAsync(PaineisRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<PaineisResponse> ExcluirAsync(PaineisRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
