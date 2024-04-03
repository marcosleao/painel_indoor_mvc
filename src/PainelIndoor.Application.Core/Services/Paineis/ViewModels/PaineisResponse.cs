using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PainelIndoor.Application.Core.Services.Paineis.ViewModels
{
    public class PaineisResponse : BaseResponse
    {
        public PaineisResponse()
        {
        }

        public PaineisResult Painel { get; set; }
    }
}
