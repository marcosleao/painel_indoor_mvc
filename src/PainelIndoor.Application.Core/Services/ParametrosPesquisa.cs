using PainelIndoor.Application.Core.Extensions;
using System.ComponentModel;

namespace PainelIndoor.Application.Core.Services
{
    public class ParametrosPesquisa : Paginacao
    {
        public Guid? Id { get; set; }

        public string CodEmpresa { get; set; }

        public string CodFilial { get; set; }

        private long? _codCentroCusto;
        public long? CodCentroCusto
        {
            get => _codCentroCusto;

            set => _codCentroCusto = (value == 0) ? null : value;
        }

        private string _fkCentroCusto;
        public string FKCentroCusto
        {
            get => _fkCentroCusto;

            set => _fkCentroCusto = (CodCentroCusto.HasValue) ? CodEmpresa + "-" + CodCentroCusto.ToString() : null;
        }

        private long? _codItemContabil;
        public long? CodItemContabil
        {
            get => _codItemContabil;

            set => _codItemContabil = (value == 0) ? null : value;
        }

        private string _fkItemContabil;
        public string FKItemContabil
        {
            get => _fkItemContabil;

            set => _fkItemContabil = (CodItemContabil.HasValue) ? CodEmpresa + "-" + CodItemContabil.ToString() : null;
        }

        private string _textoPesquisa;
        public string TextoPesquisa
        {
            get => _textoPesquisa;

            set => _textoPesquisa = (string.IsNullOrEmpty(value)) ? null : AjustarTextos.TextoPadrao(value);
        }

        private int? _idSituacao;
        public int? IdSituacao
        {
            get => _idSituacao;

            set => _idSituacao = (value == 0) ? null : value;
        }

        public Guid? UserId { get; set; }

        public string NomeUsuario { get; set; }

        public bool IsLoaded { get; set; } = true;
    }
}
