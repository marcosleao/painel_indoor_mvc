using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PainelIndoor.Application.Core.Services.Paineis.ViewModels
{
    public class PaineisInicio : ParametrosInicio
    {
        public IEnumerable<PaineisResult> Paineis { get; set; }

        public PaineisRequest Adicionar { get; set; }

        public PaineisRequest Alterar { get; set; }

        public PaineisPrmtsPesquisa ParametrosPesquisa { get; set; }
    }
}
