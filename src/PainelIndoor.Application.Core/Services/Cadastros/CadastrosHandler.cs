using System;
using System.Linq;
using PainelIndoor.Application.Core.Interfaces;
using PainelIndoor.Application.Core.Services.Cadastros.ViewModels;

namespace PainelIndoor.Application.Core.Services.Cadastros
{
    public class CadastrosHandler : ICadastrosService
    {
        private readonly IFiliaisRepository _filiaisRepository;
        public CadastrosHandler(IFiliaisRepository filiaisRepository)
        {
            _filiaisRepository = filiaisRepository;
        }

        #region Cadastros

        public async Task<FiliaisInicio> FiliaisDropDown(string codEmpresa, bool isEnabled)
        {
            var filiais = await _filiaisRepository.ObterFiliaisDropDown(codEmpresa, isEnabled);

            var vm = new FiliaisInicio()
            {
                Filiais = filiais.Select(f => new FiliaisDropDown(f.CodFilial, f.ChaveCentroCusto, f.NomeFilial))
            };

            return vm;
        }
        #endregion

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
