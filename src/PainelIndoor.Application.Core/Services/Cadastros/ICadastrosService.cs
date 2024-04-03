using PainelIndoor.Application.Core.Services.Cadastros.ViewModels;
using System;

namespace PainelIndoor.Application.Core.Services.Cadastros
{
    public interface ICadastrosService : IDisposable
    {
        Task<FiliaisInicio> FiliaisDropDown(string codEmpresa, bool isEnabled);
    }
}
