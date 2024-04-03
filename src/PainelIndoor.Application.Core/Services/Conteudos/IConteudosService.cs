using PainelIndoor.Application.Core.Services.Paineis.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PainelIndoor.Application.Core.Services.Conteudos
{
    public interface IConteudosService : IDisposable
    {

        Task<PaineisResponse> ExcluirAsync(PaineisRequest request, CancellationToken cancellationToken);

        Task<PaineisResponse> AdicionarAsync(PaineisRequest request, CancellationToken cancellationToken);
    }
}
