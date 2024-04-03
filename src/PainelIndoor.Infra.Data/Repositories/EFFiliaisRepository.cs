using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PainelIndoor.Application.Core.Interfaces;
using PainelIndoor.Application.Entities;
using PainelIndoor.Application.Core.Entities;
using PainelIndoor.Infra.Data.Contexts;
using PainelIndoor.Application.Core.Services.Cadastros.ViewModels;

namespace PainelIndoor.Infra.Data.Repositories
{
    public class EFFiliaisRepository : EFAsyncRepositoryBase<Filiais>, IFiliaisRepository
    {
        public EFFiliaisRepository(ApplicationDbContext dbContext) 
            : base(dbContext)
        {
        }

        public async Task<IReadOnlyList<FiliaisDropDown>> ObterFiliaisDropDown(string codEmpresa, bool isEnabled)
        {
            return await dbContext.GetFiliais
                .Where(f => (codEmpresa == null || f.CodEmpresa == codEmpresa)
                && (!isEnabled || f.IsEnabled == isEnabled))
                .OrderBy(f => f.NomeFilial)
                .Select(f => new FiliaisDropDown(f.CodFilial, null, f.NomeFilial))
                .ToListAsync();
        }

        public async Task<IReadOnlyList<FiliaisDropDown>> ObterFiliaisNaoVinculadas(string codEmpresa, List<string> listaCodFiliais)
        {
            return await dbContext.GetFiliais
               .Where(f => (codEmpresa == "99MT" || f.CodEmpresa == codEmpresa)
               && (listaCodFiliais == null || !listaCodFiliais.Contains(f.CodFilial))
               && f.IsEnabled == true)
               .Select(f => new FiliaisDropDown(f.CodFilial, f.ChaveCentroCusto, f.NomeFilial))
               .OrderBy(f => f.NomeFilial)
               .ToListAsync();
        }

        public Task<Filiais> ObterDetalhesFilial(Guid id)
        {
            var dados = dbContext.GetFiliais
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();

            return dados;
        }


        public bool SeExiste(Filiais item)
        {
            return dbContext.GetFiliais.Any(e => e.CnpjFilial == item.CnpjFilial
            || e.CodFilial == item.CodFilial || e.NomeFilial == item.NomeFilial);
        }

        public bool SeExisteCnpjFilial(string cnpjFilial)
        {
            return dbContext.GetFiliais.Any(e => e.CnpjFilial == cnpjFilial);
        }

        public bool SeExisteCodFilial(string codFilial)
        {
            return dbContext.GetFiliais.Any(e => e.CodFilial == codFilial);
        }

        public bool SeExisteNomeFilial(string nomeFilial)
        {
            return dbContext.GetFiliais.Any(e => e.NomeFilial == nomeFilial);
        }

        public List<string> ObterCodFiliaisPorEmpresa(string codEmpresa, bool isEnabled)
        {
            return dbContext.GetFiliais
                .Where(p => (String.IsNullOrEmpty(codEmpresa) || p.CodEmpresa == codEmpresa)
                && p.IsEnabled == isEnabled)
                .Select(p => p.CodFilial)
                .ToList();
        }

        public async Task<Filiais> ObterDetalhesFilialPorCodigo(string codFilial)
        {
            var dados = await dbContext.GetFiliais
                .Where(p => p.CodFilial == codFilial)
                .FirstOrDefaultAsync();

            return dados;
        }
    }
}
