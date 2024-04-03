namespace PainelIndoor.Application.Core.Services.Cadastros.ViewModels
{
    public class FiliaisDropDown
    {
        public FiliaisDropDown(string codFilial, string chaveCentroCusto, string nomeFilial)
        {
            CodFilial = codFilial;
            ChaveCentroCusto = chaveCentroCusto;
            NomeFilial = nomeFilial;
        }

        public string CodFilial { get; }
        public string ChaveCentroCusto { get; }
        public string NomeFilial { get; }
    }
}
