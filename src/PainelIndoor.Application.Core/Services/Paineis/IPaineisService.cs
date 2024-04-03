using PainelIndoor.Application.Core.Services.Paineis.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PainelIndoor.Application.Core.Services.Paineis
{
    public interface IPaineisService : IDisposable
    {
        Task<PaineisInicio> ListarAsync(PaineisPrmtsPesquisa prmts, CancellationToken cancellationToken = default);
        Task<PaineisInicio> ModoExibicaoAsync(PaineisPrmtsPesquisa prmts, CancellationToken cancellationToken = default);
        Task<PaineisResult> ObterPainelPorIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<PaineisResponse> ExcluirAsync(PaineisRequest request, CancellationToken cancellationToken = default);
        Task<PaineisResponse> AdicionarAsync(PaineisRequest request, CancellationToken cancellationToken = default);
    }
}
