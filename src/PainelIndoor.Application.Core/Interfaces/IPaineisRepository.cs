using PainelIndoor.Application.Core.Services.Paineis.ViewModels;
using PainelIndoor.Application.Entities;
using System;
using System.Collections.Generic;

namespace PainelIndoor.Application.Core.Interfaces
{
    public interface IPaineisRepository : IAsyncRepositoryBase<Paineis>
    {
        Task<int> ContarAsync(PaineisPrmtsPesquisa filter, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<PaineisResult>> ObterDadosAsync(PaineisPrmtsPesquisa filter, CancellationToken cancellationToken = default);
        Task<IReadOnlyList<PaineisResult>> ObterDadosModoExibicaoAsync(PaineisPrmtsPesquisa filter, CancellationToken cancellationToken = default);
        Paineis ObterDetalhesMonitor(Guid id);
    }
}
