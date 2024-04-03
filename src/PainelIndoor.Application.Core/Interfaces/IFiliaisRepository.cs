using PainelIndoor.Application.Core.Entities;
using PainelIndoor.Application.Core.Services.Cadastros.ViewModels;
using PainelIndoor.Application.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PainelIndoor.Application.Core.Interfaces
{
    public interface IFiliaisRepository : IAsyncRepositoryBase<Filiais>
    {
        Task<Filiais> ObterDetalhesFilial(Guid id);
        Task<Filiais> ObterDetalhesFilialPorCodigo(string codFilial);
        Task<IReadOnlyList<FiliaisDropDown>> ObterFiliaisDropDown(string codEmpresa, bool isEnabled);
        //Obtem a lista de filiais não vinculadas à entidade atual (entidade em excibição)
        Task<IReadOnlyList<FiliaisDropDown>> ObterFiliaisNaoVinculadas(string codEmpresa, List<string> listaCodFiliais);

        /// <summary>
        /// Obtém os Códigos de Filiais por empresa 
        /// </summary>
        /// <param name="codEmpresa"></param>
        /// <param name="isEnabled"></param>
        /// <returns></returns>
        List<string> ObterCodFiliaisPorEmpresa(string codEmpresa, bool isEnabled);
    }
}
