using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PainelIndoor.Application.Core.Services.Conteudos.ViewModels
{
    public class ConteudosResponse : BaseResponse
    {
        public ConteudosResponse()
        {
        }

        public ConteudosResult Painel { get; set; }
    }
}
