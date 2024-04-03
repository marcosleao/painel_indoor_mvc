using System.ComponentModel;

namespace PainelIndoor.Application.Core.Services
{
    public class Paginacao
    {
        public bool SemPaginacao { get; set; }

        public int TotalItens { get; set; }

        public int? ItensPorPagina { get; set; } = 10;

        public int? PaginaAtual { get; set; } = 1;

        public int PaginasTotais { get; set; } = 0;

        public bool IsVisibleAnterior { get; set; }

        public bool IsVisibleProxima { get; set; }
    }
}
