using Microsoft.EntityFrameworkCore;
using PainelIndoor.Application.Core.Interfaces;
using PainelIndoor.Application.Core.Services.Paineis.ViewModels;
using PainelIndoor.Application.Entities;
using PainelIndoor.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PainelIndoor.Infra.Data.Repositories
{
    public class EFPaineisRepository : EFAsyncRepositoryBase<Paineis>, IPaineisRepository
    {
        public EFPaineisRepository(ApplicationDbContext context) : base(context)
        {          
        }

        public async Task<int> ContarAsync(PaineisPrmtsPesquisa filter, CancellationToken cancellationToken = default)
        {
            return await dbContext.Monitores
                        .Where(GetExpression(filter))
                        .CountAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<PaineisResult>> ObterDadosAsync(PaineisPrmtsPesquisa filter, CancellationToken cancellationToken = default)
        {
            var query = from paineis in dbContext.Monitores
                .Include(p => p.Conteudo)
                .Include(f => f.Filial)
                .Where(GetExpression(filter))
                .Skip(filter.ItensPorPagina.Value * (filter.PaginaAtual.Value - 1))
                            .Take(filter.ItensPorPagina.Value)

                        select new PaineisResult(paineis);

            return await query.ToListAsync(cancellationToken);
        }

        public override async Task<Paineis> GetByIdAsync(object id, CancellationToken cancellationToken = default)
        {
            return await dbContext.Monitores
                            //.Include(p => p.Conteudo)
                            .Include(f => f.Filial)
                            .FirstOrDefaultAsync(p => p.Id == Guid.Parse(id.ToString()));
        }

        public async Task<IReadOnlyList<PaineisResult>> ObterDadosModoExibicaoAsync(PaineisPrmtsPesquisa filter, CancellationToken cancellationToken = default)
        {
            var query = from paineis in dbContext.Monitores
                            .Include(p => p.Conteudo)
                            .Include(f => f.Filial)
                            .Where(p => p.CodFilial == filter.CodFilial)

                        select new PaineisResult(paineis);

            return await query.ToListAsync(cancellationToken);
        }

        public Paineis ObterDetalhesMonitor(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Paineis> ObterMonitoresPorFilial(string codFilial)
        {
            throw new NotImplementedException();
        }

        private static Expression<Func<Paineis, bool>> GetExpression(PaineisPrmtsPesquisa filter)
        {
            return (i => (filter.Id.HasValue) ? i.Id == filter.Id :
            (String.IsNullOrEmpty(filter.TextoPesquisa) || i.Descricao.Contains(filter.TextoPesquisa)
            || i.Filial.NomeFilial.Contains(filter.TextoPesquisa)));
        }
    }
}
